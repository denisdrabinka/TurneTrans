using Android.App;
using Android.Content;
using AndroidX.Core.App;
using Firebase.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace TurneTrans.Platforms.Android.Services;

[Service(Exported = true)]
[IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
public class FirebaseService : FirebaseMessagingService
{
    public FirebaseService() { }

    public override void OnNewToken(string token)
    {
        base.OnNewToken(token);
        if (Preferences.ContainsKey("DeviceToken"))
        {
            Preferences.Remove("DeviceToken");
        }
        Preferences.Set("DeviceToken", token);
    }

    public override void OnMessageReceived(RemoteMessage message)
    {
        base.OnMessageReceived(message);
        var notification = message.GetNotification();
        sendNotification(notification.Body, notification.Title, message.Data);
    }

    private void sendNotification(string in_messageBody, string in_title, IDictionary<string, string> in_data)
    {
        var intent = new Intent(this, typeof(MainActivity));
        intent.AddFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);

        foreach (var key in in_data.Keys)
        {
            string value = in_data[key];
            intent.PutExtra(key, value);
        }

        var pendingIntent = PendingIntent.GetActivity(this, MainActivity.NotificationID, intent, PendingIntentFlags.OneShot | PendingIntentFlags.Immutable);

        var notificationBuilder = new NotificationCompat.Builder(this, MainActivity.Channel_ID)
            .SetContentTitle(in_title)
            .SetSmallIcon(Resource.Mipmap.appicon)
            .SetContentText(in_messageBody)
            .SetChannelId(MainActivity.Channel_ID)
            .SetContentIntent(pendingIntent)
            .SetAutoCancel(true)
            .SetPriority((int)NotificationPriority.Max);

        var notificationManager = NotificationManagerCompat.From(this);
        notificationManager.Notify(MainActivity.NotificationID, notificationBuilder.Build());
    }
}
