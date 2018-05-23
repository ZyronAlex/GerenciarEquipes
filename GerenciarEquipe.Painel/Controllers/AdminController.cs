using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
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
        public ActionResult Create([Bind(Include = "id,nome,email,senha,ativo,fotoFile,permissoes")] AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {
                if (adminModel.fotoFile != null && adminModel.fotoFile.ContentLength != 0)
                {
                    var extencao = adminModel.fotoFile.FileName.Split('.').Last();
                    string fileName = ((long)DateTime.Now.Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds).ToString() + "." + extencao;
                    string savedFileName = Path.Combine(
                        HostingEnvironment.MapPath("~/AdminFotos/"),
                       Path.GetFileName(fileName));

                    FileInfo Local = new FileInfo(savedFileName);
                    Local.Directory.Create(); // If the directory

                    adminModel.fotoFile.SaveAs(savedFileName);
                    adminModel.foto = GetBaseUrl() + "/AdminFotos/" + fileName;
                }
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
        public ActionResult Edit([Bind(Include = "id,nome,email,senha,ativo,fotoFile,permissoes")] AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {
                if (adminModel.fotoFile != null && adminModel.fotoFile.ContentLength != 0)
                {
                    string fileName;
                    FileInfo Local;
                    if (adminModel.foto != null)
                    {
                        fileName = Path.Combine(HostingEnvironment.MapPath("~/AdminFotos/"), Path.GetFileName(adminModel.foto.Split('/').Last()));
                        Local = new FileInfo(fileName);
                        if (Local.Exists)
                            Local.Delete();
                    }
                    var extencao = adminModel.fotoFile.FileName.Split('.').Last();
                    fileName = ((long)DateTime.Now.Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds).ToString() + "." + extencao;
                    string savedFileName = Path.Combine(
                        HostingEnvironment.MapPath("~/AdminFotos/"),
                       Path.GetFileName(fileName));

                    Local = new FileInfo(savedFileName);
                    Local.Directory.Create(); // If the directory

                    adminModel.fotoFile.SaveAs(savedFileName);
                    adminModel.foto = GetBaseUrl() + "/AdminFotos/" + fileName;
                }
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

        private string GetBaseUrl()
        {
            var request = HttpContext.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;

            if (appUrl != "/")
                appUrl = "/" + appUrl;

            var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return baseUrl;
        }
    }
}
