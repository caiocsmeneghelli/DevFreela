using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
       private readonly IProjectRepository _projectRepository;
       private readonly IPaymentServices _paymentServices;

        public FinishProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<bool> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            if (project == null)
                return false;
            project.Finish();

            var paymentInfo = new PaymentInfoDTO(request.Id, request.CreditCardNumber,
                request.Cvv, request.ExpiresAt, request.FullName);
            var result = await _paymentServices.ProcessPayment(paymentInfo);

            if (!result)
                project.SetPaymentPending();

            await _projectRepository.SaveChangesAsync();

            return result;
        }
    }
}