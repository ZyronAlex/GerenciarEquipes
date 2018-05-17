using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciarEquipe.Painel.Controllers
{
    public class ErroController : Controller
    {
        // GET: Erro
        public ActionResult Index(string erro)
        {
            ViewBag.Erro = erro;
            return View();
        }
    }
}