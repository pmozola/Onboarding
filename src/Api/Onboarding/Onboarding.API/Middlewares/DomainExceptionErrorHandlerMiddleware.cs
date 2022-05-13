using System.Net;
using System.Text.Json;

using Onboarding.Domain.Base;

namespace Onboarding.API.Middlewares
{
    public class DomainExceptionErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public DomainExceptionErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var message = string.Empty;
                switch (error)
                {
                    case NotFoundException notFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        message = JsonSerializer.Serialize(new { 
                            message = notFoundException.Message,
                            errorCode = notFoundException.ErrorCode });
                        break;
                    case DomainException domainException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        message = JsonSerializer.Serialize(new { 
                            message = domainException.Message,
                            errorCode = domainException.ErrorCode });
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = message;
                await response.WriteAsync(result);
            }
        }
    }
}
