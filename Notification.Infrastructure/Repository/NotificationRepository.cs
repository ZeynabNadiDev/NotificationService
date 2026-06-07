using Microsoft.EntityFrameworkCore;
using Notification.Domain.Entities;
using Notification.Domain.Enums;
using Notification.Domain.Interfaces.Repository;
using Notification.Infrastructure.NotificationContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Infrastructure.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationDbContext _context;
        public NotificationRepository(NotificationDbContext context)
        {
            _context = context;
        }
        public async Task<UserNotification?> GetByIdAsync(Guid id)
        {
            return await _context.UserNotifications.FindAsync(id);
        }
        public async Task<(List<UserNotification> Items, int TotalCount)> GetPagedUsersNotificationsAsync(
            Guid userId, int pageNumber, int pageSize, bool? isRead = null)
        {
            var query = _context.UserNotifications.Where(x => x.UserId == userId);
            if (isRead.HasValue) 
            {
                if (isRead.Value)
                    query = query.Where(x => x.ReadAt != null);
                else
                    query = query.Where(x => x.ReadAt == null);
            }
            var totalCount = await query.CountAsync();

            var items = await query.OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
        public async Task<int> GetUnreadCountAsync(Guid userId)
        {
            return await _context.UserNotifications
           .CountAsync(x => x.UserId == userId && x.ReadAt == null);
        }

        public async Task AddAsync(UserNotification notification)
        {
            await _context.UserNotifications.AddAsync(notification);
        }
        public async Task MarkAsReadAsync(Guid id, DateTime readAt)
        {
            await _context.UserNotifications
                .Where(x => x.Id == id && x.ReadAt == null)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(n => n.ReadAt, readAt)
                    .SetProperty(n => n.Status, NotificationStatus.Read));

            } 
        public async Task MarkAllAsReadAsync(Guid userId, DateTime readAt)
        {
            var notifications = await _context.UserNotifications
                .Where(x => x.UserId == userId && x.ReadAt == null)
                .ToListAsync();
            foreach (var notification in notifications) 
            {
                notification.ReadAt = readAt;
                notification.Status = NotificationStatus.Read;
            }
        }
        public async Task MarkUserNotificationAsReadAsync(Guid userId, DateTime readAt)
        {
            var notification = await _context.UserNotifications
                  .FirstOrDefaultAsync(x => x.Id == userId && x.ReadAt == null);

            if (notification != null)
            {
                notification.ReadAt = readAt;
            }
        }
    }
}
