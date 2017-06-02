using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.Contracts.DataTransferObjects.Account
{
    /// <summary>
    /// Login object that will used for login
    /// </summary>
    public class LoginDTO
    {
        public string grant_type { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
