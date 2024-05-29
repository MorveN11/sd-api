using Project.Core.Exceptions;

namespace Project.Core.Handlers
{
    public class LogHandler
    {
        private readonly ILogger<AbstractException> _logger;
        private readonly Dictionary<Severity, Action<string>> _logMethods;

        public LogHandler(ILogger<AbstractException> logger)
        {
            _logger = logger;
            _logMethods = new Dictionary<Severity, Action<string>>
            {
                { Severity.Debug, msg => _logger.LogDebug(msg) },
                { Severity.Info, msg => _logger.LogInformation(msg) },
                { Severity.Warning, msg => _logger.LogWarning(msg) },
                { Severity.Error, msg => _logger.LogError(msg) },
                { Severity.Fatal, msg => _logger.LogCritical(msg) }
            };
        }

        public void Log(Severity severity, string message)
        {
            _logMethods[severity](message);
        }
    }
}
