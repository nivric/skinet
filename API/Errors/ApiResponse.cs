namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int code, string message = null)
        {
            StatusCode = code;
            Message = message ?? GetMessageBasedOnCode(StatusCode);
        }

        private string GetMessageBasedOnCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad request",
                401 => "Not authorized",
                404 => "Not found",
                500 => "Internal Server Error",
                _ => null

            };
        }
    }
}
