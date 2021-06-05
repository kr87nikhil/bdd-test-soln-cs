namespace Calculator
{
    public interface ICalculatorService
    {
        double Addition(double firstNumber, double secondNumber);
        double Subtraction(double firstNumber, double secondNumber);
        double Multiplication(double firstNumber, double secondNumber);
        double Division(double firstNumber, double secondNumber);
    }
}
