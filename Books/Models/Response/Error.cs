namespace Books.Models.Response
{
    public class Error
    {
        public Error(string message, string source)
        {
            Message= message;
            Source= source;
        }

        public string Message { get; set; }
        public string Source { get; set; }
    }
}