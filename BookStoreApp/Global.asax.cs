using BookStoreApp.FIlters;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BookStoreApp
{
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {

            //GlobalFilters.Filters.Add(new LogActionFilters());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
