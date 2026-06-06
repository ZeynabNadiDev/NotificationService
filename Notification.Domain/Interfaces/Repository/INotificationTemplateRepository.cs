using Notification.Domain.Entities;
using Notification.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Domain.Interfaces.Repository
{
    public interface INotificationTemplateRepository
    {
        Task<NotificationTemplate?> GetByIdAsync(Guid id);

        // To find the right template when sending by Type and Channel
        Task<NotificationTemplate?> GetByTypeAndChannelAsync(NotificationType type, NotificationChannel channel);

        // Requirement 3.2: List, Add, Update templates
        Task<List<NotificationTemplate>> GetAllAsync();
        Task AddAsync(NotificationTemplate template);
        Task UpdateAsync(NotificationTemplate template);
    }
}
