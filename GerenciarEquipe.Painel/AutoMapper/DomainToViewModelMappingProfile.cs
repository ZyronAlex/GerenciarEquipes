﻿using AutoMapper;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Painel.Models;

namespace GerenciarEquipe.Painel.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Admin, AdminModel>();
            CreateMap<Ambito, AmbitoModel>();
            CreateMap<Cargo, CargoModel>();
            CreateMap<Funcionario, FuncionarioModel>();
            CreateMap<Indicador, IndicadorModel>();
            CreateMap<Loja, LojaModel>();
            CreateMap<Meta, MetaModel>();
            CreateMap<Rank, RankModel>();
            CreateMap<Resposta, RespostaModel>();
            CreateMap<Usuario, UsuarioModel>()
                .Include<Admin, AdminModel>()
                .Include<Funcionario, FuncionarioModel>();
        }
    }
}