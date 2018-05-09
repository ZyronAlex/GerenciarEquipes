using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Application
{
    public class IndicadorAppService : AppServiceBase<Indicador>, IIndicadorAppService
    {
        private readonly IIndicadorService indicadorService;
        public IndicadorAppService(IIndicadorService indicadorService) : base(indicadorService)
        {
            this.indicadorService = indicadorService;
        }
    }
}
