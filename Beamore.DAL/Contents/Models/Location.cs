using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Contents.Models
{
    [Table("LocationTable")]
    public class Location : BaseModel
    {
        public Location()
        {
            this.Events = new HashSet<Event>();
        }
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Address { get; set; }

        public string Note { get; set; }

        public virtual ICollection<Event> Events { get; set; }

    }
}
