using Notification.Domain.Entities;
using Notification.Domain.Enums;

namespace Notification.Domain.Interfaces.Repository
{
    public interface INotificationRepository
    {
        Task<UserNotification?> GetByIdAsync(Guid id);

        // Requirement 3.3: Support for Pagination and filtering by Read/Unread status
        Task<(List<UserNotification> Items, int TotalCount)> GetPagedUsersNotificationsAsync(
            Guid userId, int pageNumber, int pageSize, bool? isRead = null);

        // Requirement 3.6: Get count of unread notifications
        Task<int> GetUnreadCountAsync(Guid userId);

        Task AddAsync(UserNotification notification);

        // Requirement 3.4: Mark a single notification as read
        Task MarkAsReadAsync(Guid id, DateTime readAt);

        // Requirement 3.5: Mark ALL notifications of a user as read
        Task MarkAllAsReadAsync(Guid userId, DateTime readAt);



    }
}
