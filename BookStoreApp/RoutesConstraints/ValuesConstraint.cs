using System;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace BookStoreApp.RoutesConstraints
{
    public class ValuesConstraint : IRouteConstraint
    {
        private readonly string[] validOptions;

        public ValuesConstraint(string options)
        {
            validOptions = options.Split('|');
        }

        public bool Match(HttpContextBase httpContext,
                          Route route,
                          string parameterName,
                          RouteValueDictionary values,
                          RouteDirection routeDirection)
        {

            if (values.TryGetValue(parameterName, out object value) && value != null)
            {
                return validOptions.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}