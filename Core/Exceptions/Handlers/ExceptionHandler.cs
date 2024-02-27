using Core.Exceptions.Types;

namespace Core.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandlerExceptionAsync(Exception exception) =>
        exception switch
        {
            BusinessException businessException => HandlerException(businessException),
            ValidationException validationException => HandlerException(validationException),
            AuthorizationException authorizationException => HandlerException(authorizationException),
            NotFoundException notFoundException => HandlerException(notFoundException),
            _ => HandlerException(exception)
        };

    protected abstract Task HandlerException(BusinessException businessException);
    protected abstract Task HandlerException(ValidationException validationException);
    protected abstract Task HandlerException(AuthorizationException authorizationException);
    protected abstract Task HandlerException(NotFoundException notFoundException);
    protected abstract Task HandlerException(Exception exception);
}
