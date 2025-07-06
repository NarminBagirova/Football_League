namespace Football_League.WebAPI.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public ApiResponse()
        {
            Errors = new List<string>();
        }

        public ApiResponse(T data, string message = "", bool success = true)
        {
            Success = success;
            Data = data;
            Message = message;
            Errors = new List<string>();
        }

        public ApiResponse(string message, bool success = false)
        {
            Success = success;
            Message = message;
            Errors = new List<string>();
        }

        public ApiResponse(List<string> errors)
        {
            Success = false;
            Errors = errors;
            Message = "An error occurred.";
        }
    }
}
