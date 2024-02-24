
using SpaSalon.Exceptions;

namespace SpaSalon.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BadRequestException e)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Bad request");
            }
            catch (NotFoundException e)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Not found");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Internal server error");
            }
        }
    }
}
