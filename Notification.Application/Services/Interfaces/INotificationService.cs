using Notification.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Application.Services.Interfaces
{
    public interface INotificationService
    {
        Task<Guid> SendNotificationAsync(SendNotificationRequest request);

        Task MarkAsReadAsync(Guid notificationId);

        Task MarkAllAsReadAsync(Guid userId);

        Task<List<NotificationDto>> GetUserNotificationsAsync(Guid userId, int page, int pageSize);

        Task<int> GetUnreadCountAsync(Guid userId);
    }
}
