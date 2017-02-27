using FormulaCalculation.Interfaces;
using FormulaCalculation.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormulaCalculationTest
{
    [TestClass]
    public class CalculatorTest
    {
        private ICalculator _calculator;

        [TestMethod]
        public void TestCalculateReturnsCorrectFormate()
        {
            _calculator = new Calculator();
            var result = _calculator.Calculate("-", 1, 1);
            Assert.IsTrue(result.Equals("1 - 1 = 0"));
        }

        [TestMethod]
        public void TestCalculateReturnsNotNull()
        {
            _calculator = new Calculator();
            var result = _calculator.Calculate("+", 2, 2);
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void TestCalculateWithImproperOperatorReturnsMessage()
        {
            _calculator = new Calculator();
            var result = _calculator.Calculate("a", 1, 1);
            Assert.IsTrue(result.Equals("Operation not accepted"));
        }

        [TestMethod]
        public void TestCalculateWithParmReturnsMessage()
        {
            _calculator = new Calculator();
            var result = _calculator.Calculate("+", 'a', 1);
            Assert.IsTrue(result.Equals("Parm is not a Number"));
        }
    }
}
