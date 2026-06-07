using Notification.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Application.Services.Interfaces
{
    public interface INotificationTemplateService
    {
        Task<NotificationTemplateDto> CreateAsync(TemplateRequest dto);

        Task<NotificationTemplateDto> UpdateAsync(Guid id, TemplateRequest dto);

        Task<List<TemplateListDto>> GetAllAsync();

        Task<NotificationTemplateDto?> GetByIdAsync(Guid id);

        Task ToggleActiveAsync(Guid id);

        Task DeleteAsync(Guid id);
    }
}
