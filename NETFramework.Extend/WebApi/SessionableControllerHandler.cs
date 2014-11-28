using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace NETFramework.Extend.WebApi
{
    public class SessionableControllerHandler : HttpControllerHandler, IRequiresSessionState
    {
        public SessionableControllerHandler(RouteData routeData) : base(routeData)
        {
        }

        public SessionableControllerHandler(RouteData routeData, HttpMessageHandler handler) : base(routeData, handler)
        {
        }
    }
}
