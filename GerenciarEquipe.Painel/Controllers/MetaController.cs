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
    [CustomAuthorize(Roles = "Admin,Goal")]
    public class MetaController : Controller
    {
        private readonly IMetaAppService metaAppService;
        private readonly IAmbitoAppService ambitoAppService;
        private readonly IInquiridoAppService inquiridoAppService;
        private readonly ICargoAppService cargoAppService;
        private readonly IIndicadorAppService indicadorAppService;
        private readonly ILojaAppService lojaAppService;

        private ICollection<Cargo> cargos;

        public MetaController(IMetaAppService metaAppService, IAmbitoAppService ambitoAppService, IInquiridoAppService inquiridoAppService, ICargoAppService cargoAppService, IIndicadorAppService indicadorAppService, ILojaAppService lojaAppService)
        {
            this.metaAppService = metaAppService;
            this.ambitoAppService = ambitoAppService;
            this.inquiridoAppService = inquiridoAppService;
            this.cargoAppService = cargoAppService;
            this.indicadorAppService = indicadorAppService;
            this.lojaAppService = lojaAppService;
            cargos = cargoAppService.Getall();
        }

        // GET: Meta
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];
            if (usuarioModel is AdminModel)
                return View(Mapper.Map<ICollection<Meta>, ICollection<MetaModel>>(metaAppService.Getall()));
            if (usuarioModel is FuncionarioModel)
                return View(Mapper.Map<ICollection<Meta>, ICollection<MetaModel>>(metaAppService.GetAllByLoja(((FuncionarioModel) usuarioModel).id_loja)));
            else
                return View(new List<MetaModel>());          
        }

        // GET: Meta/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaModel metaModel = Mapper.Map<Meta, MetaModel>(metaAppService.GetById(id));
            if (metaModel == null)
            {
                return HttpNotFound();
            }
            return View(metaModel);
        }

        // GET: Meta/Create
        public ActionResult Create()
        {
            ViewBag.Indicador = new SelectList(Mapper.Map<ICollection<Indicador>, ICollection<IndicadorModel>>(indicadorAppService.Getall()), "id", "nome");
            ViewBag.CargoAmbitos = new MultiSelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargos), "id", "nome");
            ViewBag.CargoInquiridos = new MultiSelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargos), "id", "nome");
            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];
            if (usuarioModel is FuncionarioModel)
            {
                MetaModel metaModel = new MetaModel
                {
                    id_loja = ((FuncionarioModel)usuarioModel).id_loja
                };
                return View(metaModel);
            }
            else
            {
                ViewBag.Loja = new MultiSelectList(Mapper.Map<ICollection<Loja>, ICollection<LojaModel>>(lojaAppService.Getall()), "id", "nome");
                return View();
            }
        }

        // POST: Meta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descicao,objetivo,objetivo_parcial,objetivo_parcial_dia,unidade,referencia,fonte,grupo,peso,terceiros,id_indicador,id_loja,cargoAmbitos,cargoInquiridos")] MetaModel metaModel)
        {
            if (ModelState.IsValid)
            {
                var funcionarios = 0;
                metaModel.cargoAmbitos.ForEach(x => funcionarios += cargoAppService.GetById(x).funcionarios.Count());
                metaModel.objetivo_parcial = (float.Parse(metaModel.objetivo) / (funcionarios != 0 ? funcionarios : 1)).ToString();
                metaModel.objetivo_parcial_dia = (float.Parse(metaModel.objetivo_parcial) / DiasMes.diasUteis(DateTime.Now)).ToString();

                metaAppService.Update(Mapper.Map<MetaModel, Meta>(metaModel));
                Meta meta = Mapper.Map<MetaModel, Meta>(metaModel);
                metaAppService.Add(meta);
                foreach (var item in metaModel.cargoAmbitos)
                {
                    Ambito ambito = new Ambito
                    {
                        id_cargo = item,
                        id_meta = meta.id
                    };
                    ambitoAppService.AddOrUpdate(ambito);
                }
                foreach (var item in metaModel.cargoInquiridos)
                {
                    Inquirido inquirido = new Inquirido
                    {
                        id_cargo = item,
                        id_meta = meta.id
                    };
                    inquiridoAppService.AddOrUpdate(inquirido);
                }
                return RedirectToAction("Index");
            }
            ViewBag.Indicador = new SelectList(Mapper.Map<ICollection<Indicador>, ICollection<IndicadorModel>>(indicadorAppService.Getall()), "id", "nome");
            ViewBag.CargoAmbitos = new MultiSelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargos), "id", "nome", metaModel.cargoAmbitos);
            ViewBag.CargoInquiridos = new MultiSelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargos), "id", "nome", metaModel.cargoInquiridos);
            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];
            if (usuarioModel is AdminModel)
                ViewBag.Loja = new MultiSelectList(Mapper.Map<ICollection<Loja>, ICollection<LojaModel>>(lojaAppService.Getall()), "id", "nome");
                
            return View(metaModel);
        }

        // GET: Meta/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaModel metaModel = Mapper.Map<Meta, MetaModel>(metaAppService.GetById(id));
            if (metaModel == null)
            {
                return HttpNotFound();
            }
            foreach (var item in metaModel.ambitos)
            {
                metaModel.cargoAmbitos.Add(item.id_cargo);
            }
            foreach (var item in metaModel.inquiridos)
            {
                metaModel.cargoInquiridos.Add(item.id_cargo);
            }
            ViewBag.Indicador = new SelectList(Mapper.Map<ICollection<Indicador>, ICollection<IndicadorModel>>(indicadorAppService.Getall()), "id", "nome");
            ViewBag.CargoAmbitos = new MultiSelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargos), "id", "nome", metaModel.cargoAmbitos);
            ViewBag.CargoInquiridos = new MultiSelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargos), "id", "nome", metaModel.cargoInquiridos);
            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];
            if (usuarioModel is AdminModel)
                ViewBag.Loja = new MultiSelectList(Mapper.Map<ICollection<Loja>, ICollection<LojaModel>>(lojaAppService.Getall()), "id", "nome");
            return View(metaModel);
        }

        // POST: Meta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descicao,objetivo,objetivo_parcial,objetivo_parcial_dia,unidade,referencia,fonte,grupo,peso,terceiros,id_indicador,id_loja,cargoAmbitos,cargoInquiridos")] MetaModel metaModel)
        {
            if (ModelState.IsValid)
            {
                var funcionarios = 0;
                metaModel.cargoAmbitos.ForEach(x => funcionarios += cargoAppService.GetById(x).funcionarios.Count());
                metaModel.objetivo_parcial =  (float.Parse(metaModel.objetivo) / (funcionarios != 0 ? funcionarios : 1)).ToString();
                metaModel.objetivo_parcial_dia = (float.Parse(metaModel.objetivo_parcial)/DiasMes.diasUteis(DateTime.Now)).ToString();
                metaAppService.Update(Mapper.Map<MetaModel, Meta>(metaModel));

                foreach (var item in ambitoAppService.GetByIdMeta(metaModel.id))
                {
                    if (!metaModel.cargoAmbitos.Contains(item.id_cargo))
                        ambitoAppService.Remove(item);
                }

                foreach (var item in inquiridoAppService.GetByIdMeta(metaModel.id)) 
                {
                    if (!metaModel.cargoInquiridos.Contains(item.id_cargo))
                        inquiridoAppService.Remove(item);
                }

                foreach (var item in metaModel.cargoAmbitos)
                {
                    Ambito ambito = new Ambito
                    {
                        id_cargo = item,
                        id_meta = metaModel.id
                    };
                    ambitoAppService.AddIfNotExists(ambito, a => a.id_cargo == ambito.id_cargo && a.id_meta == metaModel.id);
                }

                foreach (var item in metaModel.cargoInquiridos)
                {
                    Inquirido inquirido = new Inquirido
                    {
                        id_cargo = item,
                        id_meta = metaModel.id
                    };
                    inquiridoAppService.AddIfNotExists(inquirido, i => i.id_cargo == inquirido.id_cargo && i.id_meta == metaModel.id);
                }

                

                return RedirectToAction("Index");
            }

            ViewBag.Indicador = new SelectList(Mapper.Map<ICollection<Indicador>, ICollection<IndicadorModel>>(indicadorAppService.Getall()), "id", "nome");
            ViewBag.CargoAmbitos = new MultiSelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargos), "id", "nome", metaModel.cargoAmbitos);
            ViewBag.CargoInquiridos = new MultiSelectList(Mapper.Map<ICollection<Cargo>, ICollection<CargoModel>>(cargos), "id", "nome", metaModel.cargoInquiridos);
            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];
            if (usuarioModel is AdminModel)
                ViewBag.Loja = new MultiSelectList(Mapper.Map<ICollection<Loja>, ICollection<LojaModel>>(lojaAppService.Getall()), "id", "nome");
            return View(metaModel);
        }

        // GET: Meta/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetaModel metaModel = Mapper.Map<Meta, MetaModel>(metaAppService.GetById(id));
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
            metaAppService.Remove(metaAppService.GetById(id));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                metaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
