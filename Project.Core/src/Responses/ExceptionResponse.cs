namespace Project.Core.Responses
{
    public class ExceptionResponse
    {
        public List<string> errors { get; set; } = new List<string>();
        public int status { get; set; } = 0;
    }
}
