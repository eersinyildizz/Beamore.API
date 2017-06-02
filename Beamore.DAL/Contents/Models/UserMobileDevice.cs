using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Contents.Models
{
    [Table("UserMobileDeviceTable")]
    public class UserMobileDevice : BaseModel
    {
        public int UniqueDeviceId { get; set; }

        public int PushNotificationIdentifier { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
