using GerenciarEquipe.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarEquipe.Domain.Interfaces.Repositories
{
    public interface ICargoRepository : IRepositoryBase<Cargo>
    {
        ICollection<Cargo> GetAllByLoja(long id_loja);
    }
}
