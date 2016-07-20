using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopAdvisor
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index",
                    id = UrlParameter.Optional }
            );

            /*routes.MapRoute(
                name: "PlaceComments",
                url: "{controller}/{action}/{place}/{comment}",
                defaults: new
                {
                    controller = "Place",
                    action = "Index",
                    place = UrlParameter.Optional,
                    comment= UrlParameter.Optional
                }
            );*/
        }
    }
}
