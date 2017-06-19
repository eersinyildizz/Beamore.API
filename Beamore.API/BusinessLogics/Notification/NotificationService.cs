using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Beamore.API.BusinessLogics.Notification
{
    public class NotificationService
    {
        public static async void SendNotificationForAndroidAsync()
        {
            //Endpoint = sb://connectsmartnotificationhub.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=dWTA28wJlB9xm5dMlyKRApC7erVRTSVfCDw7b+onDMs=
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString("key", "hubName");
            await hub.SendGcmNativeNotificationAsync("{ \"data\" : {\"message\":\"Beamore Notification test!\"}}");
        }
        public static async void SendNotificationForAppleAsync()
        {
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString("key", "hubName");
            var alert = "{\"aps\":{\"alert\":\"Connect Smart notification test \"}}";
            await hub.SendAppleNativeNotificationAsync(alert);
        }

    }
}
