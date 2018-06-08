using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GerenciarEquipe.Infra.Data.Repositories
{
    public class MetaRepository : RepositoryBase<Meta>, IMetaRepository 
    {
        public ICollection<Meta> GetAllByLoja(long id_loja)
        {
            return Getall().Where(u => u.id_loja == id_loja).ToList();
        }
    }
}
