namespace Project.Core.Exceptions.Business
{
    public class TestException : BusinessException
    {
        public TestException()
            : base("This is a test Exception") { }
    }
}
