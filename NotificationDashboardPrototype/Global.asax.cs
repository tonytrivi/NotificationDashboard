using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NotificationDashboardPrototype.Migrations;
using NotificationDashboardPrototype.Data;
using System.Data.Entity;

namespace NotificationDashboardPrototype
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //commented out because I don't want to seed the database all the time
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<NotificationModelContext, Configuration>());
        }
    }
}
