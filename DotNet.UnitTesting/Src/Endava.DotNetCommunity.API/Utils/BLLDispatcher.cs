using Endava.DotNetCommunity.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Endava.DotNetCommunity.API.Utils
{
    public static class BLLDispatcher
    {
        public static IActionResult Invoke<TResponse>(Func<TResponse> service, ILogger logger, string functionName)
        {
            try
            {
                logger.LogInformation("{FunctionName} function processing a request.", functionName);
                var result = service();
                logger.LogInformation("{FunctionName} function successfully processed the request.", functionName);
                return new OkObjectResult(result);
            }
            catch (NotFoundOperationException notFoundOperationException)
            {
                var errorMessage = notFoundOperationException.Message;
                logger.LogError(functionName, "Failed to execute {FunctionName}. Error: {Error}",
                    functionName, errorMessage);
                return new UnprocessableEntityObjectResult(errorMessage);
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                var errorMessage = fileNotFoundException.Message;
                logger.LogError(fileNotFoundException, "Failed to execute {FunctionName}. Error: {Error}",
                    functionName, errorMessage);
                return new NotFoundObjectResult(errorMessage);
            }
            catch (Exception exception)
            {
                var errorMessage = exception.GetBaseException().Message;
                logger.LogError(exception, "Failed to execute {FunctionName}. Error: {Error}",
                    functionName, errorMessage);
                return new ObjectResult(errorMessage) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
