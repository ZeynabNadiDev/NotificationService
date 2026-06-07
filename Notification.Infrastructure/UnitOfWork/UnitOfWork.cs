using Notification.Domain.Interfaces;
using Notification.Domain.Interfaces.Repository;
using Notification.Domain.Interfaces.Unit_of_work;
using Notification.Infrastructure.NotificationContext;

namespace Notification.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NotificationDbContext _context;

        public INotificationRepository Notifications { get; }
        public INotificationTemplateRepository NotificationTemplates { get; }

        public INotificationRepository UserNotifications { get; }

        public UnitOfWork(
            NotificationDbContext context,
            INotificationRepository notificationRepository,
            INotificationTemplateRepository templateRepository)
        {
            _context = context;
            Notifications = notificationRepository;
            NotificationTemplates = templateRepository;
            UserNotifications = notificationRepository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
    }
}
