using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared.Entities.Interface;

namespace Shared.Entities.Entities
{
    public class BookRule : IRule
    {
        public string ApplyRule(Payment payment)
        {
            if (payment.IsBook)
            {
                return "Packing Slip for Royalty Department";
            }
            return string.Empty;
        }
    }
}
