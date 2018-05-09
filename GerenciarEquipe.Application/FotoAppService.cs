using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Application
{
    public class FotoAppService : AppServiceBase<Foto>, IFotoAppService
    {
        private readonly IFotoService fotoService;
        public FotoAppService(IFotoService fotoService) : base(fotoService)
        {
            this.fotoService = fotoService;
        }
    }
}
