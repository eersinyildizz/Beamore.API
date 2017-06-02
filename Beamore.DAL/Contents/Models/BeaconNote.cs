using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Contents.Models
{
    [Table("BeaconNoteTable")]
    public class BeaconNote : BaseModel
    {
        public string NoteHeader { get; set; }

        public string Note { get; set; }

        public DateTime SentDate { get; set; }

        public bool IsActive { get; set; }

        public int BeaconId { get; set; }

        [ForeignKey("BeaconId")]
        public Beacon Beacon { get; set; }
    }
}
