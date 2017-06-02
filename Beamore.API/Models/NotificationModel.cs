using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beamore.API.Models
{
   
    public class Data
    {
        public string message { get; set; }
    }

    public class NotificationModel
    {
        public Data data { get; set; }
    }
}