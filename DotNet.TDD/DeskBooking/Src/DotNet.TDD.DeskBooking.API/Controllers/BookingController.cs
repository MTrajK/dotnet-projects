using DotNet.TDD.DeskBooking.API.Utils;
using DotNet.TDD.DeskBooking.Application.IService;
using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.TDD.DeskBooking.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public IActionResult Add(BookingRequest request)
            => ApplicationDispatcher.Invoke(() => _bookingService.Add(request));

        [HttpDelete]
        public IActionResult Delete(long id)
            => ApplicationDispatcher.Invoke(() => _bookingService.Delete(id));

        [HttpGet]
        public IActionResult Get(long id)
            => ApplicationDispatcher.Invoke(() => _bookingService.Get(id));

        [HttpGet]
        public IActionResult GetAll()
            => ApplicationDispatcher.Invoke(() => _bookingService.GetAll());
    }
}
