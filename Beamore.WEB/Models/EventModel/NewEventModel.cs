using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beamore.WEB.Models.EventModel
{
    public class NewEventModel
    {
        public string EventName { get; set; }

        public string EventEmail { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public DateTime StartTime { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Address { get; set; }
        

        public bool IsActive { get; set; }
    }
}