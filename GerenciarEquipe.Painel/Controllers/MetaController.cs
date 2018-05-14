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

namespace GerenciarEquipe.Painel.Controllers
{
    public class MetaController : Controller
    {
        private readonly IMetaAppService metaAppService;
        private readonly ICargoAppService cargoAppService;
        public MetaController(IMetaAppService metaAppService, ICargoAppService cargoAppService)
        {
            this.metaAppService = metaAppService;
            this.cargoAppService = cargoAppService;
        }

        // GET: Meta
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("index", "login");

            return View(Mapper.Map<ICollection<Meta>, ICollection<MetaModel>>(metaAppService.Getall()));            
        }

        // GET: Meta/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaModel metaModel = Mapper.Map<Meta, MetaModel>(metaAppService.GetById(id));
            if (metaModel == null)
            {
                return HttpNotFound();
            }
            return View(metaModel);
        }

        // GET: Meta/Create
        public ActionResult Create()
        {
            ViewBag.Cargo = new SelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargoAppService.Getall()), "id", "nome");
            return View();
        }

        // POST: Meta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descicao,objetivo,objetivo_parcial,objetivo_parcial_dia,unidade,referencia,fonte,grupo,peso,data_inicio,data_fim,id_cargo,id_indicador,create_at,update_at")] MetaModel metaModel)
        {
            if (ModelState.IsValid)
            {
                metaAppService.Add(Mapper.Map<MetaModel, Meta>(metaModel));
                return RedirectToAction("Index");
            }
            ViewBag.Cargo = new SelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargoAppService.Getall()), "id", "nome");
            return View(metaModel);
        }

        // GET: Meta/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaModel metaModel = Mapper.Map<Meta, MetaModel>(metaAppService.GetById(id));
            if (metaModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cargo = new SelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargoAppService.Getall()), "id", "nome");
            return View(metaModel);
        }

        // POST: Meta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descicao,objetivo,objetivo_parcial,objetivo_parcial_dia,unidade,referencia,fonte,grupo,peso,data_inicio,data_fim,id_cargo,id_indicador,create_at,update_at")] MetaModel metaModel)
        {
            if (ModelState.IsValid)
            {
                metaAppService.Update(Mapper.Map<MetaModel, Meta>(metaModel));
                return RedirectToAction("Index");
            }
            ViewBag.Cargo = new SelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargoAppService.Getall()), "id", "nome");
            return View(metaModel);
        }

        // GET: Meta/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaModel metaModel = Mapper.Map<Meta, MetaModel>(metaAppService.GetById(id));
            if (metaModel == null)
            {
                return HttpNotFound();
            }
            return View(metaModel);
        }

        // POST: Meta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            metaAppService.Remove(metaAppService.GetById(id));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                metaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
