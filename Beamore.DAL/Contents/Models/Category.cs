using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Contents.Models
{
    [Table("CategoryTable")]
    public class Category : BaseModel
    {
        public Category()
        {
            this.Events = new HashSet<Event>();
        }
        public string CategoryName { get; set; }

        public string CategoryExplanation { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
