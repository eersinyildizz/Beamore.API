using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beamore.API.BusinessLogics.CO
{
    public class EncryptionModelCO
    {
        public string Password { get; set; }

        public string Salt { get; set; }
    }
}