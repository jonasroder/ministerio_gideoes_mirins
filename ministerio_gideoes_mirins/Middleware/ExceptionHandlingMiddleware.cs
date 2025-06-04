using Core.SharedKernel.Exceptions;
using Infrastructure.SharedKernel.Logger;

namespace Infrastructure.SharedKernel.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            var logger = ctx.RequestServices
                            .GetRequiredService<BaseLogger<ExceptionHandlingMiddleware>>();

            try
            {
                await _next(ctx);
            }
            catch (DomainException dex)
            {
                logger.LogWarning($"Domain error ({dex.ErrorCode}): {dex.Message}");
                ctx.Response.StatusCode = 400;
                await ctx.Response.WriteAsJsonAsync(new { dex.ErrorCode, dex.Message });
            }
            catch (Exception ex)
            {
                logger.LogError($"Unhandled error: {ex.Message}");
                ctx.Response.StatusCode = 500;
            }
        }
    }


}
