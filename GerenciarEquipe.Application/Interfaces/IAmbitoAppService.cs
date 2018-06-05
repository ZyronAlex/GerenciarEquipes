using System.Collections.Generic;
using GerenciarEquipe.Domain.Entities;

namespace GerenciarEquipe.Application.Interfaces
{
    public interface IAmbitoAppService : IAppServiceBase<Ambito>
    {
        ICollection<Ambito> GetByIdMeta(long? id_meta);

        ICollection<Ambito> GetByIdCargo(long? id_cargo);
    }
}
