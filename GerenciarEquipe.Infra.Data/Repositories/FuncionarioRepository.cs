using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GerenciarEquipe.Infra.Data.Repositories
{
    public class FuncionarioRepository : RepositoryBase<Funcionario>, IFuncionarioRepository
    {
        public ICollection<Funcionario> GetAllByLoja(long id_loja)
        {
            return Getall().Where(u => u.id_loja == id_loja).ToList();
        }

        public Funcionario GetByEmail(string email)
        {
            return Getall().FirstOrDefault(u => u.email == email);
        }
    }
}
