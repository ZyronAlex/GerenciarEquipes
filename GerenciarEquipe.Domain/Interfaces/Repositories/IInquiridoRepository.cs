using GerenciarEquipe.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarEquipe.Domain.Interfaces.Repositories
{
    public interface IInquiridoRepository : IRepositoryBase<Inquirido>
    {
        ICollection<Inquirido> GetByIdMeta(long? id_meta);

        ICollection<Inquirido> GetByIdCargo(long? id_cargo);
    }
}
