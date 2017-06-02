using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.Contracts.DataTransferObjects.Event.EventDetail
{
    public class PortalEventReturnDTO
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public EventDetailForPortalDTO Events { get; set; }
    }
}
