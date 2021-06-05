using NUnit.Framework;
using Calculator.Controllers;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        private CalculatorController calculatorController;

        [SetUp]
        public void Setup()
        {
            calculatorController = new CalculatorController();
        }

        [Test]
        public void WhenAdditionIsPerformed()
        {
            Assert.Pass();
        }

        [Test]
        public void WhenSubtractionIsPerformed()
        {
            Assert.Pass();
        }

        [Test]
        public void WhenMultiplicationIsPerformed()
        {
            Assert.Pass();
        }

        [Test]
        public void WhenDivisionIsPerformed()
        {
            Assert.Pass();
        }
    }
}