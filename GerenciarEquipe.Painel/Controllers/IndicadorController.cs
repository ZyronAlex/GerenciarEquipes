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
    public class IndicadorController : Controller
    {
        private readonly IIndicadorAppService indicadorAppService;
        public IndicadorController(IIndicadorAppService indicadorAppService)
        {
            this.indicadorAppService = indicadorAppService;
        }

        // GET: Indicador
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            return View(Mapper.Map<ICollection<Indicador>, ICollection<IndicadorModel>>(indicadorAppService.Getall()));
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
            return View();
        }

        // POST: Indicador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,indicativa,create_at,update_at")] IndicadorModel indicadorModel)
        {
            if (ModelState.IsValid)
            {
                indicadorAppService.Add(Mapper.Map<IndicadorModel, Indicador>(indicadorModel));
                return RedirectToAction("Index");
            }

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
            return View(indicadorModel);
        }

        // POST: Indicador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,indicativa,create_at,update_at")] IndicadorModel indicadorModel)
        {
            if (ModelState.IsValid)
            {
                indicadorAppService.Update(Mapper.Map<IndicadorModel, Indicador>(indicadorModel));
                return RedirectToAction("Index");
            }
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
