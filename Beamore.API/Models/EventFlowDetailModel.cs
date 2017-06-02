using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beamore.API.Models
{
    public class EventFlowDetailModel
    {
        public int EventId { get; set; }
        public int FlowId { get; set; }

        public string Header { get; set; }

        public string Explain { get; set; }

        public string Company { get; set; }
    }
}