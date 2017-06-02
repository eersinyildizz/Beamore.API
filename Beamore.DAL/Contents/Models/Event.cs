using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Contents.Models
{
    [Table("EventTable")]
    public class Event : BaseModel
    {
        public Event()
        {
            this.EventDetails = new HashSet<EventDetail>();
            this.EventFlows = new HashSet<EventFlow>();
            this.EventSubcribers = new HashSet<EventSubcriber>();
            this.SentNotifications = new HashSet<SentNotification>();
            this.Beacons = new HashSet<Beacon>();
            this.BeaconChats = new HashSet<BeaconChat>();
        }

        [Required]
        public string EventName { get; set; }

        [Required]
        public string EventEmail { get; set; }

        [Required]
        public DateTime EventStartDate { get; set; }

        [Required]
        public DateTime EventFinishDate { get; set; }

        public DateTime EventStartTime { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;


        public string LogoUrl { get; set; }

        public int LocationId { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("LocationId")]
        public Location Location{ get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        public virtual ICollection<EventDetail> EventDetails { get; set; }

        public virtual ICollection<EventFlow> EventFlows { get; set; }

        public virtual ICollection<EventSubcriber> EventSubcribers { get; set; }

        public virtual ICollection<SentNotification> SentNotifications { get; set; }

        public virtual ICollection<Beacon> Beacons { get; set; }

        public virtual ICollection<BeaconChat> BeaconChats { get; set; }

    }
}
