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
    public class LojaController : Controller
    {
        private readonly ILojaAppService lojaAppService;
        public LojaController(ILojaAppService lojaAppService)
        {
            this.lojaAppService = lojaAppService;
        }

        // GET: Loja
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("index", "login");
            return View(new List<LojaModel>());
        }

        // GET: Loja/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LojaModel lojaModel = null;
            if (lojaModel == null)
            {
                return HttpNotFound();
            }
            return View(lojaModel);
        }

        // GET: Loja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,email,endereco,telefone,create_at,update_at")] LojaModel lojaModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(lojaModel);
        }

        // GET: Loja/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LojaModel lojaModel = null;
            if (lojaModel == null)
            {
                return HttpNotFound();
            }
            return View(lojaModel);
        }

        // POST: Loja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,email,endereco,telefone,create_at,update_at")] LojaModel lojaModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(lojaModel);
        }

        // GET: Loja/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LojaModel lojaModel = null;
            if (lojaModel == null)
            {
                return HttpNotFound();
            }
            return View(lojaModel);
        }

        // POST: Loja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            LojaModel lojaModel = null;
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
