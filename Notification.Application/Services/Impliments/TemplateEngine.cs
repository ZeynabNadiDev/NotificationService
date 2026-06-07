using Notification.Application.Services.Interfaces;

namespace Notification.Application.Services.Impliments
{
    public class TemplateEngine : ITemplateEngine
    {
        public string Render(string template, Dictionary<string, string> values)
        {
            if (string.IsNullOrEmpty(template)) return string.Empty;
            if (values == null || values.Count == 0) return template;

            var rendered = template;
            foreach (var (key, value) in values)
            {
                rendered = rendered.Replace($"{{{key}}}", value ?? string.Empty, StringComparison.OrdinalIgnoreCase);
            }

            return rendered;
        }
    }
}
