namespace DotNet.IntegrationTesting.Demo1.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using DotNet.IntegrationTesting.Demo1.Application.IService;
    
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TemperatureConversionController : ControllerBase
    {
        private readonly ITemperatureConversionService _temperatureConversionService;

        public TemperatureConversionController(ITemperatureConversionService temperatureConversionService)
        {
            _temperatureConversionService = temperatureConversionService;
        }

        [HttpGet]
        public IActionResult ConvertCelsiusToFahrenheit(double temperature)
        {
            return Ok(_temperatureConversionService.ConvertCelsiusToFahrenheit(temperature));
        }

        [HttpGet]
        public IActionResult ConvertFahrenheitToCelsius(double temperature)
        {
            return Ok(_temperatureConversionService.ConvertFahrenheitToCelsius(temperature));
        }
    }
}
