using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Application
{
    public class RankAppService : AppServiceBase<Rank>, IRankAppService
    {
        private readonly IRankService rankService;
        public RankAppService(IRankService rankService) : base(rankService)
        {
            this.rankService = rankService;
        }
    }
}
