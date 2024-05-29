using Project.Core.Handlers;

namespace Project.Core.Exceptions.Business
{
    public class BusinessException : AbstractException
    {
        public BusinessException(string message)
            : base(message, Severity.Warning) { }

        public override void LogMessage()
        {
            LogHandler.Instance.Log(Severity, FriendlyMessage);
        }
    }
}
