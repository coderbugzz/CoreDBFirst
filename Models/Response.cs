namespace CoreDBFirst.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string message { get; set; }
    }
}