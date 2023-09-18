using MongoDB.Bson.IO;
using MongoDbIntegration.Models;

namespace MongoDbIntegration.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Call the next middleware in the pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                // Handle the exception and return an ApiResponse with error information
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Perform your custom exception handling logic here
            // For example, logging the exception, returning a custom error response, etc.

            // Set the response status code and content type
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            // Create an ApiResponse with error information
            var apiResponse = ApiResponse<object>.Error(exception.Message);

            // Serialize the ApiResponse to JSON
            var jsonResponse = Newtonsoft.Json.JsonConvert.SerializeObject(apiResponse);

            // Write the JSON response to the response body
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
