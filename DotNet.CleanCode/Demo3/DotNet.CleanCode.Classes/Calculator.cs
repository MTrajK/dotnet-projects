using System;

namespace DotNet.CleanCode.Classes
{
    public class Calculator
    {
        public const double PI = 3.14;

        private double _result;

        public Calculator()
        {
            _result = 0;
        }

        public void Add(int number)
        {
            Log("Add " + number);

            _result += number;
        }

        public void Multipy(int number)
        {
            Log("Multipy " + number);

            _result *= number;
        }

        public void Divide(int number)
        {
            Log("Divide " + number);
            
            if (number == 0)
                throw new ArgumentException("Can not divide with 0.");

            _result /= number;
        }

        public double GetResult()
        {
            Log("GetResult " + _result);

            return _result;
        }

        private void Log(string message)
        {
            // Logging
        }
    }
}
