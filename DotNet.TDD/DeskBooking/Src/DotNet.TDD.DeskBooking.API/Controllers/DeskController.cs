using DotNet.TDD.DeskBooking.Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.TDD.DeskBooking.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeskController : ControllerBase
    {
        private readonly IDeskService _deskService;

        public DeskController(IDeskService deskService)
        {
            _deskService = deskService;
        }

        [HttpPost]
        public string Create(string name)
        {
            return _deskService.CreateDesk(name);
        }
    }
}
