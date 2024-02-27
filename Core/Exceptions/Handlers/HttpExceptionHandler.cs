using Core.Exceptions.Extensions;
using Core.Exceptions.HttpProblemDetails;
using Core.Exceptions.Types;
using Microsoft.AspNetCore.Http;

namespace Core.Exceptions.Handlers
{
    public class HttpExceptionHandler : ExceptionHandler
    {
        private HttpResponse? _response;
        public HttpResponse Response
        {
            get=> _response ?? throw new ArgumentException(nameof(_response));
            set => _response = value;
        }
        protected override Task HandlerException(BusinessException businessException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = new BusinessProblemDetails(businessException.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandlerException(ValidationException validationException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = new ValidationProblemDetails(validationException.Errors).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandlerException(AuthorizationException authorizationException)
        {
            Response.StatusCode = StatusCodes.Status401Unauthorized;
            string details = new AuthorizationProblemDetails(authorizationException.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandlerException(NotFoundException notFoundException)
        {
            Response.StatusCode = StatusCodes.Status404NotFound;
            string details = new NotfoundProblemDetails(notFoundException.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandlerException(Exception exception)
        {
            Response.StatusCode = StatusCodes.Status500InternalServerError;
            string details = new InternalServerProblemDetails(exception.Message).AsJson();
            return Response.WriteAsync(details);
        }
    }
}
