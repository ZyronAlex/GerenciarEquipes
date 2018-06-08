using AutoMapper;
using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Painel.Models;
using GerenciarEquipe.Services;
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
            if (User.Identity.IsAuthenticated)
            {
                UsuarioModel usuarioModel = Mapper.Map<Usuario, UsuarioModel>(usuarioAppService.GetByEmail(User.Identity.Name));
                usuarioModel.senha = null;
                Session["Usuario"] = usuarioModel;
                if (usuarioModel is FuncionarioModel)
                    return RedirectToNextAuthorizAction(((FuncionarioModel)usuarioModel).cargo.permissoes);
                else
                    return RedirectToNextAuthorizAction(((AdminModel)usuarioModel).permissoes);
            }
            return View();
        }

        [HttpPost]
        public ActionResult index([Bind(Include = "Email,Senha")] LoginModel loginModel)
        {
            loginModel.senha = Criptografia.EncryptMD5(loginModel.senha);
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
                return RedirectToNextAuthorizAction(adminModel.permissoes);
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
                return RedirectToNextAuthorizAction(funcionarioModel.cargo.permissoes);
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

        private ActionResult RedirectToNextAuthorizAction(string Permissoes)
        {
            if (Permissoes.Contains(Permisoes.Admin.ToString()))
            {
                return RedirectToAction("index", "Home");
            }
            else if (Permissoes.Contains(Permisoes.Dash.ToString()))
            {
                return RedirectToAction("index", "Home");
            }
            else if (Permissoes.Contains(Permisoes.Equip.ToString()))
            {
                return RedirectToAction("index", "Equipe");
            }
            else if (Permissoes.Contains(Permisoes.Office.ToString()))
            {
                return RedirectToAction("index", "Cargo");
            }
            else if (Permissoes.Contains(Permisoes.Store.ToString()))
            {
                return RedirectToAction("index", "Loja");
            }
            else if (Permissoes.Contains(Permisoes.Index.ToString()))
            {
                return RedirectToAction("index", "Indicador");
            }
            else if (Permissoes.Contains(Permisoes.Goal.ToString()))
            {
                return RedirectToAction("index", "Meta");
            }
            else if (Permissoes.Contains(Permisoes.Report.ToString()))
            {
                return RedirectToAction("index", "Relatorio");
            }
            else if (Permissoes.Contains(Permisoes.Rank.ToString()))
            {
                return RedirectToAction("index", "Rank");
            }
            else if (Permissoes.Contains(Permisoes.Forms.ToString()))
            {
                return RedirectToAction("index", "Formulario");
            }
            else
                return RedirectToAction("index");
        }
    }
}
