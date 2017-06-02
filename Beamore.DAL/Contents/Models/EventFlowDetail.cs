using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Contents.Models
{
    [Table("EventFlowDetailTable")]
    public class EvenFlowDetail : BaseModel
    {
        public string Header { get; set; }

        public string Explain { get; set; }

        public string CompanyName { get; set; } = "Beamore";

        public int EventFlowId { get; set; }

        [ForeignKey("EventFlowId")]
        public EventFlow EventFlow { get; set; }
    }
}
