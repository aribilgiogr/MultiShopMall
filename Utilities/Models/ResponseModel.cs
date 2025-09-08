using Utilities.Constants;

namespace Utilities.Models
{
    public class ResponseModel
    {
        public int Code { get; set; } = 0;
        public ResponseTag Tag { get; set; } = ResponseTag.INFO;
        public required string Message { get; set; }
        public string? Detail { get; set; }
    }
}
