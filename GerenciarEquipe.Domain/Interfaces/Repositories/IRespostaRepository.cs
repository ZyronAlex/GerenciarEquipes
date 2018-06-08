using GerenciarEquipe.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarEquipe.Domain.Interfaces.Repositories
{
    public interface IRespostaRepository:IRepositoryBase<Resposta>
    {
        ICollection<Resposta> GetAllByFuncionario(long id_funcionario); 
    }
}
