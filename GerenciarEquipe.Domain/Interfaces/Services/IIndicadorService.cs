using System.Collections.Generic;
using GerenciarEquipe.Domain.Entities;

namespace GerenciarEquipe.Domain.Interfaces.Services
{
    public interface IIndicadorService : IServiceBase<Indicador>
    {
        ICollection<Indicador> GetAllByLoja(long id_loja);
    }
}
