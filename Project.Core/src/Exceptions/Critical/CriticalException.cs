using Project.Core.Handlers;

namespace Project.Core.Exceptions.Critical
{
    public class CriticalException : AbstractException
    {
        public CriticalException(Exception exception)
            : base(
                exception,
                "Something wrong happened. Please contact your system administrator",
                Severity.Error
            ) { }

        public override void LogMessage()
        {
            var current = InnerException;

            do
            {
                LogHandler.Instance.Log(Severity.Error, current?.Message ?? "");
                LogHandler.Instance.Log(Severity.Error, current?.StackTrace ?? "");
                current = current?.InnerException;
            } while (current != null);
        }
    }
}
