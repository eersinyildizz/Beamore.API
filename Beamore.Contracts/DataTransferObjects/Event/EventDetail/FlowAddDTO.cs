using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.Contracts.DataTransferObjects.Event.EventDetail
{
    public class FlowAddDTO
    {
        public int EventId { get; set; }

        public string FlowTime { get; set; }

        public string FlowName { get; set; }

        public bool IsDone { get; set; }
    }
}
