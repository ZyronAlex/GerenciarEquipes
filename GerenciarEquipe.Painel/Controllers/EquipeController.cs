using GerenciarEquipe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }

        // GET: Equipe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Equipe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipe/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Equipe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Equipe/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Equipe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Equipe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
