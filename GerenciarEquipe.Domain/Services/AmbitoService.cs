using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Domain.Services
{
    public class AmbitoService : ServiceBase<Ambito>, IAmbitoService
    {
        private readonly IAmbitoRepository ambitoRepository;
        public AmbitoService(IAmbitoRepository ambitoRepository) : base(ambitoRepository)
        {
            this.ambitoRepository = ambitoRepository;
        }
    }
}
