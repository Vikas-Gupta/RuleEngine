using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared.Entities.Interface;
using Shared.Entities;

namespace Business.Interfaces
{
    public interface IRuleManager
    {
        List<string> ExecuteRules(Payment payment);

        void AddRule(IRule rule);
    }
}
