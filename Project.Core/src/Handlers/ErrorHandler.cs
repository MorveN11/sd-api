using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Project.Core.Exceptions;
using Project.Core.Exceptions.Critical;

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

            var exception =
                (context.Exception is AbstractException)
                    ? context.Exception as AbstractException
                    : new CriticalException(context.Exception, _logger);

            exception?.LogMessage();

            context.Result = new ObjectResult(exception) { Value = exception?.FriendlyMessage };
            context.ExceptionHandled = true;
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
    }
}
