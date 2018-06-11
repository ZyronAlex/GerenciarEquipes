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
    [CustomAuthorize(Roles = "Admin,Store")]
    public class LojaController : Controller
    {
        private readonly ILojaAppService lojaAppService;
        public LojaController(ILojaAppService lojaAppService)
        {
            this.lojaAppService = lojaAppService;
        }

        // GET: Loja
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            return View(Mapper.Map<ICollection<Loja>, ICollection<LojaModel>>(lojaAppService.Getall()));
        }

        // GET: Loja/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LojaModel lojaModel = Mapper.Map<Loja, LojaModel>(lojaAppService.GetById(id));
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
                lojaAppService.Add(Mapper.Map<LojaModel, Loja>(lojaModel));
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
            LojaModel lojaModel = Mapper.Map<Loja, LojaModel>(lojaAppService.GetById(id));
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
                lojaAppService.Update(Mapper.Map<LojaModel, Loja>(lojaModel));
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
            LojaModel lojaModel = Mapper.Map<Loja, LojaModel>(lojaAppService.GetById(id));
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
            lojaAppService.Remove(lojaAppService.GetById(id));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                lojaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
