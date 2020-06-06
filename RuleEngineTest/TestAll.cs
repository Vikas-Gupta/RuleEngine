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

        [TestMethod]
        public void Add_Book_Rule()
        {
            Payment payment = new Payment();
            payment.PaymentType = Enum_PaymentType.PhysicalProduct;
            payment.ProductName = "Harry Potter Book";
            payment.IsBook = true;
            IRule rule = new BookRule();
            ruleManager.AddRule(rule);
            var ruleResult = ruleManager.ExecuteRules(payment);
            bool isBookRuleApplied = ruleResult.Contains("Packing Slip for Royalty Department");
            Assert.IsTrue(isBookRuleApplied);
        }

        [TestMethod]
        public void Add_Book_And_Physical_Rule()
        {
            Payment payment = new Payment();
            payment.PaymentType = Enum_PaymentType.PhysicalProduct;
            payment.ProductName = "Harry Potter Book";
            payment.IsBook = true;
            IRule rule = new BookRule();
            ruleManager.AddRule(rule);
            // Both rule so that both rules will be added to rule result;
            rule = new PhysicalProductRule();
            ruleManager.AddRule(rule);
            var ruleResult = ruleManager.ExecuteRules(payment);
            bool isBookRuleApplied = ruleResult.Contains("Packing Slip for Royalty Department");
            Assert.IsTrue(isBookRuleApplied);
            bool isPhysicalRuleApplied = ruleResult.Contains("Generate Packing Slip");
            Assert.IsTrue(isPhysicalRuleApplied);
        }

        [TestMethod]
        public void Add_Membership_Rule()
        {
            Payment payment = new Payment();
            payment.PaymentType = Enum_PaymentType.Membership;
            payment.ProductName = "Golf Club Membership";
            payment.IsBook = false;
            IRule rule = new MembershipRule();
            ruleManager.AddRule(rule);
            rule = new E_MailRule();
            ruleManager.AddRule(rule);
            var ruleResult = ruleManager.ExecuteRules(payment);
            bool isMembershipRuleApplied = ruleResult.Contains("Activate Membership");
            Assert.IsTrue(isMembershipRuleApplied);
            bool isActivationMailSent = ruleResult.Contains("Mail To Owner About Membership Activation");
            Assert.IsTrue(isActivationMailSent);
        }

        [TestMethod]
        public void Add_Upgrade_Membership_Rule()
        {
            Payment payment = new Payment();
            payment.PaymentType = Enum_PaymentType.Upgrade;
            payment.ProductName = "Golf Club Membership";
            payment.IsBook = false;
            IRule rule = new UpgradeMembershipRule();
            ruleManager.AddRule(rule);
            rule = new E_MailRule();
            ruleManager.AddRule(rule);
            var ruleResult = ruleManager.ExecuteRules(payment);
            bool isMembershipUpgradeRuleApplied = ruleResult.Contains("Upgrade Membership");
            Assert.IsTrue(isMembershipUpgradeRuleApplied);
            bool isActivationMailSent = ruleResult.Contains("Mail To Owner About Membership Upgradation");
            Assert.IsTrue(isActivationMailSent);
        }
    }
}
