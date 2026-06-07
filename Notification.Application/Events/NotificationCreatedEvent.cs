using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Application.Events
{
    public record NotificationCreatedEvent
    {
        public Guid NotificationId { get; init; }
        public Guid UserId { get; init; }
        public string Title { get; init; } = default!;
        public string Message { get; init; } = default!;
        public string Channel { get; init; } = default!;
        public string Type { get; init; } = default!;
        public DateTime CreatedAt { get; init; }
    }
}
