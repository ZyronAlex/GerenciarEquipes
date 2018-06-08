using System.Collections.Generic;
using GerenciarEquipe.Domain.Entities;

namespace GerenciarEquipe.Application.Interfaces
{
    public interface IIndicadorAppService : IAppServiceBase<Indicador>
    {
        ICollection<Indicador> GetAllByLoja(long id_loja);
    }
}
