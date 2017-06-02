using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.Contracts.DataTransferObjects.Event
{
    /// <summary>
    /// Genel olarak servicen donen başarılı başarısız event sonuçları.
    /// </summary>
    public class EventReturnDTO
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
