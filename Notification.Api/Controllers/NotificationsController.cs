using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.DTOs;
using Notification.Application.Services.Interfaces;

namespace Notification.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpPost]
        public async Task<IActionResult>Send([FromBody] SendNotificationRequest request)
        {
            var notificationId = await _notificationService.SendNotificationAsync(request);
            return Ok(new { Id = notificationId });
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserNotifications(Guid userId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _notificationService.GetUserNotificationsAsync(userId, page, pageSize);
            return Ok(result);
        }
        [HttpGet("user/{userId}/unread-count")]
        public async Task<IActionResult> GetUnreadCount(Guid userId)
        {
            var count = await _notificationService.GetUnreadCountAsync(userId);
            return Ok(new { UnreadCount = count });
        }
        [HttpPut("{id}/read")]
        public async Task<IActionResult> MarkAsRead(Guid id)
        {
            await _notificationService.MarkAsReadAsync(id);
            return NoContent();
        }

        [HttpPut("user/{userId}/read-all")]
        public async Task<IActionResult> MarkAllAsRead(Guid userId)
        {
            await _notificationService.MarkAllAsReadAsync(userId);
            return NoContent();
        }
    }
}
