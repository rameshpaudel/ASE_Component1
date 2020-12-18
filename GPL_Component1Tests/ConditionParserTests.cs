using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPL_Component1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL_Component1.Tests
{
    [TestClass()]
    public class ConditionParserTests
    {


        private ConditionParser cp;


        [TestInitialize]
        public void Initialize()
        {

            VariableParser.GetInstance();
            this.cp = new ConditionParser();
        }

       
        [TestMethod()]
        public void checkValidPassingIfConditionTest()
        {
            VariableParser.setVariable("count = 10");
            string validCondition = "if count < 20 then";
            this.cp.setCondition(validCondition);
            Assert.IsTrue(this.cp.validateExpression());
        }


        [TestMethod()]
        public void checkInvalidFailingIfConditionTest()
        {
            VariableParser.setVariable("fail = 10");
            string validCondition = "if fail > 20 then";
            this.cp.setCondition(validCondition);
            Assert.IsFalse(this.cp.validateExpression());
        }

        [TestMethod()]
        public void checkValidPassingLoopConditionTest()
        {
            VariableParser.setVariable("pass = 10");
            string validLoopCondition = "loop pass < 20";
            this.cp.setLoopCondition(validLoopCondition);
            Assert.IsTrue(this.cp.validateExpression());
        }

        [TestMethod()]
        public void checkValidFailingLoopConditionTest()
        {
            VariableParser.setVariable("test = 10");
            string validLoopCondition = "loop test > 20 then";
            this.cp.setLoopCondition(validLoopCondition);
            Assert.IsFalse(this.cp.validateExpression());
        }


    }
}