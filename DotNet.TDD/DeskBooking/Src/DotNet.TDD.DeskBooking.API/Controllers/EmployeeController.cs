using DotNet.TDD.DeskBooking.Application.IService;
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
        public string Create(string name)
        {
            return _employeeService.CreateEmployee(name);
        }
    }
}
