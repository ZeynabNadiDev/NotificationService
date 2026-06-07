using Notification.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Application.Services.Impliments
{
    public class TemplateEngine : ITemplateEngine
    {
        public string Render(string template, Dictionary<string, string> values)
        {
            if (string.IsNullOrEmpty(template)) return string.Empty;

            var rendered = template;
            foreach (var (key, value) in values)
            {
                rendered = rendered.Replace($"{{{{{key}}}}}", value);
            }

            return rendered;
        }
    }
}
