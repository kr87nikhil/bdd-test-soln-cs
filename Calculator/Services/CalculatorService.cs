using System;

namespace Calculator.Controllers
{
    public class CalculatorService : ICalculatorService
    {
        public delegate double CalculatorOperations(double firstNumber, double secondNumber);

        public CalculatorOperations[] GetAllValidOperations()
        {
            return new CalculatorOperations[] {
                Addition, Subtraction, Multiplication, Division
            };
        }

        public double Addition(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public double Division(double firstNumber, double secondNumber)
        {
            if (secondNumber == 0)
            {
                throw new DivideByZeroException("Devisor is 0");
            }
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
