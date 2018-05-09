using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Domain.Services
{
    public class LojaService : ServiceBase<Loja>, ILojaService
    {
        private readonly ILojaRepository lojaRepository;
        public LojaService(ILojaRepository lojaRepository) : base(lojaRepository)
        {
            this.lojaRepository = lojaRepository;
        }
    }
}
