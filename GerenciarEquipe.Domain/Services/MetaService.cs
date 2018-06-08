using System.Collections.Generic;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Domain.Services
{
    public class MetaService : ServiceBase<Meta>, IMetaService
    {
        private readonly IMetaRepository metaRepository;
        public MetaService(IMetaRepository metaRepository) : base(metaRepository)
        {
            this.metaRepository = metaRepository;
        }

        public ICollection<Meta> GetAllByLoja(long id_loja)
        {
            return metaRepository.GetAllByLoja(id_loja);
        }
    }
}
