using Beamore.API.BusinessLogics.UnitOfWorks;
using Beamore.Contracts.DataTransferObjects;
using Beamore.Contracts.DataTransferObjects.Event;
using Beamore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Beamore.API.Controllers
{
    [RoutePrefix("api/event")]
    public class EventController : ApiController
    {
        [HttpPost]
        [Route("addnewevent")]
        [Authorize(Roles = "Manager")]
        public bool CreateNewEvent(NewEventDTO evnt)
        {
            EventService events = new EventService(new EventRepo(), new LocationRepo(), new UserRepo(), new EventSubcriberRepo());
            bool result = events.CreateNewEvent(evnt, this.User.Identity.Name);
            return result;
        }

        [HttpGet]
        [Route("events")]
        [Authorize(Roles = ("endUser"))]
        public List<EventDTO> GetAllEvent()
        {
            EventService events = new EventService(new EventRepo(), new LocationRepo(), new UserRepo(), new EventSubcriberRepo());
            return events.getAllEvents();
        }

        [HttpGet]
        [Route("myevent")]
        [Authorize(Roles = ("Manager"))]
        public List<EventDTO> GetEvent()
        {
            System.Diagnostics.Trace.TraceInformation("IP :" + HttpContext.Current.Request.UserHostAddress);
            EventService events = new EventService(new EventRepo(), new LocationRepo(), new UserRepo(), new EventSubcriberRepo());
            return events.getMyEvent(this.User.Identity.Name);
        }

        [HttpGet]
        [Route("myeventdetail")]
        [Authorize(Roles = ("Manager"))]
        public EventDTO GetMyEvent(int EventId)
        {
            System.Diagnostics.Trace.TraceInformation("IP :" + HttpContext.Current.Request.UserHostAddress);
            EventService events = new EventService(new EventRepo(), new LocationRepo(), new UserRepo(), new EventSubcriberRepo());
            return events.getMyEventForOne(EventId,this.User.Identity.Name);
        }

        [HttpGet]
        [Route("myuserevent")]
        [Authorize(Roles = ("endUser"))]
        public List<EventDTO> GetUserEvent()
        {

            System.Diagnostics.Trace.TraceInformation("IP :"+ HttpContext.Current.Request.UserHostAddress);
            EventService events = new EventService(new EventRepo(), new LocationRepo(), new UserRepo(), new EventSubcriberRepo());
            return events.GetUserEvent(this.User.Identity.Name);
        }

        [HttpPost]
        [Route("subscribetoevent")]
        [Authorize(Roles = ("endUser"))]
        public EventReturnDTO SubscribeEvent(EventSubscribeDTO model)
        {
            EventService events = new EventService(new EventRepo(), new LocationRepo(), new UserRepo(), new EventSubcriberRepo());
            return events.SubscribeEvent(this.User.Identity.Name, model.EventId);
        }

        [HttpPost]
        [Route("unsubscribetoevent")]
        [Authorize(Roles = ("endUser"))]
        public EventReturnDTO UnSubscribeEvent(EventSubscribeDTO model)
        {
            EventService events = new EventService(new EventRepo(), new LocationRepo(), new UserRepo(), new EventSubcriberRepo());
            return events.UnSubscribeEvent(this.User.Identity.Name, model.EventId);
        }

        [HttpGet]
        [Route("participantnumber")]
        [Authorize(Roles = ("endUser, Manager"))]
        public int GetParticipantNumber(int EventId)
        {

            System.Diagnostics.Trace.TraceInformation("IP :" + HttpContext.Current.Request.UserHostAddress);
            EventService events = new EventService(new EventRepo(), new LocationRepo(), new UserRepo(), new EventSubcriberRepo());
            return events.ParticipantNumber(this.User.Identity.Name, EventId);
        }



        ///SILINECEK
        ///
        [HttpGet]
        [Route("allevent")]
        public List<EventDTO> GetAllEventForChatbot()
        {
            EventService events = new EventService(new EventRepo(), new LocationRepo(), new UserRepo(), new EventSubcriberRepo());
            return events.GetAllEventForChatbot();
        }



    }
}
