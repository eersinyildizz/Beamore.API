using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Contents.Models
{
    /// <summary>
    /// Database abstract Basemodel - Private Key && CretaedDate
    /// </summary>
    public abstract class BaseModel
    {
        [Key]
        public int Id{ get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
