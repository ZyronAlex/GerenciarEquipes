using GerenciarEquipe.Domain.Entities;

namespace GerenciarEquipe.Domain.Interfaces.Services
{
    public interface IFuncionarioService:IServiceBase<Funcionario>
    {
        bool Login(Funcionario funcionario);

        Funcionario GetByEmail(string email);
    }
}
