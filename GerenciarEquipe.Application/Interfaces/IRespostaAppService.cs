using GerenciarEquipe.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarEquipe.Application.Interfaces
{
    public interface IRespostaAppService : IAppServiceBase<Resposta>
    {
        ICollection<Resposta> GetAllByFuncionario(long id_funcionario);
    }
}
