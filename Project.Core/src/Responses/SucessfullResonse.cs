namespace Project.Core.Responses
{
    public class SucessfullResponse
    {
        public string message { get; set; }
        public int status { get; set; } = 200;

        public SucessfullResponse(string message)
        {
            this.message = message;
        }
    }

    public class SucessfullDataResponse<T> : SucessfullResponse
    {
        public T data { get; set; }

        public SucessfullDataResponse(T data, string message)
            : base(message)
        {
            this.data = data;
        }
    }
}
