using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Domain.Services
{
    public class FotoService : ServiceBase<Foto>, IFotoService
    {
        private readonly IFotoRepository fotoRepository;
        public FotoService(IFotoRepository fotoRepository) : base(fotoRepository)
        {
            this.fotoRepository = fotoRepository;
        }
    }
}
