using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Contents.Models
{
    [Table("TempUserTable")]
    public class TempUser : BaseModel
    {
        public string Email { get; set; }

        public string TempGuid { get; set; }

        // TODO: this willl change with real ecpiration time
        public DateTime ExpirationTime { get; set; } = DateTime.UtcNow;
    }
}
