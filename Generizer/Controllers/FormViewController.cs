using Generizer.Forms;
using Generizer.Models;
using log4net;
using System.Web;
using System.Web.Mvc;

namespace Generizer.Controllers
{
    public class FormViewController : Controller
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(FormViewController));

        [HttpPost]
        public ActionResult GenerateForm(RawFormModel rawForm)
        {
            if (rawForm.Json == null)
            {
                _log.Info("Пустой входной JSON");
                return Content("Json пустой");
            }

            var decoded = HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(rawForm.Json));
            var generated = Generator.CreateForm(decoded);
            return View("FormView", new FormModel { Html = generated });
        }
    }
}