using Notification.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Application.DTOs
{
    public class NotificationDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public NotificationStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ReadAt { get; set; }
    }
}
