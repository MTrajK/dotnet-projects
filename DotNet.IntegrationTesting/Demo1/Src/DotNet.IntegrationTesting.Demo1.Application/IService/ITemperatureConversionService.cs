namespace DotNet.IntegrationTesting.Demo1.Application.IService
{
    public interface ITemperatureConversionService
    {
        public double ConvertCelsiusToFahrenheit(double temperature);

        public double ConvertFahrenheitToCelsius(double temperature);
    }
}
