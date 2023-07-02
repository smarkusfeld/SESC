namespace IdentityService.Models
{
    /// <summary>
    /// Returns the response value after user registration and login
    /// <br>Contains error details if request fails</br>
    /// </summary>
    public class Response
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
    }
}
