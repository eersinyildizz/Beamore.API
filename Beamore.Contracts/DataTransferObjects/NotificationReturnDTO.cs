using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.Contracts.DataTransferObjects
{
    public class NotificationReturnDTO
    {
        public int Id { get; set; }

        public string NotificationHeader { get; set; }

        public string NotificationMessage { get; set; }

        public int EventId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
