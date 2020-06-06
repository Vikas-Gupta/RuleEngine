using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RuleEngineTest
{
    [TestClass]
    public class TestAll
    {
        [TestMethod]
        public void Add_Physical_Product_Rule()
        {
            Rule rule = new Rule();
            Assert.IsTrue(RuleManager.AddRule(rule));
        }
    }
}
