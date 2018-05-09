using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Services;


namespace GerenciarEquipe.Application
{
    public class RespostaAppService : AppServiceBase<Resposta>, IRespostaAppService
    {
        private readonly IRespostaService respostaService;
        public RespostaAppService(IRespostaService respostaService) : base(respostaService)
        {
            this.respostaService = respostaService;
        }
    }
}
