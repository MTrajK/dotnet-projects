using DotNet.TDD.DeskBooking.API.Utils;
using DotNet.TDD.DeskBooking.Application.IService;
using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;
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
        public IActionResult Add(DeskRequest request)
            => ApplicationDispatcher.Invoke(() => _deskService.Add(request));

        [HttpDelete]
        public IActionResult Delete(long id)
            => ApplicationDispatcher.Invoke(() => _deskService.Delete(id));

        [HttpGet]
        public IActionResult Get(long id)
            => ApplicationDispatcher.Invoke(() => _deskService.Get(id));

        [HttpGet]
        public IActionResult GetAll()
            => ApplicationDispatcher.Invoke(() => _deskService.GetAll());
    }
}
