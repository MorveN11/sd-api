using Project.Core.Handlers;

namespace Project.Core.Exceptions.Business
{
    public class TestException : BusinessException
    {
        public TestException(LogHandler logger)
            : base("This is a test Exception", logger) { }
    }
}
