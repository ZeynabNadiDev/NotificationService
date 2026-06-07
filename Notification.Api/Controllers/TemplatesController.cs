using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.DTOs;
using Notification.Application.Services.Interfaces;

namespace Notification.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        private readonly INotificationTemplateService _templateService;

        public TemplatesController(INotificationTemplateService templateService)
        {
            _templateService = templateService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TemplateRequest dto)
        {
            var result = await _templateService.CreateAsync(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TemplateRequest dto)
        {
            var result = await _templateService.UpdateAsync(id, dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _templateService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _templateService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPatch("{id}/toggle")]
        public async Task<IActionResult> ToggleActive(Guid id)
        {
            await _templateService.ToggleActiveAsync(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _templateService.DeleteAsync(id);
            return NoContent();
        }

    }
}
