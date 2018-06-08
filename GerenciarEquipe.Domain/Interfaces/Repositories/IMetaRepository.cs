using GerenciarEquipe.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarEquipe.Domain.Interfaces.Repositories
{
    public interface IMetaRepository : IRepositoryBase<Meta>
    {
        ICollection<Meta> GetAllByLoja(long id_loja);
    }
}
