using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Application
{
    public class LojaAppService : AppServiceBase<Loja>, ILojaAppService
    {
        private readonly ILojaService lojaService;
        public LojaAppService(ILojaService lojaService) : base(lojaService)
        {
            this.lojaService = lojaService;
        }
    }
}
