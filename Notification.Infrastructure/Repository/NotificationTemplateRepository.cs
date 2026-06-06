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
    public class NotificationTemplateRepository : INotificationTemplateRepository
    {
        private readonly NotificationDbContext _context;
        public NotificationTemplateRepository(NotificationDbContext context)
        {
            _context = context;
        }
        async Task<NotificationTemplate?> INotificationTemplateRepository.GetByIdAsync(Guid id)
        {
            return await _context.NotificationTemplates.FindAsync(id);
        }

        async Task<NotificationTemplate?> INotificationTemplateRepository.GetByTypeAndChannelAsync(
          NotificationType type, NotificationChannel channel)
        {
            return await _context.NotificationTemplates
                       .FirstOrDefaultAsync(x => x.TemplateType == type && x.Channel == channel);
        }

        async Task<List<NotificationTemplate>> INotificationTemplateRepository.GetAllAsync()
        {
            return await _context.NotificationTemplates
               .OrderBy(x => x.TemplateType)
               .ThenBy(x => x.Channel)
               .ToListAsync();
        }
        async Task INotificationTemplateRepository.AddAsync(NotificationTemplate template)
        {
            await _context.NotificationTemplates.AddAsync(template);
        }

        Task INotificationTemplateRepository.UpdateAsync(NotificationTemplate template)
        {
            _context.NotificationTemplates.Update(template);
            return Task.CompletedTask;
        }
    }
}
