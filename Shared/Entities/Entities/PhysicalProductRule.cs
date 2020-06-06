using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared.Entities.Interface;

namespace Shared.Entities.Entities
{
    public class PhysicalProductRule : IRule
    {
        public string ApplyRule(Payment payment)
        {
            if (payment.PaymentType == Enum.Enum_PaymentType.PhysicalProduct)
            {
                return "Generate Packing Slip";
            }
            return string.Empty;
        }
    }
}
