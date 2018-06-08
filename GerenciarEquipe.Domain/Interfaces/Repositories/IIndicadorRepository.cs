using GerenciarEquipe.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarEquipe.Domain.Interfaces.Repositories
{
    public interface IIndicadorRepository : IRepositoryBase<Indicador>
    {
        ICollection<Indicador> GetAllByLoja(long id_loja);
    }
}
