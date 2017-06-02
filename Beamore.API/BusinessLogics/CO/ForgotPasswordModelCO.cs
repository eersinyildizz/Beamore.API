using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beamore.API.BusinessLogics.CO
{
    public class ForgotPasswordModelCO
    {
        public string Email { get; set; }

        public string GuidPassword { get; set; }

        public string Link { get; set; }
    }
}