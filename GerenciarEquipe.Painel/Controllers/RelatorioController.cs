using GerenciarEquipe.Painel.Models;
using GerenciarEquipe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciarEquipe.Painel.Controllers
{
    [CustomAuthorize(Roles = "Admin,Report")]
    public class RelatorioController : Controller
    {
        // GET: Relatorio
        public ActionResult Index()
        {
            return View();
        }
    }
}