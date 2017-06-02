using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beamore.API.BusinessLogics.CO
{
    /// <summary>
    /// Validation Control result object.
    /// </summary>
    public class ValidationCO
    {
        public bool IsValid { get; set; }

        public string Message { get; set; }
    }
}