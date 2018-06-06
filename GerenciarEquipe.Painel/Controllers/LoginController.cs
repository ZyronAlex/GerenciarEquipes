using AutoMapper;
using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Painel.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GerenciarEquipe.Painel.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdminAppService adminAppService;
        private readonly IFuncionarioAppService funcionarioAppService;
        private readonly IUsuarioAppService usuarioAppService;

        public LoginController(IAdminAppService adminAppService, IFuncionarioAppService funcionarioAppService, IUsuarioAppService usuarioAppService)
        {
            this.adminAppService = adminAppService;
            this.funcionarioAppService = funcionarioAppService;
            this.usuarioAppService = usuarioAppService;
        }

        // GET: Login
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult index([Bind(Include = "Email,Senha")] LoginModel loginModel)
        {
            if (adminAppService.Login(Mapper.Map<AdminModel, Admin>(new AdminModel(loginModel))))
            {
                AdminModel adminModel = Mapper.Map<Admin, AdminModel>(adminAppService.GetByEmail(loginModel.email));
                FormsAuthentication.SetAuthCookie(adminModel.email, false);
                var authTicket = new FormsAuthenticationTicket(1, adminModel.email, DateTime.Now, DateTime.Now.AddMinutes(60), false, adminModel.permissoes);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                adminModel.senha = null;
                Session["Usuario"] = adminModel;
                return RedirectToAction("index", "Home");
            }            
            else if (funcionarioAppService.Login(Mapper.Map<FuncionarioModel, Funcionario>(new FuncionarioModel(loginModel))))
            {
                FuncionarioModel funcionarioModel = Mapper.Map<Funcionario, FuncionarioModel>(funcionarioAppService.GetByEmail(loginModel.email));
                FormsAuthentication.SetAuthCookie(funcionarioModel.email, false);
                var authTicket = new FormsAuthenticationTicket(1, funcionarioModel.email, DateTime.Now, DateTime.Now.AddMinutes(60), false, funcionarioModel.cargo.permissoes);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                funcionarioModel.senha = null;
                Session["Usuario"] = funcionarioModel;
                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.Mensagem = "Login ou Senha inválidos";
                return View();
            }
        }

        public ActionResult LogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

        public void GetEmail()
        {
            UsuarioModel usuarioModel = Mapper.Map<Usuario, UsuarioModel>(usuarioAppService.GetByEmail(User.Identity.Name));
            usuarioModel.senha = null;
            Session["Usuario"] = usuarioModel;
        }
    }
}
