using System;
using Calculator.Controllers;

namespace Calculator
{
    class Program: WrongInputHandler
    {
        private static int selectedOption = 0;
        private static double firstNumber, secondNumber, result;
        private static CalculatorController calculatorController;

        static void Main()
        {
            Console.WriteLine("Select operation to be performed");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division\n");
            Console.Write("Select option: ");
            PerformOperation(() => {
                selectedOption = int.Parse(Console.ReadLine());
                Console.Write("Enter 1st number: ");
                firstNumber = double.Parse(Console.ReadLine());
                Console.Write("Enter 2nd number: ");
                secondNumber = double.Parse(Console.ReadLine());
            });
            calculatorController = new CalculatorController();
            switch (selectedOption) {
                case 1:
                    PerformOperation(() =>
                    {
                        result = calculatorController.Addition(firstNumber, secondNumber);
                    });
                    break;
                case 2:
                    PerformOperation(() =>
                    {
                        result = calculatorController.Subtraction(firstNumber, secondNumber);
                    });
                    break;
                case 3:
                    PerformOperation(() =>
                    {
                        result = calculatorController.Multiplication(firstNumber, secondNumber);
                    });
                    break;
                case 4:
                    PerformOperation(() =>
                    {
                        result = calculatorController.Division(firstNumber, secondNumber);
                    });
                    break;
                default:
                    Console.WriteLine("Wrong option selected. Please provide correct option");
                    break;
            }
            Console.WriteLine("Result: " + result);
        }
    }

    internal class WrongInputHandler
    {
        public static void PerformOperation(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (FormatException exception)
            {
                Console.WriteLine("Wrong Input received. Please enter correct input");
                Console.WriteLine("Exception: " + exception.Message);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Devide by 0 operation encountered. Second number for devision should not be 0");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception: " + exception.Message);
            }
            finally
            {
                Console.WriteLine();
            }
        }
    }
}
