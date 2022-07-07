namespace DotNet.IntegrationTesting.Demo1.Application.Service
{
    using DotNet.IntegrationTesting.Demo1.Application.IService;

    public class TemperatureConversionService : ITemperatureConversionService
    {
        public double ConvertCelsiusToFahrenheit(double temperature)
        {
            return (temperature * 9 / 5) + 32;
        }

        public double ConvertFahrenheitToCelsius(double temperature)
        {
            return (temperature - 32) * 5 / 9;
        }
    }
}
