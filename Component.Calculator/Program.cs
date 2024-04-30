using System;
using Calculator.Controllers;

namespace Calculator
{
    internal sealed class Program: WrongInputHandler
    {
        private static readonly CalculatorService calculatorService = new CalculatorService();

        private static int selectedOption = 0;
        private static double firstNumber, secondNumber, result;

        public static void Main()
        {
            Console.WriteLine("Select operation to be performed");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division\n");
            Console.Write("Select option: ");

            PerformOperation(() => {
                selectedOption = int.Parse(Console.ReadLine());
                var performOperation = calculatorService.GetAllValidOperations()[selectedOption - 1];
                Console.Write("Enter 1st number: ");
                firstNumber = double.Parse(Console.ReadLine());
                Console.Write("Enter 2nd number: ");
                secondNumber = double.Parse(Console.ReadLine());
                result = performOperation(firstNumber, secondNumber);
                Console.WriteLine("\nResult: " + result);
            });
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
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Wrong option selected");
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong Input data type received");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Invalid operaton: Devision by 0 encountered");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception: " + exception.Message);
            }
        }
    }
}
