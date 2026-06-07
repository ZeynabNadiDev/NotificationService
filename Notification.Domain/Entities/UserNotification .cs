using Notification.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Domain.Entities
{
    public class UserNotification 
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? TemplateId { get; set; }// Foreign Key to the template used for this notification
        public virtual NotificationTemplate? Template { get; set; }
        public string Title { get; set; } // Final rendered subject/title after replacing placeholders
        public string Message { get; set; } // Final rendered message content after replacing placeholders
        public NotificationChannel Channel { get; set; }
        public NotificationType Type { get; set; }//This is extra but I added becuse Checking data fastly
        public NotificationStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ReadAt { get; set; }

    }
}
