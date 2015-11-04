namespace Bookmarks.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("BookmarksIndex", "Bookmarks/Index/{page}", new { controller = "Bookmarks", action = "Index", page = UrlParameter.Optional });
            routes.MapRoute("BookmarkDetails", "Bookmarks/Details/{title}", new { controller = "Bookmarks", action = "Details", title = UrlParameter.Optional });

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
