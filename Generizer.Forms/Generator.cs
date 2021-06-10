using Generizer.Forms.Controls;
using log4net;
using Newtonsoft.Json.Linq;
using System;

namespace Generizer.Forms
{
    public static class Generator
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Generator));

        public static string CreateForm(string json)
        {
            var form = new WebForm();
            dynamic d;
            try
            {
                d = JObject.Parse(json);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Произошда ошибка во время парсинга JSON: {0}", ex);
                return "<p>Произошла ошибка во время парсинга JSON</p>";
            }
             
            form.Name = d.form.name;
            form.Postmessage = d.form.postmessage;

            foreach(dynamic item in d.form.items)
            {
                form.Items.Add(ControlFactory.Create(item));
            }

            return Generator.GenerateHtml(form);
        }

        private static string GenerateHtml(WebForm form)
        {
            var html = string.Empty;
            foreach(var item in form.Items)
            {
                if (item != null)
                {
                    html += item.GenerateHtml();
                }
            }

            html += $"<div id=\'postMsg\'>{form.Postmessage}</div>";

            return html;
        }
    }
}
