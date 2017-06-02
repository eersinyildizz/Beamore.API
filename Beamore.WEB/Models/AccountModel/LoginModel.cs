using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beamore.WEB.Models
{
    public class LoginModel
    {
        public string grant_type { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}