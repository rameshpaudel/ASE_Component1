using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPL_Component1;
namespace GPL_Tests
{
    [TestClass]
    public class ShapesValidationTest
    {
        private ShapesValidator sv;


        [TestInitialize]
        public void Initialize()
        {
            
            this.sv = new ShapesValidator();
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
