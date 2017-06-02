using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.Contracts.DataTransferObjects
{
    public class EventDTO
    {
        public int EventID { get; set; }

        public string EventName { get; set; }
        /// <summary>
        /// This email is creatimg automathicly Ex: iztech@beamore.tech
        /// </summary>
        public string EventEmail { get; set; }

        public DateTime EventDate { get; set; }

        public DateTime EventStartTime { get; set; }

        public string LogoUrl { get; set; }

        public LocationDTO Location { get; set; }
    }
}
