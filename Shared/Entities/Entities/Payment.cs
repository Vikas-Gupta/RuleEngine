using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared.Enum;

namespace Shared.Entities
{
    public class Payment
    {
        public Enum_PaymentType PaymentType {get; set;}
        public string ProductName {get; set;}
        public bool IsBook { get; set; }
    }
}
