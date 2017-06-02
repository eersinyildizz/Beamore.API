using Beamore.Contracts.DataTransferObjects;
using Beamore.Contracts.DataTransferObjects.Event;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Beamore.WEB.Service.HomeService
{
    public class ServiceClient
    {
        //private string ApiUrl = "http://localhost:62755";
        private string ApiUrl = "http://beamoreapi.azurewebsites.net";
        private HttpClient client = new HttpClient();
        private string token;

        public ServiceClient(string _token)
        {
            token = _token;
        }
        
        public async Task<UserDTO> GetUser()
        {
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            HttpResponseMessage req = await client.GetAsync(ApiUrl+"/api/user/userinfo");

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserDTO>(data);
            }

            return null;
        }

        public async Task<bool> NewEvent(NewEventDTO model)
        {
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

            HttpResponseMessage req = await client.PostAsync(ApiUrl + "/api/event/addnewevent", content);

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(data);
            }
            return false;
            
        }

        public async Task<List<EventDTO>> GetEvents()
        {
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            HttpResponseMessage req = await client.GetAsync(ApiUrl+"/api/event/myevent");

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<EventDTO>>(data);
            }

            return null;
        }

        public async Task<EventDTO> GetMyEventDetail(int id)
        {
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            HttpResponseMessage req = await client.GetAsync(ApiUrl + "/api/event/myeventdetail?EventId="+id);

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EventDTO>(data);
            }

            return null;
        }

        public async Task<int> GetNumberofParticipant(int EventId)
        {
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            HttpResponseMessage req = await client.GetAsync(ApiUrl + "/api/event/participantnumber?EventId=" + EventId);

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<int>(data);
            }
            // Default value
            return 0;
        }

    }
}