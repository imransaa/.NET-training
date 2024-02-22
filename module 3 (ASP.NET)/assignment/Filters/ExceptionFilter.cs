using assignment.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace assignment.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var error = new ErrorModel(
                    500,
                    context.Exception.Message,
                    context.Exception.StackTrace
                );

            context.Result = new JsonResult( error );
        }
    }
}
