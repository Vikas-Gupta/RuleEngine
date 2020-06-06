using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Entities.Interface;
using Shared.Entities.Entities;
using Business.Interfaces;
using Business.Managers;
using Shared.Entities;
using Shared.Enum;

namespace RuleEngineTest
{
    [TestClass]
    public class TestAll
    {
        private IRuleManager ruleManager;

        public TestAll()
        {
            // We can implement DI but I am having VS 2010 on my system
            // So not able to implement right now as not able to find any DI container compatible 
            // with VS 2010
            ruleManager = new RuleManager();
        }

        [TestMethod]
        public void Add_Physical_Product_Rule()
        {
            Payment payment = new Payment();
            payment.PaymentType = Enum_PaymentType.PhysicalProduct;
            payment.ProductName = "Computer";
            IRule rule = new PhysicalProductRule();
            ruleManager.AddRule(rule);
            var ruleResult = ruleManager.ExecuteRules(payment);
            bool isPhysicalRuleApplied = ruleResult.Contains("Generate Packing Slip");
            Assert.IsTrue(isPhysicalRuleApplied);
        }
    }
}
