using System.Collections.Generic;
using GerenciarEquipe.Domain.Entities;

namespace GerenciarEquipe.Domain.Interfaces.Services
{
    public interface ICargoService : IServiceBase<Cargo>
    {
        ICollection<Cargo> GetAllByLoja(long id_loja);
    }
}
