using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GerenciarEquipe.Infra.Data.Repositories
{
    public class AmbitoRepository : RepositoryBase<Ambito>, IAmbitoRepository
    {
        public ICollection<Ambito> GetByIdMeta(long? id_meta)
        {
            return Getall().Where(a => a.id_meta == id_meta).ToList();
        }

        public ICollection<Ambito> GetByIdCargo(long? id_cargo)
        {
            return Getall().Where(a => a.id_cargo == id_cargo).ToList();
        }
    }
}
