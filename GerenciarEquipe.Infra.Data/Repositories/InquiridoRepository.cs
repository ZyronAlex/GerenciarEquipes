using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GerenciarEquipe.Infra.Data.Repositories
{
    public class InquiridoRepository : RepositoryBase<Inquirido>, IInquiridoRepository
    {
        public ICollection<Inquirido> GetByIdMeta(long? id_meta)
        {
            return Getall().Where(i => i.id_meta == id_meta).ToList();
        }

        public ICollection<Inquirido> GetByIdCargo(long? id_cargo)
        {
            return Getall().Where(i => i.id_cargo == id_cargo).ToList();
        }
    }
}
