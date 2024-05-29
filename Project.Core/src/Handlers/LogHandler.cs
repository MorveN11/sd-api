using log4net;

namespace Project.Core.Handlers
{
    public class LogHandler
    {
        private readonly ILog _logger;
        private static LogHandler? instance;

        public static LogHandler Instance => instance ?? (instance = new LogHandler());

        private LogHandler()
        {
            _logger = LogManager.GetLogger(typeof(LogHandler));
        }

        public void Log(Severity severity, string message)
        {
            switch (severity)
            {
                case Severity.Debug:
                    _logger.Debug(message);
                    break;
                case Severity.Info:
                    _logger.Info(message);
                    break;
                case Severity.Warning:
                    _logger.Warn(message);
                    break;
                case Severity.Error:
                    _logger.Error(message);
                    break;
                case Severity.Fatal:
                    _logger.Fatal(message);
                    break;
            }
        }
    }
}
