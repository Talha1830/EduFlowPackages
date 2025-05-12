using Microsoft.AspNetCore.Http;

namespace EduFlow.Shared.Extensions
{
    public static class HttpResponseExtensions
    {
        public static void AddCustomHeader(this HttpResponse response, string headerName, string headerValue)
        {
            if (!response.Headers.ContainsKey(headerName))
            {
                response.Headers.Add(headerName, headerValue);
            }
        }
    }

}