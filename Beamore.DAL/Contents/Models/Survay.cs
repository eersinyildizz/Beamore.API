using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Contents.Models
{
    [Table("SurveyTable")]
    public class Survay : BaseModel
    {
        public Survay()
        {
            this.SurvayOptions = new HashSet<SurvayOption>();
        }
        public string Question { get; set; }

        public int BeaconId { get; set; }

        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }

        [ForeignKey("BeaconId")]
        public Beacon Beacon{ get; set; }

        public virtual  ICollection<SurvayOption> SurvayOptions { get; set; }
    }
}
