using Generizer.Models;
using log4net;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web.Mvc;

namespace Generizer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            var model = new RawFormModel();
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                string localPath = new Uri(path).LocalPath;
                localPath = Path.Combine(localPath, "Json/Form_2.json");
                model.Json = System.IO.File.ReadAllText(localPath, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Произошла ошибка при получении модели: {0}", ex);
            }            

            return View(model);
        }
    }
}