using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared.Entities.Interface;
using Shared.Enum;

namespace Shared.Entities.Entities
{
    public class CommissionRule : IRule
    {
        public string ApplyRule(Payment payment)
        {
            if (payment.PaymentType == Enum_PaymentType.PhysicalProduct || payment.IsBook)
            {
                return "Commission Payment to Agent";
            }
            return string.Empty;
        }
    }
}
