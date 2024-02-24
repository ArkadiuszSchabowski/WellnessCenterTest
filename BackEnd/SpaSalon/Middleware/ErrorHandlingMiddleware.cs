
using SpaSalon.Exceptions;

namespace SpaSalon.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                next.Invoke(context);
            }
            catch (BadRequestException e)
            {
                context.Response.StatusCode = 400;
                return e.Message;
            }
            catch (NotFoundException e)
            {
                context.Response.StatusCode = 404;
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
            }
        }
    }
}
