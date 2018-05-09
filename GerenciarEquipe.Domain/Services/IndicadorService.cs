using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Domain.Services
{
    public class IndicadorService : ServiceBase<Indicador>, IIndicadorService
    {
        private readonly IIndicadorRepository indicadorRepository;
        public IndicadorService(IIndicadorRepository indicadorRepository) : base(indicadorRepository)
        {
            this.indicadorRepository = indicadorRepository;
        }
    }
}
