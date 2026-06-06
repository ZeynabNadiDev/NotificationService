using Notification.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Domain.Interfaces.Unit_of_work
{
    public interface IUnitOfWork:IDisposable
    {
        INotificationRepository UserNotifications { get; }
        INotificationTemplateRepository NotificationTemplates { get; }
        Task<int> SaveChangesAsync();
    }
}
