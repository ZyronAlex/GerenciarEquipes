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
    public class AdminController : Controller
    {
        private readonly IAdminAppService adminAppService;
        public AdminController(IAdminAppService adminAppService)
        {
            this.adminAppService = adminAppService;
        }

        // GET: Admin
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("index", "login");
            return View(Mapper.Map<ICollection<Admin>, ICollection<AdminModel>>(adminAppService.Getall()));
        }

        // GET: Admin/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminModel adminModel = Mapper.Map<Admin, AdminModel>(adminAppService.GetById(id));
            if (adminModel == null)
            {
                return HttpNotFound();
            }
            return View(adminModel);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,email,senha,ativo,create_at,update_at,permissoes")] AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {
                adminAppService.Add(Mapper.Map<AdminModel, Admin>(adminModel));
                return RedirectToAction("Index");
            }

            return View(adminModel);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminModel adminModel = Mapper.Map<Admin, AdminModel>(adminAppService.GetById(id)); ;
            if (adminModel == null)
            {
                return HttpNotFound();
            }
            return View(adminModel);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,email,senha,ativo,create_at,update_at,permissoes")] AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {
                adminAppService.Update(Mapper.Map<AdminModel, Admin>(adminModel));
                return RedirectToAction("Index");
            }
            return View(adminModel);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminModel adminModel = Mapper.Map<Admin, AdminModel>(adminAppService.GetById(id)); ; ;
            if (adminModel == null)
            {
                return HttpNotFound();
            }
            return View(adminModel);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            adminAppService.Remove(adminAppService.GetById(id));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                adminAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
