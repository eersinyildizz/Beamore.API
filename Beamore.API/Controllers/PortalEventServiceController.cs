using Beamore.API.BusinessLogics.UnitOfWorks;
using Beamore.API.Models;
using Beamore.Contracts.DataTransferObjects.Event;
using Beamore.Contracts.DataTransferObjects.Event.EventDetail;
using Beamore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Beamore.API.Controllers
{
    [RoutePrefix("api/portal")]
    public class PortalEventServiceController : ApiController
    {
        [HttpGet]
        [Route("myeventdetail")]
        [Authorize(Roles = "Manager")]
        public List<EventFlowDTO> getMyEventDetail(int EventId)
        {
            PortalEventService events = new PortalEventService(new UserRepo(), new EventRepo(), new LocationRepo(), new EventFlowRepo());
            List<EventFlowDTO> result = events.GetMyEventDetail(this.User.Identity.Name, EventId);
            return result;
        }

        [HttpGet]
        [Route("eventdetail")]
        [Authorize(Roles = "endUser")]
        public List<EventFlowDTO> GetMyEventDetailForendUser(int EventId)
        {
            PortalEventService events = new PortalEventService(new UserRepo(), new EventRepo(), new LocationRepo(), new EventFlowRepo());
            List<EventFlowDTO> result = events.GetMyEventDetailForendUser(this.User.Identity.Name, EventId);
            return result;
        }

        [HttpPost]
        [Route("addflow")]
        [Authorize(Roles = "Manager")]
        public bool AddFlow(List<FlowAddDTO> flows)
        {
            PortalEventService events = new PortalEventService(new UserRepo(), new EventRepo(), new LocationRepo(), new EventFlowRepo());
            bool result = events.AddEventFlow(this.User.Identity.Name, flows);
            return result;
        }

        [HttpPost]
        [Route("addflowdetail")]
        [Authorize(Roles = "Manager")]
        public bool AddEventFlowDetail(EventFlowDetailModel flows)
        {
            PortalEventService events = new PortalEventService(new UserRepo(), new EventRepo(), new LocationRepo(), new EventFlowRepo());
            bool result = events.AddEventFlowDetail(this.User.Identity.Name, flows);
            return result;
        }


        ///SILINECEK
        ///Chotbot için ooluşturuldu
        ///
        [HttpGet]
        [Route("eventdetailforbot")]
        public List<EventFlowDTO> GetMyEventDetailForBot(int EventId)
        {
            PortalEventService events = new PortalEventService(new UserRepo(), new EventRepo(), new LocationRepo(), new EventFlowRepo());
            List<EventFlowDTO> result = events.GetMyEventDetailForBot(EventId);
            return result;
        }
    }
}