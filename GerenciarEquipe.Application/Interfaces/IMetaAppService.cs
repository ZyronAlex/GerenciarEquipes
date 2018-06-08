using System.Collections.Generic;
using GerenciarEquipe.Domain.Entities;

namespace GerenciarEquipe.Application.Interfaces
{
    public interface IMetaAppService : IAppServiceBase<Meta>
    {
        ICollection<Meta> GetAllByLoja(long id_loja);
    }
}
