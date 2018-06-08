using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace GerenciarEquipe.Application
{
    public class IndicadorAppService : AppServiceBase<Indicador>, IIndicadorAppService
    {
        private readonly IIndicadorService indicadorService;
        public IndicadorAppService(IIndicadorService indicadorService) : base(indicadorService)
        {
            this.indicadorService = indicadorService;
        }

        public ICollection<Indicador> GetAllByLoja(long id_loja)
        {
            return indicadorService.GetAllByLoja(id_loja);
        }

    }
}
