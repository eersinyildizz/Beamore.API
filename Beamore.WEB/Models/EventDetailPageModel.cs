using Beamore.Contracts.DataTransferObjects;
using Beamore.Contracts.DataTransferObjects.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beamore.WEB.Models
{
    public class EventDetailPageModel
    {
        public EventDTO Event { get; set; }

        public List<EventFlowDTO> EventFlow { get; set; }

        public int NumberOfParticipant { get; set; }

        public int NotificationCount { get; set; }
    }
}