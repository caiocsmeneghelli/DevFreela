using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.DTOs
{
    public class PaymentInfoDTO
    {
        public PaymentInfoDTO(int id, string creditCardNumber, string cvv, string expiresAt, string fullName)
        {
            IdProject = id;
            CreditCardNumber = creditCardNumber;
            Cvv = cvv;
            ExpireAt = expiresAt;
            FullName = fullName;
            Amount = 0;
        }

        public int IdProject { get; private set; }
        public string CreditCardNumber { get; private set; }
        public string Cvv { get; private set; }
        public string ExpireAt { get; private set; }
        public string FullName { get; private set; }
        public decimal Amount { get; set; }
    }
}
