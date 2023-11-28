using GoldenAirport.Common;
using SendGrid.Helpers.Errors.Model;
using System.Net;
using System.Text.Json;

namespace GoldenAirport.WebAPI.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                ErrorResponse errorResponse = new() { Code = 117 };

                errorResponse.details = new List<DetailsResponse>
                            {
                               new DetailsResponse
                               {
                                    Key = string.Join(",eee", ex.Data),
                                    Value = string.Join(",rrrrr", ex.InnerException?.Message)
                               }
                            };
                if (ex.Message != null)
                {
                    errorResponse.Message = ex.Message;
                }
                else
                {
                    errorResponse.Message = ex.InnerException.Message;
                }
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(errorResponse.ConvertToJson());
            }
        }

        //private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        //{
        //    var code = HttpStatusCode.InternalServerError; // default to 500
        //    var message = exception.Message;
        //    switch (exception)
        //    {
        //        case NotFoundException _:
        //            code = HttpStatusCode.NotFound;
        //            break;
        //        case BadRequestException _:
        //            code = HttpStatusCode.BadRequest;
        //            break;
        //    }

        //    var result = JsonSerializer.Serialize(new { error = message });
        //    context.Response.ContentType = "application/json";
        //    context.Response.StatusCode = (int)code;
        //    return context.Response.WriteAsync(result);
        //}
    }
}
