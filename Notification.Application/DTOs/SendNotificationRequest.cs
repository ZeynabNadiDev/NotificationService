using Notification.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Application.DTOs
{
    public class SendNotificationRequest
    {
        public Guid UserId { get; set; }

        public string? Title { get; set; }
        public string? Message { get; set; }

        public Guid? TemplateId { get; set; }

        public Dictionary<string, string>? Parameters { get; set; }

        public NotificationChannel Channel { get; set; }

        public NotificationType Type { get; set; }
    }
}
