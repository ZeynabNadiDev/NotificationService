using MassTransit;
using Notification.Application.DTOs;
using Notification.Application.Events;
using Notification.Application.Services.Interfaces;
using Notification.Domain.Entities;
using Notification.Domain.Enums;
using Notification.Domain.Interfaces.Unit_of_work;
using System.Linq;

namespace Notification.Application.Services.Impliments
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _uow;
        private readonly ITemplateEngine _templateEngine;
        private readonly IPublishEndpoint _publishEndpoint;
        public NotificationService(IUnitOfWork uow, ITemplateEngine templateEngine, IPublishEndpoint publishEndpoint)
        {
            _uow = uow;
            _templateEngine = templateEngine;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Guid> SendNotificationAsync(SendNotificationRequest request)
        {
            string? title = request.Title;
            string? message = request.Message;

            if (request.TemplateId.HasValue)
            {
                var template = await _uow.NotificationTemplates.GetByIdAsync(request.TemplateId.Value);

                if (template == null)
                    throw new Exception("Notification template not found");

                var parameters = request.Parameters ?? new Dictionary<string, string>();

                title = _templateEngine.Render(template.Subject, parameters);
                message = _templateEngine.Render(template.Body, parameters);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(message))
                    throw new Exception("Title and Message are required when TemplateId is not provided.");
            }

            var notification = new UserNotification
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                TemplateId = request.TemplateId,
                Title = title!,
                Message = message!,
                Channel = request.Channel,
                Type = request.Type,
                Status = NotificationStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _uow.UserNotifications.AddAsync(notification);
            await _uow.SaveChangesAsync();

            await _publishEndpoint.Publish(new NotificationCreatedEvent
            {
                NotificationId = notification.Id,
                UserId = notification.UserId,
                Title = notification.Title,
                Message = notification.Message,
                Channel = notification.Channel.ToString(), 
                Type = notification.Type.ToString(),
                CreatedAt = notification.CreatedAt
            });


            return notification.Id;
        }

        public async Task<int> GetUnreadCountAsync(Guid userId)
        {
            return await _uow.UserNotifications.GetUnreadCountAsync(userId);
        }

        public async Task<List<NotificationDto>> GetUserNotificationsAsync(Guid userId, int page, int pageSize)
        {
            var result = await _uow.UserNotifications
                .GetPagedUsersNotificationsAsync(userId, page, pageSize);

            return result.Items.Select(n => new NotificationDto
            {
                Id = n.Id,
                Title = n.Title,
                Message = n.Message,
                Status = n.Status,
                CreatedAt = n.CreatedAt,
                ReadAt = n.ReadAt
            }).ToList();
        }

        public async Task MarkAsReadAsync(Guid notificationId)
        {
            await _uow.UserNotifications.MarkAsReadAsync(notificationId, DateTime.UtcNow);
            await _uow.SaveChangesAsync();
        }

        public async Task MarkAllAsReadAsync(Guid userId)
        {
            await _uow.UserNotifications.MarkAllAsReadAsync(userId, DateTime.UtcNow);
            await _uow.SaveChangesAsync();
        }
    }
}
