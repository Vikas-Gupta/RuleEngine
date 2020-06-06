using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared.Entities.Interface;
using Shared.Enum;

namespace Shared.Entities.Entities
{
    public class VideoRule : IRule
    {
        public string ApplyRule(Payment payment)
        {
            if (payment.PaymentType == Enum_PaymentType.Video)
            {
                return "Add Free First Aid Video";
            }
            return string.Empty;
        }
    }
}
