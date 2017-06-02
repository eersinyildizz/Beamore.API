using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.Contracts.DataTransferObjects
{
    public class LocationDTO
    {
        public double Latitude  { get; set; }

        public double Longitude { get; set; }

        public string Address { get; set; }

        public string Note { get; set; }
    }
}
