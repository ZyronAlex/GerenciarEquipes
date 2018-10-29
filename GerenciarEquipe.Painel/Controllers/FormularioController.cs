using AutoMapper;
using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Painel.Models;
using GerenciarEquipe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciarEquipe.Painel.Controllers
{
    [CustomAuthorize(Roles = "Admin,Forms")]
    public class FormularioController : Controller
    {
        private readonly IMetaAppService metaAppService;
        private readonly IIndicadorAppService indicadorAppService;
        private readonly IRespostaAppService respostaAppService;
        private readonly IInquiridoAppService inquiridoAppService;
        private readonly IAmbitoAppService ambitoAppService;

        public FormularioController(IMetaAppService metaAppService, IIndicadorAppService indicadorAppService,
        IRespostaAppService respostaAppService, IInquiridoAppService inquiridoAppService, IAmbitoAppService ambitoAppService)
        {
            this.metaAppService = metaAppService;
            this.indicadorAppService = indicadorAppService;
            this.respostaAppService = respostaAppService;
            this.inquiridoAppService = inquiridoAppService;
            this.ambitoAppService = ambitoAppService;
        }

        // GET: Formulario
        public ActionResult Index()
        {
            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];
            if (usuarioModel is AdminModel)
                return View(Mapper.Map<ICollection<Inquirido>, ICollection<InquiridoModel>>(inquiridoAppService.Getall()));
            if (usuarioModel is FuncionarioModel)
                return View(Mapper.Map<ICollection<Inquirido>, ICollection<InquiridoModel>>(inquiridoAppService.GetByIdCargo(((FuncionarioModel)usuarioModel).id_cargo)));
            else
                return View(new List<InquiridoModel>());
        }

        public ActionResult Responder(long? id_meta, int? pageIndex, RespostaModel respostaModel)
        {
            UsuarioModel usuarioModel = (UsuarioModel)Session["Usuario"];

            if (id_meta != null)
            {
                MetaModel metaModel = Mapper.Map<Meta, MetaModel>(metaAppService.GetById(id_meta));
                List<RespostaModel> respostas = new List<RespostaModel>();

                if (respostaModel.resultado != null)
                {
                    respostaAppService.Add(Mapper.Map<RespostaModel, Resposta>(respostaModel));
                }
                if (metaModel.terceiros)
                {
                    List<AmbitoModel> ambitos = Mapper.Map<ICollection<Ambito>, ICollection<AmbitoModel>>(ambitoAppService.GetByIdMeta(id_meta)).ToList();
                    List<CargoModel> cargos = new List<CargoModel>();

                    foreach (var ambito in ambitos)
                        cargos.Add(ambito.cargo);
                    foreach (var cargo in cargos)
                        foreach (var funcionario in cargo.funcionarios)
                        {
                            respostas.Add(new RespostaModel
                            {
                                autor = usuarioModel.id,
                                id_funcionario = funcionario.id,
                                id_meta = (long)id_meta,
                                funcionario = funcionario,
                                meta = metaModel,
                                create_at = DateTime.Now
                            });
                        }


                    return View(PaginatedList<RespostaModel>.Create(respostas, pageIndex ?? 0, 1, 5));
                }
                else if (!metaModel.terceiros && respostaModel.resultado == null)
                {
                    respostas.Add(new RespostaModel
                    {
                        autor = usuarioModel.id,
                        id_funcionario = usuarioModel.id,
                        id_meta = (long)id_meta,
                        funcionario = Mapper.Map<UsuarioModel, FuncionarioModel>(usuarioModel),
                        meta = metaModel,
                        create_at = DateTime.Now
                    });
                    return View(PaginatedList<RespostaModel>.Create(respostas, pageIndex ?? 0, 1, 5));
                }
            }
            return View(PaginatedList<RespostaModel>.Create(new List<RespostaModel>(), pageIndex ?? 0, 1, 5));
        }
    }
}