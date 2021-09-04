using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using RestaurantAPI.Exceptions;

namespace RestaurantAPI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public IActionResult Error()
        {
            var errorDetails = new ErrorDetails();
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            Exception exception = context.Error;

            switch (exception)
            {
                case BadRequestException:
                    {
                        errorDetails.Message = exception.Message;
                        errorDetails.StatusCode = (int)HttpStatusCode.BadRequest;

                        return BadRequest(errorDetails);
                    }
                case NotFoundException:
                    {
                        errorDetails.Message = exception.Message;
                        errorDetails.StatusCode = (int)HttpStatusCode.NotFound;

                        return NotFound(errorDetails);
                    }
                default:
                    {
                        return Problem(exception.Message, null, 500);
                    }
            }
        }
    }
}