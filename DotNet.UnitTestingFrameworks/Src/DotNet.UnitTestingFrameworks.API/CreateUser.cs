using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using DotNet.UnitTestingFrameworks.Common.APIModels;
using DotNet.UnitTestingFrameworks.BLL.IService;
using DotNet.UnitTestingFrameworks.API.Utils;

namespace DotNet.UnitTestingFrameworks.API
{
    public class CreateUser
    {
        private readonly ICreateUserService _service;

        public CreateUser(ICreateUserService service)
        {
            _service = service;
        }

        [FunctionName("CreateUser")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] CreateUserRequestModel request,
            ILogger log) => BLLDispatcher.Invoke(() => _service.CreateUser(request), log, "CreateUser");
    }
}
