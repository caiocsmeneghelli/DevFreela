using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.ViewModels.User;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var stringPassword = _authService.ComputeSha256Hash(request.Password);
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, stringPassword);
            if (user == null) { return null; }
            var token = _authService.GenerateJwtToken(user.Email, user.Role);
            var viewModel = new LoginUserViewModel(user.Email, token);
            return viewModel;
        }
    }
}