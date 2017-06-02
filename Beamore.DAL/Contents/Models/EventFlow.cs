using Beamore.DAL.Contents.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Contents.Models
{
    [Table("EventFlowTable")]
    public class EventFlow : BaseModel
    {
        //public EventFlow()
        //{
        //    this.EvenFlowDetails = new HashSet<EvenFlowDetail>();
        //}
        public string FlowTime { get; set; }

        public string FlowName { get; set; }

        public bool IsDone { get; set; } = false;

        public int SubEvent { get; set; } = 0;

        public int EventId { get; set; }

        public string Header { get; set; } = "No information";

        public string Explain { get; set; } = "No information";

        public string CompanyName { get; set; } = "No information";

        [ForeignKey("EventId")]
        public Event Event { get; set; }

        //public virtual ICollection<EvenFlowDetail> EvenFlowDetails { get; set; }

    }
}
