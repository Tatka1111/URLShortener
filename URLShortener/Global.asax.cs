
using System;
using System.Web.Routing;

namespace URLShortener
{
    public class Global : System.Web.HttpApplication
    {
        public static string BaseURL = ""; 

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteCollection routes = RouteTable.Routes;

            Route N = new Route("{action}", new ShortlinkRouteHandler());
            routes.Add(N);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}