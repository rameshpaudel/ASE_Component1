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
    public class CommandValidatorTests
    {

        private CommandValidator sv;


        [TestInitialize]
        public void Initialize()
        {

            this.sv = new CommandValidator();
            VariableParser.GetInstance();
        }

        [TestMethod()]
        public void validatePassesIfCorrectTest()
        {
            Boolean validation = this.sv.validate("circle");
            Assert.IsTrue(validation);
        }

        [TestMethod()]
        public void validatePassesIfInCorrectTest()
        {
            Boolean validation = this.sv.validate("test");
            Assert.IsFalse(validation);
        }


        [TestMethod()]
        public void IsDigitsOnlyFailsOnCharacterTest()
        {
            string characters = "test this out";
            Assert.IsFalse(this.sv.IsDigitsOnly(characters));
        }

        [TestMethod()]
        public void IsDigitsOnlyPassesOnDigitTest()
        {
            
            Assert.IsTrue(this.sv.IsDigitsOnly("234"));
        }

        [TestMethod()]
        public void isValidVarPassesOnValidInputTest()
        {
            string validVar = "test = 200";
            Boolean variableStatus = this.sv.isValidVar(validVar);
            Assert.IsTrue(variableStatus);

        }


        [TestMethod()]
        public void isValidVarFailsOnValidInputTest()
        {
            string invalidVar = "test > 200";
            Boolean variableStatus = this.sv.isValidVar(invalidVar);
            Assert.IsFalse(variableStatus);

        }

        [TestMethod()]
        public void checkValidShapeTest()
        {
            string shape = "rectangle";
            Boolean status = this.sv.checkValidShape(shape);
            Assert.IsTrue(status);
        }

        [TestMethod()]
        public void checkValidFunctionTest()
        {
            string function = "moveto";
            Boolean status = this.sv.checkValidFunction(function);
            Assert.IsTrue(status);

        }

        [TestMethod()]
        public void checkInvalidConditionExpresssionFailsTest()
        {
            string validCond = "+";
            Boolean status = this.sv.checkValidCondition(validCond);
            Assert.IsFalse(status);
        }

        [TestMethod()]
        public void checkValidConditionExpresssionPassesTest()
        {
            string validCond = ">";
            Boolean status = this.sv.checkValidCondition(validCond);
            Assert.IsTrue(status);
        }

        [TestMethod()]
        public void checkInvalidIfConditionFailsTest()
        {
            VariableParser.setVariable("count = 10");
            string validCond = "if count == 10 500 then";
            Assert.IsFalse(this.sv.checkValidIfCondition(validCond));
        }

        [TestMethod()]
        public void checkEndIfTest()
        {
            string cmd = "endif";
            Assert.IsTrue(this.sv.checkEndIf(cmd));
        }

        [TestMethod()]
        public void checkValidLoopConditionTest()
        {
            VariableParser.setVariable("test = 1");
            string cmd = "loop test < 3";
            Assert.IsTrue(this.sv.checkValidLoopCondition(cmd));
        }

       
        
    }
}