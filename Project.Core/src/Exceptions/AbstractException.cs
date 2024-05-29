using Project.Core.Handlers;

namespace Project.Core.Exceptions
{
    public abstract class AbstractException : Exception
    {
        public new Exception? InnerException { get; protected set; } = null;
        public string FriendlyMessage { get; protected set; }
        public Severity Severity { get; protected set; }

        public AbstractException(string friendlyMessage, Severity severity)
        {
            FriendlyMessage = friendlyMessage;
            Severity = severity;
        }

        public AbstractException(Exception exception, string friendlyMessage, Severity severity)
            : this(friendlyMessage, severity)
        {
            InnerException = exception;
        }

        public abstract void LogMessage();
    }
}
