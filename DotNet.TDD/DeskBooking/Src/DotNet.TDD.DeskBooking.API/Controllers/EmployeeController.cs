using DotNet.TDD.DeskBooking.API.Utils;
using DotNet.TDD.DeskBooking.Application.IService;
using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.TDD.DeskBooking.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult Add(EmployeeRequest request)
            => ApplicationDispatcher.Invoke(() => _employeeService.Add(request));

        [HttpDelete]
        public IActionResult Delete(long id)
            => ApplicationDispatcher.Invoke(() => _employeeService.Delete(id));

        [HttpGet]
        public IActionResult Get(long id)
            => ApplicationDispatcher.Invoke(() => _employeeService.Get(id));

        [HttpGet]
        public IActionResult GetAll()
            => ApplicationDispatcher.Invoke(() => _employeeService.GetAll());
    }
}
