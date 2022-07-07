namespace DotNet.IntegrationTesting.Demo2.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using DotNet.IntegrationTesting.Demo2.Application.IService;

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AnimalsFactsController : Controller
    {
        private readonly ICatFactsService _catFactsService;

        private const string _errorMessage = "The cat facts API is not available at the moment, please try later.";

        public AnimalsFactsController(ICatFactsService catFactsService)
        {
            _catFactsService = catFactsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRandomCatFact(int maxLength)
        {
            var result = await _catFactsService.GetRandomCatFact(maxLength);
            
            if (result != null)
                return Ok(result);
            else 
                return BadRequest(_errorMessage);
        }
    }
}
