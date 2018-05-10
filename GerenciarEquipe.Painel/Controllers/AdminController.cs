using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GerenciarEquipe.Painel.Models;

namespace GerenciarEquipe.Painel.Controllers
{
    public class AdminController : Controller
    {
        private GerenciarEquipePainelContext db = new GerenciarEquipePainelContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.UsuarioModels.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminModel adminModel = db.UsuarioModels.Find(id);
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
                db.UsuarioModels.Add(adminModel);
                db.SaveChanges();
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
            AdminModel adminModel = db.UsuarioModels.Find(id);
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
                db.Entry(adminModel).State = EntityState.Modified;
                db.SaveChanges();
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
            AdminModel adminModel = db.UsuarioModels.Find(id);
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
            AdminModel adminModel = db.UsuarioModels.Find(id);
            db.UsuarioModels.Remove(adminModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
