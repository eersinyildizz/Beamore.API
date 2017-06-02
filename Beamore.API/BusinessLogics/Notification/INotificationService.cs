using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beamore.API.BusinessLogics.Notification
{
    public interface INotificationService
    {
        void SendNotificationAsync();
    }
}