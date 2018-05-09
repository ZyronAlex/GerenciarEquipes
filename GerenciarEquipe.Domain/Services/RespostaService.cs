using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Domain.Services
{
    public class RespostaService : ServiceBase<Resposta>, IRespostaService
    {
        private readonly IRespostaRepository respostaRepository;
        public RespostaService(IRespostaRepository respostaRepository) : base(respostaRepository)
        {
            this.respostaRepository = respostaRepository;
        }
    }
}
