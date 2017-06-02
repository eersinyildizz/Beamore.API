using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Contents.Models
{
    [Table("BeaconChatTable")]
    public class BeaconChat : BaseModel
    {
        /// <summary>
        /// İf result is 1 then it means message sending from Event otherwise message sending from user
        /// </summary>
        public int SenderType { get; set; } = 1;

        public string Message { get; set; }

        public int EventId { get; set; } = 0;

        public int UserId { get; set; } = 0;

        public int BeaconId { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("BeaconId")]
        public Beacon Beacon { get; set; }
    }
}
