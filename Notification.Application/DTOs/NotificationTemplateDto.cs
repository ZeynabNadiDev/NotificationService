using Notification.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Application.DTOs
{
    public class NotificationTemplateDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public NotificationType TemplateType { get; set; }

        public NotificationChannel Channel { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool IsActive { get; set; }
    }
}
