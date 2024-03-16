using System.Net;
using Application.Helpers;

namespace WebApi.Middlewares {
    public class ExceptionHandlingMiddleware {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware ( RequestDelegate next ) {
            _next = next;
        }

        public async Task Invoke( HttpContext context, IWebHostEnvironment env ) {
            
            try {
                await _next( context );
            } catch ( Exception exception ) {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var source = !string.IsNullOrEmpty(exception.Source) ? exception.Source : string.Empty;

                if ( env.IsDevelopment() ) {
                    var innerException = exception.InnerException != null ? exception.InnerException.Message : string.Empty;
                    var stackTrace = !string.IsNullOrEmpty(exception.StackTrace) ? exception.StackTrace.Replace("\r\n", Environment.NewLine).Trim() : string.Empty;
                    var htmlBody = MessageBuilder.BuildExceptionMessage( context, exception );
                    var response = ApiResnposeBuilder.GenerateInternalServerError(null, $"{source}-{exception.Message}", stackTrace);
                    await context.Response.WriteAsJsonAsync( response );
                } else {
                    var response = ApiResnposeBuilder.GenerateInternalServerError(null, $"{source}-{exception.Message}", null);
                    await context.Response.WriteAsJsonAsync( response );
                }
            }
        }
    }
}
