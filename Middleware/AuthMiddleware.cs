using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace heheshop.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.ToString().ToLower();

            var userRole = context.Session.GetString("Role");

            // Chặn truy cập /admin nếu không phải Admin
            if (path.StartsWith("/admin") && userRole != "Admin")
            {
                context.Response.Redirect("/account/login");
                return;
            }

            // Nếu cần chặn các trang cần login
            if (path.StartsWith("/order") && string.IsNullOrEmpty(userRole))
            {
                context.Response.Redirect("/account/login");
                return;
            }

            await _next(context);
        }
    }
}
