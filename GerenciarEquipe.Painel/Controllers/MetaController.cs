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
        private readonly IAmbitoAppService ambitoAppService;
        private readonly IInquiridoAppService inquiridoAppService;
        private readonly ICargoAppService cargoAppService;
        private readonly IIndicadorAppService indicadorAppService;

        public MetaController(IMetaAppService metaAppService, IAmbitoAppService ambitoAppService, IInquiridoAppService inquiridoAppService, ICargoAppService cargoAppService, IIndicadorAppService indicadorAppService)
        {
            this.metaAppService = metaAppService;
            this.ambitoAppService = ambitoAppService;
            this.inquiridoAppService = inquiridoAppService;
            this.cargoAppService = cargoAppService;
            this.indicadorAppService = indicadorAppService;
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
            ViewBag.Indicador = new SelectList(Mapper.Map<ICollection<Indicador>, ICollection<IndicadorModel>>(indicadorAppService.Getall()), "id", "nome");
            //ViewBag.Cargo = new SelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargoAppService.Getall()), "id", "nome");
            MetaModel metaModel = new MetaModel();
            metaModel.cargoAmbitos = new SelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargoAppService.Getall()), "id", "nome");
            metaModel.cargoInquiridos = new SelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargoAppService.Getall()), "id", "nome");
            return View();
        }

        // POST: Meta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descicao,objetivo,objetivo_parcial,objetivo_parcial_dia,unidade,referencia,fonte,grupo,peso,id_indicador,inquiridos,ambitos")] MetaModel metaModel)
        {
            if (ModelState.IsValid)
            {
                metaAppService.Add(Mapper.Map<MetaModel, Meta>(metaModel));
                return RedirectToAction("Index");
            }

            ViewBag.Indicador = new SelectList(Mapper.Map<ICollection<Indicador>, ICollection<IndicadorModel>>(indicadorAppService.Getall()), "id", "nome");
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

            ViewBag.Indicador = new SelectList(Mapper.Map<ICollection<Indicador>, ICollection<IndicadorModel>>(indicadorAppService.Getall()), "id", "nome");
            ViewBag.Cargo = new SelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargoAppService.Getall()), "id", "nome");
            return View(metaModel);
        }

        // POST: Meta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descicao,objetivo,objetivo_parcial,objetivo_parcial_dia,unidade,referencia,fonte,grupo,peso,id_indicador,create_at,update_at")] MetaModel metaModel)
        {
            if (ModelState.IsValid)
            {
                metaAppService.Update(Mapper.Map<MetaModel, Meta>(metaModel));
                return RedirectToAction("Index");
            }

            ViewBag.Indicador = new SelectList(Mapper.Map<ICollection<Indicador>, ICollection<IndicadorModel>>(indicadorAppService.Getall()), "id", "nome");
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
