using Project.Core.Handlers;

namespace Project.Core.Exceptions.Business
{
    public class DuplicateIdException : BusinessException
    {
        public DuplicateIdException(LogHandler logger)
            : base("The provided ID already exists in the database.", logger) { }
    }
}
