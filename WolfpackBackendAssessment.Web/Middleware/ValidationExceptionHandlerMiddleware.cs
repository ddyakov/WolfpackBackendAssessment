namespace WolfpackBackendAssessment.Web.Middleware
{
	using System;
	using System.Net;
	using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Builder;

	using Newtonsoft.Json;
	using Newtonsoft.Json.Serialization;

    using Domain.Exceptions;
    using Application.Exceptions;

	public class ValidationExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationExceptionHandlerMiddleware(RequestDelegate next)
            => _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = string.Empty;

            switch (exception)
            {
                case ModelValidationException modelValidationException:
                    code = HttpStatusCode.BadRequest;
                    result = SerializeObject(new
                    {
                        ValidationDetails = true,
                        modelValidationException.Errors
                    });
                    break;
                case NullReferenceException _:
                    code = HttpStatusCode.BadRequest;
                    result = SerializeObject(new[] { "Invalid request." });
                    break;
                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (string.IsNullOrEmpty(result))
            {
                var error = exception.Message;

                if (exception is BaseDomainException baseDomainException)
                    error = baseDomainException.Error;

                result = SerializeObject(new[] { error });
            }

            return context.Response.WriteAsync(result);
        }

        private static string SerializeObject(object obj)
            => JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy(true, true)
                }
            });
    }

    public static class ValidationExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidationExceptionHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware<ValidationExceptionHandlerMiddleware>();
    }
}
