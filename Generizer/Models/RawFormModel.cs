using System.Web.Mvc;

namespace Generizer.Models
{
    public class RawFormModel
    {
        [AllowHtml]
        public string Json { get; set; }
    }
}