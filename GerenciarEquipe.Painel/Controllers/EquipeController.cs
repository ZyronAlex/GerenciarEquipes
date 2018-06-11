using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using AutoMapper;
using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Painel.Models;
using GerenciarEquipe.Services;

namespace GerenciarEquipe.Painel.Controllers
{
    [CustomAuthorize(Roles = "Admin,Equip")]
    public class EquipeController : Controller
    {
        private readonly IFuncionarioAppService funcionarioAppService;
        private readonly ICargoAppService cargoAppService;
        private readonly ILojaAppService lojaAppService;
        public EquipeController(IFuncionarioAppService funcionarioAppService, ICargoAppService cargoAppService, ILojaAppService lojaAppService)
        {
            this.funcionarioAppService = funcionarioAppService;
            this.cargoAppService = cargoAppService;
            this.lojaAppService = lojaAppService;
        }

        // GET: Equipe
        public ActionResult Index()
        {
            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];
            if (usuarioModel is AdminModel)
                return View(Mapper.Map<ICollection<Funcionario>, ICollection<FuncionarioModel>>(funcionarioAppService.Getall()));
            if (usuarioModel is FuncionarioModel)
                return View(Mapper.Map<ICollection<Funcionario>, ICollection<FuncionarioModel>>(funcionarioAppService.GetAllByLoja(((FuncionarioModel)usuarioModel).id_loja)));
            else
                return View(new List<FuncionarioModel>());            
        }

        // GET: Equipe/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuncionarioModel funcionarioModel = Mapper.Map<Funcionario, FuncionarioModel>(funcionarioAppService.GetById(id));
            if (funcionarioModel == null)
            {
                return HttpNotFound();
            }
            return View(funcionarioModel);
        }

        // GET: Equipe/Create
        public ActionResult Create()
        {
            ViewBag.Cargo = new SelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargoAppService.Getall()), "id", "nome");
            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];
            if (usuarioModel is FuncionarioModel)
            {
                FuncionarioModel funcionarioModel = new FuncionarioModel
                {
                    id_loja = ((FuncionarioModel)usuarioModel).id_loja
                };
                return View(funcionarioModel);
            }
            else
            {
                ViewBag.Loja = new MultiSelectList(Mapper.Map<ICollection<Loja>, ICollection<LojaModel>>(lojaAppService.Getall()), "id", "nome");
                return View();
            }
        }

        // POST: Equipe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,email,senha,ativo,foto,fotoFile,matricula,nascimento,genero,cidade,estado,turno,id_cargo,id_loja")] FuncionarioModel funcionarioModel)
        {
            if (ModelState.IsValid)
            {
                if (funcionarioModel.fotoFile != null && funcionarioModel.fotoFile.ContentLength != 0)
                {
                    var extencao = funcionarioModel.fotoFile.FileName.Split('.').Last();
                    var fileName = ((long)DateTime.Now.Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds).ToString() + "." + extencao;
                    string savedFileName = Path.Combine(
                        HostingEnvironment.MapPath("~/FuncionarioFotos/"),
                       Path.GetFileName(fileName));

                    FileInfo Local = new FileInfo(savedFileName);
                    Local.Directory.Create(); // If the directory

                    funcionarioModel.fotoFile.SaveAs(savedFileName);
                    funcionarioModel.foto = GetBaseUrl() + "FuncionarioFotos/" + fileName;
                }
                if (!Criptografia.IsMD5(funcionarioModel.senha))
                    funcionarioModel.senha = Criptografia.EncryptMD5(funcionarioModel.senha);
                funcionarioAppService.Add(Mapper.Map<FuncionarioModel, Funcionario>(funcionarioModel));
                return RedirectToAction("Index");

            }

            ViewBag.Cargo = new SelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargoAppService.Getall()), "id", "nome");
            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];
            if (usuarioModel is AdminModel)
                ViewBag.Loja = new MultiSelectList(Mapper.Map<ICollection<Loja>, ICollection<LojaModel>>(lojaAppService.Getall()), "id", "nome");
            return View(funcionarioModel);
        }

        // GET: Equipe/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuncionarioModel funcionarioModel = Mapper.Map<Funcionario, FuncionarioModel>(funcionarioAppService.GetById(id));
            if (funcionarioModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.Cargo = new SelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargoAppService.Getall()), "id", "nome");
            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];
            if (usuarioModel is AdminModel)
                ViewBag.Loja = new MultiSelectList(Mapper.Map<ICollection<Loja>, ICollection<LojaModel>>(lojaAppService.Getall()), "id", "nome");
            return View(funcionarioModel);
        }

        // POST: Equipe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,email,senha,ativo,foto,fotoFile,matricula,nascimento,genero,cidade,estado,turno,id_cargo,id_loja")] FuncionarioModel funcionarioModel)
        {
            if (ModelState.IsValid)
            {
                if (funcionarioModel.fotoFile != null && funcionarioModel.fotoFile.ContentLength != 0)
                {
                    string fileName;
                    FileInfo Local;
                    if (funcionarioModel.foto != null)
                    {
                        fileName = Path.Combine(HostingEnvironment.MapPath("~/FuncionarioFotos/"), Path.GetFileName(funcionarioModel.foto.Split('/').Last()));
                        Local = new FileInfo(fileName);
                        if (Local.Exists)
                            Local.Delete();
                    }
                    var extencao = funcionarioModel.fotoFile.FileName.Split('.').Last();
                    fileName = ((long)DateTime.Now.Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds).ToString() + "." + extencao;
                    string savedFileName = Path.Combine(
                        HostingEnvironment.MapPath("~/FuncionarioFotos/"),
                       Path.GetFileName(fileName));

                    Local = new FileInfo(savedFileName);
                    Local.Directory.Create(); // If the directory

                    funcionarioModel.fotoFile.SaveAs(savedFileName);
                    funcionarioModel.foto = GetBaseUrl() + "FuncionarioFotos/" + fileName;
                }
                if (!Criptografia.IsMD5(funcionarioModel.senha))
                    funcionarioModel.senha = Criptografia.EncryptMD5(funcionarioModel.senha);

                funcionarioAppService.Update(Mapper.Map<FuncionarioModel, Funcionario>(funcionarioModel));
                return RedirectToAction("Index");
            }
            ViewBag.Cargo = new SelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargoAppService.Getall()), "id", "nome");
            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];
            if (usuarioModel is AdminModel)
                ViewBag.Loja = new MultiSelectList(Mapper.Map<ICollection<Loja>, ICollection<LojaModel>>(lojaAppService.Getall()), "id", "nome");
            return View(funcionarioModel);
        }

        // GET: Equipe/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuncionarioModel funcionarioModel = Mapper.Map<Funcionario, FuncionarioModel>(funcionarioAppService.GetById(id));
            if (funcionarioModel == null)
            {
                return HttpNotFound();
            }
            return View(funcionarioModel);
        }

        // POST: Equipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {           
            funcionarioAppService.Disdisable(funcionarioAppService.GetById(id));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                funcionarioAppService.Dispose();
            }
            base.Dispose(disposing);
        }

        private string GetBaseUrl()
        {
            var request = HttpContext.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;

            if (appUrl != "/")
                appUrl = "/" + appUrl;

            var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return baseUrl;
        }
    }
}
