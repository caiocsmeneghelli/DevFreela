﻿using DevFreela.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Services
{
    public interface IPaymentServices
    {
        void ProcessPayment(PaymentInfoDTO paymentInfoDTO);
    }
}
