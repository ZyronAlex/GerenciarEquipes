using AutoMapper;
using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Painel.Models;
using System.Web.Mvc;

namespace GerenciarEquipe.Painel.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioAppService usuarioAppService;
        public LoginController(IUsuarioAppService usuarioAppService)
        {
            this.usuarioAppService = usuarioAppService;
        }

        // GET: Login
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            Session.Abandon();
            Session.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult index([Bind(Include = "Email,Senha")] LoginModel loginModel)
        {
            var funcionario = new FuncionarioModel(loginModel);
            var usuario = Mapper.Map<FuncionarioModel, Usuario>(funcionario);
            Session["usuario"] = usuario;
            return RedirectToAction("index", "Home");

            //if (usuarioAppService.Login(usuario))
            //{
            //    usuario.senha = "";
            //    Session["usuario"] = Mapper.Map<Admin, AdminModel>(usuarioAppService.BuscarPorLogin(usuario.email));
            //    return RedirectToAction("index", "Home");
            //}
            //else
            //{
            //    ViewBag.Mensagem = "Login ou Senha inválidos";
            //    return View();
            //}
        }
    }
}
