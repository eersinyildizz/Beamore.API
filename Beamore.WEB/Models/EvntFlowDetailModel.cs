using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beamore.WEB.Models
{
    public class EvntFlowDetailModel
    {
        public int EventId { get; set; }
        public int FlowId { get; set; }

        public string Header { get; set; }

        public string Explain { get; set; }

        public string Company { get; set; }
    }
}