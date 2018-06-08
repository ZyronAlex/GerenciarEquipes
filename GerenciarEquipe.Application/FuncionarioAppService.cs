using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace GerenciarEquipe.Application
{
    public class FuncionarioAppService : AppServiceBase<Funcionario>, IFuncionarioAppService
    {
        private readonly IFuncionarioService funcionarioService;
        public FuncionarioAppService(IFuncionarioService funcionarioService) : base(funcionarioService)
        {
            this.funcionarioService = funcionarioService;
        }

        public Funcionario GetByEmail(string email)
        {
            return funcionarioService.GetByEmail(email);
        }

        public ICollection<Funcionario> GetAllByLoja(long id_loja)
        {
            return funcionarioService.GetAllByLoja(id_loja);
        }

        public bool Login(Funcionario funcionario)
        {
            return funcionarioService.Login(funcionario);
        }
    }
}
