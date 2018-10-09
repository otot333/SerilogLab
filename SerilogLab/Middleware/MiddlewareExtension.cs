using Microsoft.AspNetCore.Builder;

namespace SerilogLab.Middleware
{
    public static class MiddlewareExtensions
    {
        
        public static IApplicationBuilder UsePerformanceMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PerformanceMiddleware>();
        }
    }
}