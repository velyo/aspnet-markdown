using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Velyo.AspNet.Markdown
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.LowercaseUrls = true;
            routes.EnableFriendlyUrls(settings);
        }
    }
}
