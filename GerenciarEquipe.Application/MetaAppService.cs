using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Application
{
    public class MetaAppService : AppServiceBase<Meta>, IMetaAppService
    {
        private readonly IMetaService metaService;
        public MetaAppService(IMetaService metaService) : base(metaService)
        {
            this.metaService = metaService;
        }
    }
}
