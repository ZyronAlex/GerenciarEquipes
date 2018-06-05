using System.Collections.Generic;
using GerenciarEquipe.Domain.Entities;

namespace GerenciarEquipe.Application.Interfaces
{
    public interface IInquiridoAppService : IAppServiceBase<Inquirido>
    {
        ICollection<Inquirido> GetByIdMeta(long? id_meta);

        ICollection<Inquirido> GetByIdCargo(long? id_cargo);
    }
}
