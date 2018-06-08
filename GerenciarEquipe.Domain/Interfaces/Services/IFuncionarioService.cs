using GerenciarEquipe.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarEquipe.Domain.Interfaces.Services
{
    public interface IFuncionarioService:IServiceBase<Funcionario>
    {
        bool Login(Funcionario funcionario);

        Funcionario GetByEmail(string email);

        ICollection<Funcionario> GetAllByLoja(long id_loja);
    }
}
