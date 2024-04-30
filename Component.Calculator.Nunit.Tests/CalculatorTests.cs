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
        [TestCase(-2, -7, -9)]
        [TestCase(-4, 48, 44)]
        public void WhenAdditionIsPerformed(double firstNumber, double secondNumber, double expectedResult)
        {
            double actualResult = calculatorService.Addition(firstNumber, secondNumber);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(9864, 78536, -68672)]
        [TestCase(32, -96, 128)]
        [TestCase(4546, 343, 4203)]
        public void WhenSubtractionIsPerformed(double firstNumber, double secondNumber, double expectedResult)
        {
            double actualResult = calculatorService.Subtraction(firstNumber, secondNumber);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(4, 6, 24)]
        [TestCase(51686, 6454, 333581444)]
        [TestCase(-629, 27, -16983)]
        public void WhenMultiplicationIsPerformed(double firstNumber, double secondNumber, double expectedResult)
        {
            double actualResult = calculatorService.Multiplication(firstNumber, secondNumber);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(103, 2, 51.5)]
        [TestCase(27.0, 3, 9.0)]
        [TestCase(-4689, 33, -142.09090909090909)]
        [TestCase(22, 7, 3.1428571428571428)]
        public void WhenDivisionIsPerformed(double firstNumber, double secondNumber, double expectedResult)
        {
            double actualResult = calculatorService.Division(firstNumber, secondNumber);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void WhenDivisionIsPerformedByZero()
        {
            double firstNumber = new Random().Next();
            Assert.Throws<DivideByZeroException>(() => calculatorService.Division(firstNumber, 0));
        }
    }
}