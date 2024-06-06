using Project.Core.Handlers;

namespace Project.Core.Exceptions
{
    public abstract class AbstractException : Exception
    {
        public new Exception? InnerException { get; protected set; } = null;
        public string FriendlyMessage { get; protected set; }
        public Severity Severity { get; protected set; }
        protected LogHandler Logger { get; }

        protected AbstractException(string friendlyMessage, Severity severity, LogHandler logger)
        {
            FriendlyMessage = friendlyMessage;
            Severity = severity;
            Logger = logger;
        }

        protected AbstractException(
            Exception exception,
            string friendlyMessage,
            Severity severity,
            LogHandler logger
        )
            : this(friendlyMessage, severity, logger)
        {
            InnerException = exception;
        }

        public abstract void LogMessage();
    }
}
