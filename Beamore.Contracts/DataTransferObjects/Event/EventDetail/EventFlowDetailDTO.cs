using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.Contracts.DataTransferObjects.Event.EventDetail
{
    class EventFlowDetailDTO
    {
        public int FlowId { get; set; }

        public string Header { get; set; }

        public string Explain { get; set; }

        public string Company { get; set; }
    }
}
