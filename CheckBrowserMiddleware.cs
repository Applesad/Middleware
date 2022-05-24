using UAParser;

namespace Middleware
{
    public class CheckBrowserMiddleware
    {
        private RequestDelegate _next;

        public CheckBrowserMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext context)
        {
            var Agent = context.Request.Headers.UserAgent;
            var Parser = UAParser.Parser.GetDefault();
            ClientInfo client = Parser.Parse(Agent);

            if (client.UA.Family == "Edge" || client.UA.Family == "IE" || client.UA.Family == "EdgeChromium")
            {
                context.Response.Redirect("https://www.mozilla.org/pl/firefox/new/");
            }
            await _next(context);
        }
    }
}
