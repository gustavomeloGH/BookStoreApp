using BookStoreApp.RoutesConstraints;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace BookStoreApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var constaintsResolver = new DefaultInlineConstraintResolver();
            constaintsResolver.ConstraintMap.Add("values", typeof(ValuesConstraint));
            
            //routes.MapMvcAttributeRoutes(constaintsResolver);
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
