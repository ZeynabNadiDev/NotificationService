using Notification.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using System.Xml.Linq;

namespace Notification.Domain.Entities
{
    public class NotificationTemplate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }// Friendly name for administrative purposes (e.g., "Order Confirmation")
        public NotificationType TemplateType { get; set; }
        public NotificationChannel Channel { get; set; }
        public string Subject { get; set; }// Subject line, primarily used for Email notifications
        public string Body { get; set; } // Raw content with placeholders, e.g., "Hello {{UserName}}, your order is {{Status}}"
        public bool IsActive { get; set; }

    }
}
