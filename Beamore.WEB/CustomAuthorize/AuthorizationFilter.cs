using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Beamore.WEB.CustomAuthorize
{
    public class AuthorizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            if (session["token"] != null)
                return;

            //Redirect him to somewhere.
            var redirectTarget = new RouteValueDictionary
             {{"action", "Login"}, {"controller", "Account"}};
            filterContext.Result = new RedirectToRouteResult(redirectTarget);
        }
    }
}