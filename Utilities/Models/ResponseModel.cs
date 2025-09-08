using Utilities.Constants;

namespace Utilities.Models
{
    public class ResponseModel<T>
    {
        public int Code { get; set; } = 0;
        public ResponseTag Tag { get; set; } = ResponseTag.INFO;
        public required string Message { get; set; }
        public string? Detail { get; set; }
        public T? Data { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public static ResponseModel<T> Success(T data, string message = "Success") => new() { Message = message, Data = data };

        public static ResponseModel<T> Error(string message, string? detail = null, int code = -1)
            => new() { Code = code, Tag = ResponseTag.ERROR, Message = message, Detail = detail };
    }
}
