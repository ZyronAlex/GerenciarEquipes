using GerenciarEquipe.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarEquipe.Domain.Interfaces.Repositories
{
    public interface IAmbitoRepository : IRepositoryBase<Ambito>
    {
        ICollection<Ambito> GetByIdMeta(long? id_meta);

        ICollection<Ambito> GetByIdCargo(long? id_cargo);
    }
}
