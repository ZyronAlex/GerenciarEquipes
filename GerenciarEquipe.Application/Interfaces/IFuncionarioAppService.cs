using System.Collections.Generic;
using GerenciarEquipe.Domain.Entities;

namespace GerenciarEquipe.Application.Interfaces
{
    public interface IFuncionarioAppService: IAppServiceBase<Funcionario>
    {
        bool Login(Funcionario funcionario);

        Funcionario GetByEmail(string email);

        ICollection<Funcionario> GetAllByLoja(long id_loja);
    }
}
