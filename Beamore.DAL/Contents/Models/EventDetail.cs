using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Contents.Models
{
    [Table("EventDetailTable")]
    public class EventDetail : BaseModel
    {
        public string EventExplanation { get; set; }

        public string Tag { get; set; }

        public int Participant { get; set; } = 0;

        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }
    }
}
