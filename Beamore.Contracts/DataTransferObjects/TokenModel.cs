using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.Contracts.DataTransferObjects
{
    public class TokenModel
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public int expires_in { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        //    [JsonProperty(".issued")]
        //    public string issued { get; set; }

        //    [JsonProperty(".expires")]
        //    public string expires { get; set; }
        //
    }
}
