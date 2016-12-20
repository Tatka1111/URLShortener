using System.Web;
using System.Web.Routing;

namespace URLShortener
{
    internal class ShortlinkRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext context)
        {
            return new ShortlinkHttpHandler(context.RouteData.Values);
        }
    }

    public class ShortlinkHttpHandler : IHttpHandler
    {
        RouteValueDictionary route;
        public ShortlinkHttpHandler(RouteValueDictionary _route)
        {
            route = _route;
        }
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            
            string shortUrlId = (string) route["action"];
            string fullURL = ShortlinkSQLWorker.SelectURL(shortUrlId);
            string mainPage = Global.BaseURL;

            if (shortUrlId.Length != 6)
            {
                context.Response.Redirect(mainPage);
                return;
            }

            if (fullURL.IndexOf("<ERROR>: ") == 0)
            {
                context.Response.Write(fullURL);
            } else
            {
                if (fullURL == "")
                {
                    context.Response.Redirect(mainPage);
                } else
                {
                    context.Response.Redirect(fullURL);
                }
            }
        }
    }
}