using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Project.Core.Exceptions;
using Project.Core.Exceptions.Business;
using Project.Core.Exceptions.Critical;
using Project.Core.Responses;

namespace Project.Core.Handlers
{
    public class ErrorHandler : IActionFilter
    {
        private readonly LogHandler _logger;

        public ErrorHandler(LogHandler logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                return;
            }

            var exception = context.Exception switch
            {
                AbstractException baseException => baseException,
                _ => new CriticalException(context.Exception, _logger)
            };

            var statusCode =
                exception.GetType().IsGenericType
                && exception.GetType().GetGenericTypeDefinition() == typeof(NotFoundException<>)
                    ? StatusCodes.Status404NotFound
                    : exception switch
                    {
                        DuplicateIdException _ => StatusCodes.Status409Conflict,
                        NotFoundException _ => StatusCodes.Status404NotFound,
                        CriticalException _ => StatusCodes.Status500InternalServerError,
                        _ => StatusCodes.Status400BadRequest
                    };

            exception.LogMessage();

            context.Result = new ObjectResult(
                new ExceptionResponse()
                {
                    errors = new List<string> { exception.FriendlyMessage },
                    status = statusCode
                }
            )
            {
                StatusCode = statusCode
            };
            context.ExceptionHandled = true;
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
    }
}
