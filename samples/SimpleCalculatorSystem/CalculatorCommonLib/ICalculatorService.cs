using Hik.Communication.MbtServices.Service;

namespace CalculatorCommonLib
{
    /// <summary>
    /// This interface defines methods of calculator service that can be called by clients.
    /// </summary>
    [MbtService]
    public interface ICalculatorService
    {
        int Add(int number1, int number2);

        double Divide(double number1, double number2);
    }
}
