using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.Contracts.DataTransferObjects.Event.EventDetail
{
    public class EventDetailForPortalDTO
    {
        public NewEventDTO Event { get; set; }

        public List<EventFlowDTO> EventFlow{ get; set; }
    }   
}
