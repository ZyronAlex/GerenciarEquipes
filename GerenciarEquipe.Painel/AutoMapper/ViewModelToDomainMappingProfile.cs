using AutoMapper;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Painel.Models;

namespace GerenciarEquipe.Painel.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AdminModel, Admin>();
            CreateMap<AmbitoModel, Ambito>();
            CreateMap<CargoModel, Cargo>();
            CreateMap<FotoModel, Foto>();
            CreateMap<FuncionarioModel, Funcionario>();
            CreateMap<IndicadorModel, Indicador>();
            CreateMap<LojaModel, Loja>();
            CreateMap<MetaModel, Meta>();
            CreateMap<RankModel, Rank>();
            CreateMap<RespostaModel, Resposta>();
            CreateMap<UsuarioModel, Usuario>();
        }
    }
}