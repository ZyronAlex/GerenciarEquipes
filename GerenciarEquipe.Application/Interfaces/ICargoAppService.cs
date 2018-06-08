using System.Collections.Generic;
using GerenciarEquipe.Domain.Entities;

namespace GerenciarEquipe.Application.Interfaces
{
    public interface ICargoAppService : IAppServiceBase<Cargo>
    {
        ICollection<Cargo> GetAllByLoja(long id_loja);
    }
}
