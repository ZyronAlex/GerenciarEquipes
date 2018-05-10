using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciarEquipe.Painel.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("index", "login");
            return View();
        }

        public ActionResult SetColor(string themeName)
        {
            Session["ThemeName"] = themeName;
            return View("index");
        }
    }
}