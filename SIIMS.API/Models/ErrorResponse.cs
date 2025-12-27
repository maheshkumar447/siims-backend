namespace SIIMS.API.Models
{

    /// <summary>
    /// Standard error response returned by the API.
    /// Ensures consistent error structure across all endpoints.
    /// </summary>  
    public class ErrorResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
