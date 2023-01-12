namespace Books.Models.Response
{
    public class DateResponse<T> : Response
    {
        public T? Data { get; set; }
    }
}
