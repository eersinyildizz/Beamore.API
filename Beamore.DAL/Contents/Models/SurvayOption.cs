using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Contents.Models
{
    [Table("SurvayOptionTable")]
    public class SurvayOption : BaseModel
    {
        public string Option { get; set; }

        public int NumberOfSelected { get; set; }

        public int SurvayId { get; set; }

        [ForeignKey("SurvayId")]
        public virtual Survay Survay { get; set; }
    }
}
