using Beamore.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Transactions;

namespace Beamore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void initialize()
        {
            
        }

        //[TestMethod]
        //public async Task TestAccestokenExists()
        //{
        //    HttpClient client = new HttpClient();
           
        //        var user = new UserAccountDTO {
        //            Username = "ersinyildiz@gmail.com",
        //            Password = "123"
        //        };

        //        var json = JsonConvert.SerializeObject(user);
        //        HttpContent content = new StringContent(json);
        //        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

        //        HttpResponseMessage req = await client.PostAsync("http://localhost:62755/token", new FormUrlEncodedContent(
        //            new Dictionary<string, string>()
        //            {
        //            { "grant_type", "password" },
        //            { "Username", user.Username },
        //            { "Password", user.Password }
        //            }));
        //        Assert.IsNotNull(req);
        //        Assert.IsTrue(req.IsSuccessStatusCode);
        //        var data = await req.Content.ReadAsStringAsync();
        //        var token = JsonConvert.DeserializeObject<TokenModel>(data);
        //        Assert.IsNotNull(token.access_token);
            
        //}
    }
}
