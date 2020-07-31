using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorApp.Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void TestDivide10and2()
        {
            double a = 10.0;
            double b = 2.0;
            double expected = 6.0;

            Calculator calc = new Calculator();
            double actual = calc.Divide(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}
