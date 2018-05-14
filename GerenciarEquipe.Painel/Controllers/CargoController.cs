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
    public class CargoController : Controller
    {
        private readonly ICargoAppService cargoAppService;
        public CargoController(ICargoAppService cargoAppService)
        {
            this.cargoAppService = cargoAppService;
        }

        // GET: Cargo
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("index", "login");
            return View(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargoAppService.Getall()));
        }

        // GET: Cargo/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoModel cargoModel = Mapper.Map<Cargo, CargoModel>(cargoAppService.GetById(id));
            if (cargoModel == null)
            {
                return HttpNotFound();
            }
            return View(cargoModel);
        }

        // GET: Cargo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cargo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,descicao,permissoes")] CargoModel cargoModel)
        {
            if (ModelState.IsValid)
            {
                cargoAppService.Add(Mapper.Map<CargoModel, Cargo>(cargoModel));
                return RedirectToAction("Index");
            }

            return View(cargoModel);
        }

        // GET: Cargo/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoModel cargoModel = Mapper.Map<Cargo, CargoModel>(cargoAppService.GetById(id));
            if (cargoModel == null)
            {
                return HttpNotFound();
            }
            return View(cargoModel);
        }

        // POST: Cargo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,descicao,permissoes")] CargoModel cargoModel)
        {
            if (ModelState.IsValid)
            {
                cargoAppService.Update(Mapper.Map<CargoModel, Cargo>(cargoModel));
                return RedirectToAction("Index");
            }
            return View(cargoModel);
        }

        // GET: Cargo/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoModel cargoModel = Mapper.Map<Cargo, CargoModel>(cargoAppService.GetById(id));
            if (cargoModel == null)
            {
                return HttpNotFound();
            }
            return View(cargoModel);
        }

        // POST: Cargo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            cargoAppService.Remove(cargoAppService.GetById(id));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cargoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
