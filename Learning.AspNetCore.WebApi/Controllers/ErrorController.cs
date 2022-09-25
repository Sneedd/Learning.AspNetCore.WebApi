
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Learning.AspNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {
        private IHostEnvironment _hostEnvironment;

        public ErrorController(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Get()
        {
            var exceptionHandler = this.HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (exceptionHandler != null && exceptionHandler.Error != null)
            {
                var exception = exceptionHandler.Error;
                return this.Problem(
                    detail: _hostEnvironment.IsDevelopment() ? exception.ToString() : exception.Message,
                    instance: null,
                    statusCode: 500,
                    title: "Unexpected error",
                    type: exception.GetType().Name
                );
            }
            return this.Ok();
        }
    }
}
