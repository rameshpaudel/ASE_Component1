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
    public class ShapesFactoryTests
    {
        private CommandValidator sv;


        [TestInitialize]
        public void Initialize()
        {

            this.sv = new CommandValidator();
        }

        [TestMethod]
        public void TestValidCirclePasses()
        {

            bool isCircle = this.sv.validate("circle");
            Assert.AreEqual(isCircle, true);

        }
        [TestMethod]
        public void TestInvalidShapeFails()
        {

            bool invalid = this.sv.validate("space");
            Assert.AreEqual(invalid, false);
        }
    }
}