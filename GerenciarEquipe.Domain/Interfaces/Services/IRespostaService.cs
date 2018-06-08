using GerenciarEquipe.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarEquipe.Domain.Interfaces.Services
{
    public interface IRespostaService:IServiceBase<Resposta>
    {
        ICollection<Resposta> GetAllByFuncionario(long id_funcionario);
    }
}
