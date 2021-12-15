using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using DotNet.UnitTestingFrameworks.Common.APIModels;
using DotNet.UnitTestingFrameworks.BLL.IService;
using DotNet.UnitTestingFrameworks.API.Utils;

namespace DotNet.UnitTestingFrameworks.API
{
    public class GetUser
    {
        private readonly IGetUserService _service;

        public GetUser(IGetUserService service)
        {
            _service = service;
        }

        [FunctionName("GetUser")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] GetUserRequestModel request,
            ILogger log) => BLLDispatcher.Invoke(() => _service.GetUser(request), log, "GetUser");
    }
}
