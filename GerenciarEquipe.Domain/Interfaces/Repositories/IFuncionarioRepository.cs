using GerenciarEquipe.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarEquipe.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository:IRepositoryBase<Funcionario>
    {
        Funcionario GetByEmail(string email);

        ICollection<Funcionario> GetAllByLoja(long id_loja);
    }
}
