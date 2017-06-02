using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Contents.Models
{
    [Table("EventSubcriberTable")]
    public class EventSubcriber : BaseModel
    {
        public int EventId { get; set; }

        public int UserId { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey("EventId")]
        public Event Event { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
