using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Domain.Services
{
    public class RankService : ServiceBase<Rank>, IRankService
    {
        private readonly IRankRepository rankRepository;
        public RankService(IRankRepository rankRepository) : base(rankRepository)
        {
            this.rankRepository = rankRepository;
        }
    }
}
