namespace bellosoft.Domain.Entities
{
    public class ApiResponse<T>(int statusCode, string message, T? data = default)
    {
        public int StatusCode { get; set; } = statusCode;
        public string Message { get; set; } = message;
        public T? Data { get; set; } = data;
    }
}
