using Beamore.Contracts.DataTransferObjects;
using Beamore.Contracts.DataTransferObjects.Event;
using Beamore.Contracts.DataTransferObjects.Event.EventDetail;
using Beamore.WEB.CustomAuthorize;
using Beamore.WEB.Helper;
using Beamore.WEB.Models;
using Beamore.WEB.Models.EventDetail;
using Beamore.WEB.Models.EventModel;
using Beamore.WEB.Service.HomeService;
using Beamore.WEB.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Beamore.WEB.Controllers
{
    [AuthorizationFilter]
    public class HomeController : Controller
    {
        // GET: Home

        private ImageService imageService = new ImageService();


        public async Task<ActionResult> Index()
        {
            ServiceClient service = new ServiceClient(Session["token"].ToString());
            var events = await service.GetEvents();
            return View(events);

        }

        public ActionResult NewEvent()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> NewEvent(NewEventModel model)
        {
            ServiceClient service = new ServiceClient(Session["token"].ToString());
            var logoUrl = await imageService.UploadImageAsync(Request.Files[0]);


            NewEventDTO evnt = new NewEventDTO
            {
                EventName = model.EventName,
                EventEmail = "eventname@beamore.tech",
                StartDate = model.StartDate,
                FinishDate = model.FinishDate,
                StartTime = model.StartTime,
                IsActive = !model.IsActive,
                Locaiton = new LocationDTO
                {
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    Address = model.Address
                },
                LogoUrl = logoUrl.ToString()
            };

            bool result = await service.NewEvent(evnt);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.error = "Error. Please try again ...";
            return View();
        }

        public async Task<ActionResult> EventDetail(int id)
        {
            if (id > 0)
            {
                PortalServiceClient service = new PortalServiceClient(Session["token"].ToString());
                ServiceClient service2 = new ServiceClient(Session["token"].ToString());
                ServiceClient service3 = new ServiceClient(Session["token"].ToString());
                PortalServiceClient service4 = new PortalServiceClient(Session["token"].ToString());
                var events = await service2.GetMyEventDetail(id);
                int numberofParticipant = await service3.GetNumberofParticipant(id);
                var result =await  service.GetEventDetail(id);
                var noti = await service4.GetNotification(id);
                EventDetailPageModel returnModel = new EventDetailPageModel
                {
                    NotificationCount = noti.Count,
                    Event = events,
                    EventFlow = result,
                    NumberOfParticipant = numberofParticipant
                };


                return View(returnModel);
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<ActionResult> FlowAdd(EventFlowModel model)
        {
            PortalServiceClient portalService = new PortalServiceClient(Session["token"].ToString());

            List<FlowAddDTO> flow = new List<FlowAddDTO>();
            for (int a = 0; a < model.Flow.Length; a++)
            {
                FlowAddDTO fl = new FlowAddDTO();

                fl.EventId = model.EventId;
                fl.FlowName = model.Flow[a];
                if (a == 0)
                {
                    fl.FlowTime = "8 AM";
                }
                else if (a == 1)
                {
                    fl.FlowTime = "9 AM";
                }
                else if (a == 2)
                {
                    fl.FlowTime = "10 AM";
                }
                else if (a == 3)
                {
                    fl.FlowTime = "11 AM";
                }
                else if (a == 4)
                {
                    fl.FlowTime = "12 AM";
                }
                else if (a == 5)
                {
                    fl.FlowTime = "1 PM";
                }
                else if (a == 6)
                {
                    fl.FlowTime = "2 PM";
                }
                else if (a == 7)
                {
                    fl.FlowTime = "3 PM";
                }
                else if (a == 8)
                {
                    fl.FlowTime = "4 PM";
                }
                else if (a == 9)
                {
                    fl.FlowTime = "5 PM";
                }
                else if (a == 10)
                {
                    fl.FlowTime = "6 PM";
                }
                else
                {
                    fl.FlowTime = "7 PM";
                }
                fl.IsDone = false;
                flow.Add(fl);
            }
            bool result = await portalService.AddFlow(flow);
            
            return RedirectToAction("EventDetail", "Home", new { id = model.EventId });
        }

        [HttpPost]
        public async Task<ActionResult> FlowDetailAdd(EvntFlowDetailModel model)
        {
          PortalServiceClient service = new PortalServiceClient(Session["token"].ToString());
            var result = await service.AddFlowDetail(model);
            return RedirectToAction("EventDetail", "Home", new { id = model.EventId });
        }
        public ActionResult Logout()
        {
            Session.Remove("token");
            Session.Abandon();
            Response.Cookies.Clear();
            return RedirectToAction("Login", "Account");
        }

        public async Task<ActionResult> SendNotification(NotificationDTO model)
        {
            PortalServiceClient service = new PortalServiceClient(Session["token"].ToString());
            await service.SentNotificaiton(model);
            return RedirectToAction("EventDetail", "Home", new { id = model.EventId });
        }

        public async Task<ActionResult> GetNotification(int id)
        {
            PortalServiceClient service = new PortalServiceClient(Session["token"].ToString());
            var mdl = await service.GetNotification(id);
            return RedirectToAction("EventDetail", "Home");
        }
    }
}