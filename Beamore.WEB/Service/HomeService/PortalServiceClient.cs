using Beamore.Contracts.DataTransferObjects;
using Beamore.Contracts.DataTransferObjects.Event;
using Beamore.Contracts.DataTransferObjects.Event.EventDetail;
using Beamore.WEB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Beamore.WEB.Service.HomeService
{
    public class PortalServiceClient
    {
        //private string ApiUrl = "http://localhost:62755";
        private string ApiUrl = "http://beamoreapi.azurewebsites.net";
        private HttpClient client = new HttpClient();
        private string token;
        public PortalServiceClient(string _token)
        {
            token = _token;
        }

        public async Task<bool> AddFlow(List<FlowAddDTO> model)
        {
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

            HttpResponseMessage req = await client.PostAsync(ApiUrl + "/api/portal/addflow", content);

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(data);
            }
            return false;

        }

        public async Task<List<EventFlowDTO>> GetEventDetail(int id)
        {
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            HttpResponseMessage req = await client.GetAsync(ApiUrl+"/api/portal/myeventdetail?EventId="+id);

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<EventFlowDTO>>(data);
            }

            return null;
        }


        public async Task<bool> AddFlowDetail(EvntFlowDetailModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

            HttpResponseMessage req = await client.PostAsync(ApiUrl + "/api/portal/addflowdetail", content);

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(data);
            }
            return false;

        }

        public async Task<bool> SentNotificaiton(NotificationDTO model)
        {
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

            HttpResponseMessage req = await client.PostAsync(ApiUrl + "/api/notification", content);

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(data);
            }
            return false;

        }

        public async Task<List<NotificationReturnDTO>> GetNotification(int id)
        {
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            HttpResponseMessage req = await client.GetAsync(ApiUrl + "/api/getnotification?EventId=" + id);

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<NotificationReturnDTO>>(data);
            }

            return null;
        }


    }
}