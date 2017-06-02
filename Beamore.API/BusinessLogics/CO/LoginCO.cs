using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beamore.API.BusinessLogics.CO
{
    public class LoginCO
    {
        public string UserEmail { get; set; }

        public string Role { get; set; }

        public bool Status { get; set; }
    }
}