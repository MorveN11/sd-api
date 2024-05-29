using Project.Core.Handlers;

namespace Project.Core.Exceptions.Business
{
    public class BusinessException : AbstractException
    {
        public BusinessException(string message, LogHandler logger)
            : base(message, Severity.Warning, logger) { }

        public override void LogMessage()
        {
            Logger.Log(Severity, FriendlyMessage);
        }
    }
}
