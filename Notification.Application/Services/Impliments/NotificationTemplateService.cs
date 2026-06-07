using Notification.Application.DTOs;
using Notification.Application.Services.Interfaces;
using Notification.Domain.Entities;
using Notification.Domain.Interfaces.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Application.Services.Impliments
{
    public class NotificationTemplateService:INotificationTemplateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationTemplateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<NotificationTemplateDto> CreateAsync(TemplateRequest dto)
        {
            var template = new NotificationTemplate
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                TemplateType = dto.TemplateType,
                Channel = dto.Channel,
                Subject = dto.Subject,
                Body = dto.Body,
                IsActive = true
            };

            await _unitOfWork.NotificationTemplates.AddAsync(template);
            await _unitOfWork.SaveChangesAsync();

            return new NotificationTemplateDto
            {
                Id = template.Id,
                Name = template.Name,
                TemplateType = template.TemplateType,
                Channel = template.Channel,
                Subject = template.Subject,
                Body = template.Body,
                IsActive = template.IsActive
            };
        }

        public async Task<NotificationTemplateDto> UpdateAsync(Guid id, TemplateRequest dto)
        {
            var template = await _unitOfWork.NotificationTemplates.GetByIdAsync(id);

            if (template == null)
                throw new Exception("Template not found");

            template.Name = dto.Name;
            template.TemplateType = dto.TemplateType;
            template.Channel = dto.Channel;
            template.Subject = dto.Subject;
            template.Body = dto.Body;

            await _unitOfWork.SaveChangesAsync();

            return new NotificationTemplateDto
            {
                Id = template.Id,
                Name = template.Name,
                TemplateType = template.TemplateType,
                Channel = template.Channel,
                Subject = template.Subject,
                Body = template.Body,
                IsActive = template.IsActive
            };
        }

        public async Task<List<TemplateListDto>> GetAllAsync()
        {
            var templates = await _unitOfWork.NotificationTemplates.GetAllAsync();

            return templates.Select(t => new TemplateListDto
            {
                Id = t.Id,
                Name = t.Name,
                TemplateType = t.TemplateType,
                Channel = t.Channel,
                IsActive = t.IsActive
            }).ToList();
        }

        public async Task<NotificationTemplateDto?> GetByIdAsync(Guid id)
        {
            var template = await _unitOfWork.NotificationTemplates.GetByIdAsync(id);

            if (template == null)
                return null;

            return new NotificationTemplateDto
            {
                Id = template.Id,
                Name = template.Name,
                TemplateType = template.TemplateType,
                Channel = template.Channel,
                Subject = template.Subject,
                Body = template.Body,
                IsActive = template.IsActive
            };
        }

        public async Task ToggleActiveAsync(Guid id)
        {
            var template = await _unitOfWork.NotificationTemplates.GetByIdAsync(id);

            if (template == null)
                throw new Exception("Template not found");

            template.IsActive = !template.IsActive;

            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var template = await _unitOfWork.NotificationTemplates.GetByIdAsync(id);

            if (template == null)
                throw new Exception("Template not found");

            _unitOfWork.NotificationTemplates.DeleteAsync(template);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
