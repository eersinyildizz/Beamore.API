using Beamore.Contracts.DataTransferObjects;
using Beamore.Contracts.DataTransferObjects.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beamore.API.BusinessLogics.UnitOfWorks
{
    public interface IEventService
    {
        bool CreateNewEvent(NewEventDTO evnt, string email);

        List<EventDTO> getAllEvents();

        EventReturnDTO SubscribeEvent(string email, int eventID);

        EventDTO getMyEventForOne(int id, string email);
    }
}