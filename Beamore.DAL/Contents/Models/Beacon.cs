using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Contents.Models
{
    [Table("BeaconTable")]
    public class Beacon : BaseModel
    {
        public Beacon()
        {
            this.BeaconNotes = new HashSet<BeaconNote>();
            this.BeaconChats = new HashSet<BeaconChat>();
        }
        public string BeaconUniqueId { get; set; }

        public string Password { get; set; }

        public DateTime UsedDate { get; set; } = DateTime.UtcNow;

        public bool IsUsed { get; set; } = false;

        public int UserId { get; set; }

        public int EventId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }

        public virtual ICollection<BeaconNote> BeaconNotes { get; set; }

        public virtual ICollection<BeaconChat> BeaconChats { get; set; }

    }
}
