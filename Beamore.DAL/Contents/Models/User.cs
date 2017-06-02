    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Contents.Models
{
    [Table("UserTable")]
    public class User : BaseModel
    {
        public User()
        {
            this.Events = new HashSet<Event>();
            this.Locations = new HashSet<Location>();
            this.EventSubcribers = new HashSet<EventSubcriber>();
            this.UserMobileDevices = new HashSet<UserMobileDevice>();
            this.Beacons = new HashSet<Beacon>();
            this.BeaconChats = new HashSet<BeaconChat>();
        }
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordSalt { get; set; }

        [Required]
        public string Role { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

        public virtual ICollection<EventSubcriber> EventSubcribers { get; set; }

        public virtual ICollection<UserMobileDevice> UserMobileDevices { get; set; }

        public virtual ICollection<Beacon> Beacons { get; set; }

        public virtual ICollection<BeaconChat> BeaconChats { get; set; }
    }
}
