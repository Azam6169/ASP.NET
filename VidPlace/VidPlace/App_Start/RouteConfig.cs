using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VidPlace
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            /*routes.MapRoute(
                name: "media-released",
                url: "medias/released/{year}/{month}",
                defaults: new { controller = "Medias", action = "released" },
                constraints: new {year = "2017|2018", month = "^(0?[1-9]|1[012])$" }
            );*/

            /*
            routes.MapRoute(
                name: "media-index",
                url: "medias/index/{pageIndex}/{sortBy}",
                defaults: new { controller = "Medias", action = "index" }
            );*/




            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home", 
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Default-test",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "test",
                    action = "getString",
                    id = UrlParameter.Optional
                }
            );


            
        }
    }
}
