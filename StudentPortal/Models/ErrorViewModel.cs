namespace StudentPortal.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public int ResponseCode { get; set; }
        public List<ErrorMessage> Errors { get; set; }

        
    }
    public class ErrorMessage
    {
        public string Code { get; init; }
        public string Message { get; init; }
        public ErrorMessage(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}