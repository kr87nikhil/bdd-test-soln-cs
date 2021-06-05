using NUnit.Framework;
using Calculator.Controllers;

namespace Calculator.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class CalculatorTests
    {
        private CalculatorController calculatorController;

        [SetUp]
        public void Setup()
        {
            calculatorController = new CalculatorController();
        }

        [Test]
        [TestCase(10, 93.7, 103.7)]
        [TestCase(2, 7, 9)]
        public void WhenAdditionIsPerformed(double firstNumber, double secondNumber, double expectedResult)
        {
            double actualResult = calculatorController.Addition(firstNumber, secondNumber);
            Assert.AreEqual(actualResult, expectedResult);
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
        [TestCase(103, 2, 51.5)]
        [TestCase(27.0, 3, 9.0)]
        public void WhenDivisionIsPerformed(double firstNumber, double secondNumber, double expectedResult)
        {
            double actualResult = calculatorController.Division(firstNumber, secondNumber);
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}