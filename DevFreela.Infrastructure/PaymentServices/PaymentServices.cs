using DevFreela.Core.DTOs;
using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Http;
using Newtonsoft.Json;

namespace DevFreela.Infrastructure.PaymentServices
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IMessageBusService _messageBusService;
        private readonly string QUEUE_NAME = "Payments";

        public PaymentServices(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }

        public async void ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            var paymentInfoJson = JsonConvert.SerializeObject(paymentInfoDTO);
            var paymentByte = Encoding.UTF8.GetBytes(paymentInfoJson);

            _messageBusService.Publish(QUEUE_NAME, paymentByte);
        }
    }
}
