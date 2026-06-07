using MassTransit;
using Microsoft.Extensions.Logging;
using Notification.Application.Events;

namespace Notification.Infrastructure.Consumers;

public class NotificationCreatedConsumer : IConsumer<NotificationCreatedEvent>
{
    private readonly ILogger<NotificationCreatedConsumer> _logger;

    public NotificationCreatedConsumer(ILogger<NotificationCreatedConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<NotificationCreatedEvent> context)
    {
        var message = context.Message;

        _logger.LogInformation("--- Processing Notification ---");
        _logger.LogInformation("NotificationId: {NotificationId}", message.NotificationId);
        _logger.LogInformation("UserId: {UserId}", message.UserId);
        _logger.LogInformation("Title: {Title}", message.Title);
        _logger.LogInformation("Message: {Message}", message.Message);
        _logger.LogInformation("Channel: {Channel}", message.Channel);
        _logger.LogInformation("Type: {Type}", message.Type);

        await Task.Delay(1000);

        _logger.LogInformation("--- Notification Processed Successfully ---");
    }
}
