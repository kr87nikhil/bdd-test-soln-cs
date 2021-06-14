using System;
using NUnit.Framework;
using Calculator.Controllers;

namespace Calculator.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class CalculatorTests
    {
        private CalculatorService calculatorService;

        [SetUp]
        public void Setup()
        {
            calculatorService = new CalculatorService();
        }

        [Test]
        [TestCase(10, 93.7, 103.7)]
        [TestCase(2, 7, 9)]
        public void WhenAdditionIsPerformed(double firstNumber, double secondNumber, double expectedResult)
        {
            double actualResult = calculatorService.Addition(firstNumber, secondNumber);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void WhenSubtractionIsPerformed()
        {
            Assert.Fail();
        }

        [Test]
        public void WhenMultiplicationIsPerformed()
        {
            Assert.Fail();
        }

        [Test]
        [TestCase(103, 2, 51.5)]
        [TestCase(27.0, 3, 9.0)]
        public void WhenDivisionIsPerformed(double firstNumber, double secondNumber, double expectedResult)
        {
            double actualResult = calculatorService.Division(firstNumber, secondNumber);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void WhenDivisionIsPerformedByZero()
        {
            double firstNumber = new Random().Next();
            Assert.Throws<DivideByZeroException>(() => calculatorService.Division(firstNumber, 0));
        }
    }
}