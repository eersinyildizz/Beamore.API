using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.Contracts.DataTransferObjects.Event
{
    public class NewEventDTO
    {
        public string EventName { get; set; }

        public string EventEmail { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public DateTime StartTime { get; set; }

        public LocationDTO Locaiton { get; set; }

        public string LogoUrl { get; set; }

        public bool IsActive { get; set; }
    }
}
