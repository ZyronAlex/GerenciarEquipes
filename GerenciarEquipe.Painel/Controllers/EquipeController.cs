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
    public class EquipeController : Controller
    {
        private readonly IFuncionarioAppService funcionarioAppService;
        public EquipeController(IFuncionarioAppService funcionarioAppService)
        {
            this.funcionarioAppService = funcionarioAppService;
        }

        // GET: Equipe
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("index", "login");
            return View(new List<FuncionarioModel>());
        }

        // GET: Equipe/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuncionarioModel funcionarioModel = null;
            if (funcionarioModel == null)
            {
                return HttpNotFound();
            }
            return View(funcionarioModel);
        }

        // GET: Equipe/Create
        public ActionResult Create()
        {
            ViewBag.Genero = new SelectList(new List<string>(new string[]{"Masculino","Femninio"}));
            ViewBag.Turno = new SelectList(new List<string>(new string[] {"Matutino","Vespertino","Noturno","Sembrol"}));
            ViewBag.Incicador = new SelectList(new List<IndicadorModel>(), "id", "nome");

            return View();
        }

        // POST: Equipe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,email,senha,ativo,create_at,update_at,matricula,nascimento,genero,cidade,estado,turno,id_cargo,id_loja")] FuncionarioModel funcionarioModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(funcionarioModel);
        }

        // GET: Equipe/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuncionarioModel funcionarioModel = null;
            if (funcionarioModel == null)
            {
                return HttpNotFound();
            }
            return View(funcionarioModel);
        }

        // POST: Equipe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,email,senha,ativo,create_at,update_at,matricula,nascimento,genero,cidade,estado,turno,id_cargo,id_loja")] FuncionarioModel funcionarioModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(funcionarioModel);
        }

        // GET: Equipe/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuncionarioModel funcionarioModel = null;
            if (funcionarioModel == null)
            {
                return HttpNotFound();
            }
            return View(funcionarioModel);
        }

        // POST: Equipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FuncionarioModel funcionarioModel = null;
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
