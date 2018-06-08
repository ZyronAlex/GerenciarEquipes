using GerenciarEquipe.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarEquipe.Domain.Interfaces.Services
{
    public interface IMetaService : IServiceBase<Meta>
    {
        ICollection<Meta> GetAllByLoja(long id_loja);
    }
}
