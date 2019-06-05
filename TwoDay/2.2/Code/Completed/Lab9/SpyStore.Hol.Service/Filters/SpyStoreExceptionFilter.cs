using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Dal.Exceptions;

namespace SpyStore.Hol.Service.Filters
{
    public class SpyStoreExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public SpyStoreExceptionFilter(
            IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public override void OnException(ExceptionContext context)
        {
            bool isDevelopment = _hostingEnvironment.IsDevelopment();
            var ex = context.Exception;
            string stackTrace = (isDevelopment) ? context.Exception.StackTrace : string.Empty;
            string message = ex.Message;
            string error = string.Empty;
            IActionResult actionResult;
            switch (ex)
            {
                case SpyStoreInvalidQuantityException iqe:
                    //Returns a 400
                    error = "Invalid quantity request.";
                    actionResult = new BadRequestObjectResult(new { Error = error, Message = message, StackTrace = stackTrace });
                    break;
                case DbUpdateConcurrencyException ce:
                    //Returns a 400
                    error = "Concurrency Issue.";
                    actionResult = new BadRequestObjectResult(new { Error = error, Message = message, StackTrace = stackTrace });
                    break;
                case SpyStoreInvalidProductException ipe:
                    //Returns a 400
                    error = "Invalid Product Id.";
                    actionResult = new BadRequestObjectResult(new { Error = error, Message = message, StackTrace = stackTrace });
                    break;
                case SpyStoreInvalidCustomerException ice:
                    //Returns a 400
                    error = "Invalid Customer Id.";
                    actionResult = new BadRequestObjectResult(new { Error = error, Message = message, StackTrace = stackTrace });
                    break;
                default:
                    error = "General Error.";
                    actionResult = new ObjectResult(new { Error = error, Message = message, StackTrace = stackTrace })
                    {
                        StatusCode = 500
                    };
                    break;
            }
            //context.ExceptionHandled = true;
            context.Result = actionResult;
        }
    }
}
