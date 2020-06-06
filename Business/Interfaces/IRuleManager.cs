using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared.Entities.Interface;

namespace Business.Interfaces
{
    public interface IRuleManager
    {
        List<string> ExecuteRules();

        void AddRule(IRule rule);
    }
}
