using Beamore.API.BusinessLogics.Notification;
using Beamore.API.BusinessLogics.UnitOfWorks;
using Beamore.API.Models;
using Beamore.Contracts.DataTransferObjects;
using Beamore.DAL.Contents.Models;
using Beamore.DAL.Repositories;
using Microsoft.Azure.NotificationHubs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Beamore.API.Controllers
{
    [RoutePrefix("api")]
    public class NotificationController : ApiController
    {
        SentNotificationRepo _sentNotificationRepo = new SentNotificationRepo();
       

        [HttpPost]
        [Authorize(Roles ="Manager")]
        [Route("notification")]
        
        public void Notificaiton(NotificationDTO model)
        {
            var xx = new NotificationModel
            {
                data = new Data
                {
                    message = model.EventId + "% " + model.Message
                }

            };
            SendNotificationAsync(xx);

            var mdl = new SentNotification
            {
                EventId = model.EventId,
                NotificationHeader = "Beamore",
                NotificationMessage = model.Message                
            };
            _sentNotificationRepo.add(mdl);
            _sentNotificationRepo.Save();

        }

        [HttpGet]
        [Authorize(Roles ="endUser, Manager")]
        [Route("getnotification")]
        public List<SentNotification> getNotification(int EventId)
        {
            var result = _sentNotificationRepo.FindByExxpression(p=>p.EventId == EventId);

            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async void SendNotificationAsync(NotificationModel msg)
        {
            var json = JsonConvert.SerializeObject(msg);
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString("key", "hubName");
            await hub.SendGcmNativeNotificationAsync(json);
        }
    }
}
