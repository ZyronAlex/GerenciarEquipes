using GerenciarEquipe.Domain.Entities;

namespace GerenciarEquipe.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository:IRepositoryBase<Funcionario>
    {
        Funcionario GetByEmail(string email);
    }
}
