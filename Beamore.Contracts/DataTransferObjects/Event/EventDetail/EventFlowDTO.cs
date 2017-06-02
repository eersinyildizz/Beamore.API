using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.Contracts.DataTransferObjects.Event
{
    public class EventFlowDTO

    {
        public int FlowId { get; set; }

        public string FlowTime { get; set; }

        public string FlowName { get; set; }

        public bool IsDone { get; set; }

        public string Header { get; set; }

        public string Explain { get; set; }

        public string CompanyName { get; set; }
    }
}
