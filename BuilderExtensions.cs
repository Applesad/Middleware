namespace Middleware
{
    public static class BuilderExtensions
    {
        public static IApplicationBuilder UseCheckBrowserMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CheckBrowserMiddleware>();
        }
    }
}
