using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.Contracts.DataTransferObjects.Account
{
    /// <summary>
    /// Result message after registration 
    /// </summary>
    public class RegistrationResultDTO
    {
        /// <summary>
        /// if register is success then return true otherwise return false
        /// </summary>
        public bool IsSuccess{ get; set; }
        /// <summary>
        /// İf there is error than return error message 
        /// </summary>
        public string Message { get; set; }
    }
}
