using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Interfaces;
using Shared.Entities.Interface;

namespace Business.Managers
{
    public class RuleManager : IRuleManager
    {
        List<IRule> _rules = new List<IRule>();

        public RuleManager()
        {

        }

        public List<string> ExecuteRules()
        {
            throw new NotImplementedException();
        }


        public void AddRule(IRule rule)
        {
            _rules.Add(rule);
        }
    }
}
