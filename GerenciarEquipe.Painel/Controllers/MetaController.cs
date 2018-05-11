using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Painel.Models;

namespace GerenciarEquipe.Painel.Controllers
{
    public class MetaController : Controller
    {
        private readonly IMetaAppService metaAppService;
        public MetaController(IMetaAppService metaAppService)
        {
            this.metaAppService = metaAppService;
        }

        // GET: Meta
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("index", "login");

            return View(new List<MetaModel>());            
        }

        // GET: Meta/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaModel metaModel = null;
            if (metaModel == null)
            {
                return HttpNotFound();
            }
            return View(metaModel);
        }

        // GET: Meta/Create
        public ActionResult Create()
        {

            ViewBag.Cargo = new SelectList(new List<CargoModel>(), "id", "nome");
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
               
                return RedirectToAction("Index");
            }

            return View(metaModel);
        }

        // GET: Meta/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaModel metaModel = null;
            if (metaModel == null)
            {
                return HttpNotFound();
            }
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
                return RedirectToAction("Index");
            }
            return View(metaModel);
        }

        // GET: Meta/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaModel metaModel = null;
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
            MetaModel metaModel = null;
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}
