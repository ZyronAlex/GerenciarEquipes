using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GerenciarEquipe.Infra.Data.Repositories
{
    public class RespostaRepository : RepositoryBase<Resposta>, IRespostaRepository
    {
        public ICollection<Resposta> GetAllByFuncionario(long id_funcionario)
        {
            return Getall().Where(u => u.id_funcionario == id_funcionario).ToList();
        }
    }
}
