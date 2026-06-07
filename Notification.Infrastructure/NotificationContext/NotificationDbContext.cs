using Microsoft.EntityFrameworkCore;
using Notification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Infrastructure.NotificationContext
{
    public class NotificationDbContext:DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options)
      : base(options)
        {
        }

        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<NotificationTemplate> NotificationTemplates { get; set; }

    }
}
