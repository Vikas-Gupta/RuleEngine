using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared.Entities.Interface;
using Shared.Enum;

namespace Shared.Entities.Entities
{
    public class E_MailRule : IRule
    {

        public string ApplyRule(Payment payment)
        {
            if (payment.PaymentType == Enum_PaymentType.Membership)
            {
                return "Mail To Owner About Membership Activation";
            }
            if (payment.PaymentType == Enum_PaymentType.Upgrade)
            {
                return "Mail To Owner About Membership Upgradation";
            }
            return string.Empty;
        }
    }
}
