using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Interfaces;
using Shared.Entities.Interface;
using Shared.Entities;

namespace Business.Managers
{
    public class RuleManager : IRuleManager
    {
        List<IRule> _rules = new List<IRule>();

        public RuleManager()
        {

        }

        public List<string> ExecuteRules(Payment payment)
        {
            List<string> result = new List<string>();

            foreach (var rule in _rules)
            {
                result.Add(rule.ApplyRule(payment));
            }

            return result;
        }


        public void AddRule(IRule rule)
        {
            _rules.Add(rule);
        }
    }
}
