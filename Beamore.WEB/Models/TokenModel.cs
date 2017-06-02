using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beamore.WEB.Models
{
    public class TokenModel
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public int expires_in { get; set; }

        [JsonProperty(".issued")]
        public string issued { get; set; }

        [JsonProperty(".expires")]
        public string expires { get; set; }

    }
}