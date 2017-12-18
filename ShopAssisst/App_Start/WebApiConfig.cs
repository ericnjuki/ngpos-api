using Microsoft.Web.Http.Routing;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace ShopAssisst2 {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Web API configuration and services
            var constraintResolver = new DefaultInlineConstraintResolver() {
                ConstraintMap =
                {
                    ["apiVersion"] = typeof( ApiVersionRouteConstraint )
                }
            };

            //Enabling cors
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/v{version:apiVersion}/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );
        }
    }
}