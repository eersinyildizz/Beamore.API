using Beamore.Contracts.DataTransferObjects.Account;
using Beamore.WEB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Beamore.WEB.Service
{
    public class DataClient
    {
        //private string ApiUrl = "http://localhost:62755";
        private string ApiUrl = "http://beamoreapi.azurewebsites.net";
        public async Task<bool> UpdatePassword(ForgotPasswordModel model)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage req = await client.PostAsync(ApiUrl + "/api/user/updatepassword", content);

                if (req != null && req.IsSuccessStatusCode)
                {
                    var data = await req.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<bool>(data);
                }
                return false;
            }
        }


        public async Task<RegistrationResultDTO> Register(RegisterDTO model)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage req = await client.PostAsync(ApiUrl + "/api/user/register", content);


                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RegistrationResultDTO>(data);



            }
        }

        public async Task<ForgotPasswordResultDTO> ResetPassword(ForgotPasswordDTO model)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage req = await client.PostAsync(ApiUrl + "/api/user/forgotpassword", content);


                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ForgotPasswordResultDTO>(data);



            }
        }


        public async Task<TokenModel> Login(LoginModel model)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

                HttpResponseMessage req = await client.PostAsync(ApiUrl+"/token", new FormUrlEncodedContent(
                    new Dictionary<string, string>()
                    {
                    { "grant_type", model.grant_type },
                    { "Username", model.Email },
                    { "Password", model.Password }
                    }));

                if (req != null && req.IsSuccessStatusCode)
                {
                    var data = await req.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TokenModel>(data);
                }

                return null;
            }

        }


    }
}