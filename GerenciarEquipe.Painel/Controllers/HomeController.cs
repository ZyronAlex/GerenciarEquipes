using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciarEquipe.Painel.Controllers
{
    [Authorize(Roles = "Admin,Dash")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SetColor(string themeName)
        {
            Session["ThemeName"] = themeName;
            return View("index");
        }
    }
}