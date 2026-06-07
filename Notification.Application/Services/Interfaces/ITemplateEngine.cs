using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Application.Services.Interfaces
{
    public interface ITemplateEngine
    {
     public string Render(string template, Dictionary<string, string> values);
    }
}
