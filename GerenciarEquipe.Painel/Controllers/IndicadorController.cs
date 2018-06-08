using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Painel.Models;
using GerenciarEquipe.Services;

namespace GerenciarEquipe.Painel.Controllers
{
    [CustomAuthorize(Roles = "Admin,Index")]
    public class IndicadorController : Controller
    {
        private readonly IIndicadorAppService indicadorAppService;
        private readonly ILojaAppService lojaAppService;

        public IndicadorController(IIndicadorAppService indicadorAppService, ILojaAppService lojaAppService)
        {
            this.indicadorAppService = indicadorAppService;
            this.lojaAppService = lojaAppService;
        }

        // GET: Indicador
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];
            if (usuarioModel is AdminModel)
                return View(Mapper.Map<ICollection<Indicador>, ICollection<IndicadorModel>>(indicadorAppService.Getall()));
            if (usuarioModel is FuncionarioModel)
                return View(Mapper.Map<ICollection<Indicador>, ICollection<IndicadorModel>>(indicadorAppService.GetAllByLoja(((FuncionarioModel)usuarioModel).id_loja)));
            else
                return View(new List<IndicadorModel>());            
        }

        // GET: Indicador/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndicadorModel indicadorModel = Mapper.Map<Indicador,IndicadorModel>(indicadorAppService.GetById(id));
            if (indicadorModel == null)
            {
                return HttpNotFound();
            }
            return View(indicadorModel);
        }

        // GET: Indicador/Create
        public ActionResult Create()
        {
            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];
            if (usuarioModel is FuncionarioModel)
            {
                IndicadorModel indicadorModel = new IndicadorModel
                {
                    id_loja = ((FuncionarioModel)usuarioModel).id_loja
                };
                return View(indicadorModel);
            }
            else
            {
                ViewBag.Loja = new MultiSelectList(Mapper.Map<ICollection<Loja>, ICollection<LojaModel>>(lojaAppService.Getall()), "id", "nome");
                return View();
            }
        }

        // POST: Indicador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,indicativa,id_loja,create_at,update_at")] IndicadorModel indicadorModel)
        {
            if (ModelState.IsValid)
            {
                indicadorAppService.Add(Mapper.Map<IndicadorModel, Indicador>(indicadorModel));
                return RedirectToAction("Index");
            }

            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];
            if (usuarioModel is AdminModel)
                ViewBag.Loja = new MultiSelectList(Mapper.Map<ICollection<Loja>, ICollection<LojaModel>>(lojaAppService.Getall()), "id", "nome");
            return View(indicadorModel);
        }

        // GET: Indicador/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndicadorModel indicadorModel = Mapper.Map<Indicador, IndicadorModel>(indicadorAppService.GetById(id));
            if (indicadorModel == null)
            {
                return HttpNotFound();
            }

            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];
            if (usuarioModel is AdminModel)
                ViewBag.Loja = new MultiSelectList(Mapper.Map<ICollection<Loja>, ICollection<LojaModel>>(lojaAppService.Getall()), "id", "nome");
            return View(indicadorModel);
        }

        // POST: Indicador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,indicativa,id_loja,create_at,update_at")] IndicadorModel indicadorModel)
        {
            if (ModelState.IsValid)
            {
                indicadorAppService.Update(Mapper.Map<IndicadorModel, Indicador>(indicadorModel));
                return RedirectToAction("Index");
            }

            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];
            if (usuarioModel is AdminModel)
                ViewBag.Loja = new MultiSelectList(Mapper.Map<ICollection<Loja>, ICollection<LojaModel>>(lojaAppService.Getall()), "id", "nome");
            return View(indicadorModel);
        }

        // GET: Indicador/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndicadorModel indicadorModel = Mapper.Map<Indicador, IndicadorModel>(indicadorAppService.GetById(id)); ;
            if (indicadorModel == null)
            {
                return HttpNotFound();
            }
            return View(indicadorModel);
        }

        // POST: Indicador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            indicadorAppService.Remove(indicadorAppService.GetById(id)); ;
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                indicadorAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
