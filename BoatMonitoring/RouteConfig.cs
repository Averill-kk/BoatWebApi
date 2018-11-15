using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatMonitoring
{
    public class RouteConfig
    {
        routes.MapRoute(
        name: "Home",
        url: "",
        defaults: new { controller = "Home", action = "Index" }
    );

    routes.MapRoute(
        name: "Map",
        url:  "map",
        defaults: new { controller = "Map", action = "Index" }
    );
    }
}
