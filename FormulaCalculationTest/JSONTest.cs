using FormulaCalculation.Interfaces;
using FormulaCalculation.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FormulaCalculationTest
{
    [TestClass]
    public class JSONTest
    {
        private IJSON _json;

        [TestMethod]
        public void TestGetJSONReturnsCorrectFormate()
        {
            _json = new JSON();
            var result = _json.getJSON();
            Assert.IsTrue(result is Dictionary<string, dynamic>);
        }

        [TestMethod]
        public void TestGetJSONReturnsNotNull()
        {
            _json = new JSON();
            var result = _json.getJSON();
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void TestGetJSONReturnsParam1()
        {
            _json = new JSON();
            var result = _json.getJSON();
            dynamic value;
            result.TryGetValue("parm1", out value);

            Assert.IsTrue(value != null);
        }

        [TestMethod]
        public void TestGetJSONReturnsParam2()
        {
            _json = new JSON();
            var result = _json.getJSON();
            dynamic value;
            result.TryGetValue("parm2", out value);

            Assert.IsTrue(value != null);
        }

        [TestMethod]
        public void TestGetJSONReturnsOP()
        {
            _json = new JSON();
            var result = _json.getJSON();
            dynamic value;
            result.TryGetValue("op", out value);

            Assert.IsTrue(value != null);
        }
    }
}
