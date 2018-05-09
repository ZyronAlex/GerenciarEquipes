using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Application
{
    public class FuncionarioAppService : AppServiceBase<Funcionario>, IFuncionarioAppService
    {
        private readonly IFuncionarioService funcionarioService;
        public FuncionarioAppService(IFuncionarioService funcionarioService) : base(funcionarioService)
        {
            this.funcionarioService = funcionarioService;
        }
    }
}
