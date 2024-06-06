using Project.Core.Handlers;

namespace Project.Core.Exceptions.Critical
{
    public class CriticalException : AbstractException
    {
        public CriticalException(Exception exception, LogHandler logger)
            : base(
                exception,
                "Something wrong happened. Please contact your system administrator.",
                Severity.Error,
                logger
            ) { }

        public override void LogMessage()
        {
            var current = InnerException;

            do
            {
                Logger.Log(Severity.Error, current?.Message ?? "");
                Logger.Log(Severity.Error, current?.StackTrace ?? "");
                current = current?.InnerException;
            } while (current != null);
        }
    }
}
