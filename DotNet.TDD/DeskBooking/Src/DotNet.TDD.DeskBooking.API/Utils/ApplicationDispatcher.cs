using DotNet.TDD.DeskBooking.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.TDD.DeskBooking.API.Utils
{
    public static class ApplicationDispatcher
    {
        public static IActionResult Invoke<TResponse>(Func<TResponse> service)
        {
            try
            {
                var result = service();
                return new OkObjectResult(result);
            }
            catch (DataNotFoundException dataNotFoundException)
            {
                var errorMessage = dataNotFoundException.Message;
                return new NotFoundObjectResult(errorMessage);
            }
            catch (DuplicateDataException duplicateDataException)
            {
                var errorMessage = duplicateDataException.Message;
                return new UnprocessableEntityObjectResult(errorMessage);
            }
            catch (Exception exception)
            {
                var errorMessage = exception.GetBaseException().Message;
                return new ObjectResult(errorMessage) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}