using Beamore.Contracts.DataTransferObjects.Event;
using Beamore.Contracts.DataTransferObjects.Event.EventDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beamore.API.BusinessLogics.UnitOfWorks
{
    public interface IPortalEventService
    {
        List<EventFlowDTO> GetMyEventDetail(string email, int EventID);
        
    }
}