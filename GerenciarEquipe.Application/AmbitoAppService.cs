using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Application
{
    public class AmbitoAppService : AppServiceBase<Ambito>, IAmbitoAppService
    {
        private readonly IAmbitoService ambitoService;
        public AmbitoAppService(IAmbitoService ambitoService) : base(ambitoService)
        {
            this.ambitoService = ambitoService;
        }
    }
}
