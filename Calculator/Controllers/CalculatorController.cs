using System;

namespace Calculator.Controllers
{
    public class CalculatorController : ICalculatorService
    {
        public double Addition(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public double Division(double firstNumber, double secondNumber)
        {
            return firstNumber / secondNumber;
        }

        public double Multiplication(double firstNumber, double secondNumber)
        {
            throw new NotImplementedException();
        }

        public double Subtraction(double firstNumber, double secondNumber)
        {
            throw new NotImplementedException();
        }
    }
}
