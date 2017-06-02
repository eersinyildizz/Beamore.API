using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.Contracts.DataTransferObjects.Account
{
    public class ForgotPasswordResultDTO
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
