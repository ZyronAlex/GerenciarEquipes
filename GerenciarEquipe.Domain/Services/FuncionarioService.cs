using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Domain.Services
{
    public class FuncionarioService : ServiceBase<Funcionario>, IFuncionarioService
    {
        private readonly IFuncionarioRepository funcionarioRepository;
        public FuncionarioService(IFuncionarioRepository funcionarioRepository) : base(funcionarioRepository)
        {
            this.funcionarioRepository = funcionarioRepository;
        }

        public Funcionario GetByEmail(string email)
        {
            return funcionarioRepository.GetByEmail(email);
        }

        public bool Login(Funcionario funcionario)
        {
            var f = GetByEmail(funcionario.email);
            return f.Login(funcionario);
        }
    }
}
