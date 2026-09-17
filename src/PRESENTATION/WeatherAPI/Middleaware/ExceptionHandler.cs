namespace WeatherAPI.Middleaware
{
    public class ExceptionHandler(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (NotExistException ex)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;

                var response = Response<object>.Fail(
                    ex.Message,
                    StatusCodes.Status404NotFound);

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}