namespace EduFlow.Shared.Helpers
{
    using System.Collections.Generic;
    using System.Net;

    public class ApiResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<Validation>? Validations { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? Data { get; set; }
        public ApiResponse()
        {
            Success = false;
            Message = string.Empty;
        }

        public ApiResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public ApiResponse(List<Validation> validations, bool success)
        {
            Success = success;
            Validations = validations;
        }
        public ApiResponse(string data, string message, bool success) 
        {
            Data = data;
            Success= success;
            Message = message;
        }
    }

    public class Validation
    {
        public string? Field { get; set; }
        public string? Message { get; set; }

        public Validation(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }

}
