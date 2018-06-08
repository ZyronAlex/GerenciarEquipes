using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GerenciarEquipe.Infra.Data.Repositories
{
    public class IndicadorRepository : RepositoryBase<Indicador>, IIndicadorRepository
    {
        public ICollection<Indicador> GetAllByLoja(long id_loja)
        {
            return Getall().Where(u => u.id_loja == id_loja).ToList();
        }
    }
}
