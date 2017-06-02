using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beamore.WEB.Helper
{
    public class SessionHelper 
    {
        private HttpContextBase Context { get; set; }
        public SessionHelper(HttpContextBase context)
        {
            this.Context = context;
        }
        public bool SessionControl()
        {
            if (this.Context.Session["token"] != null)
            {
                return true;
            }
            return false;
        }
    }
}