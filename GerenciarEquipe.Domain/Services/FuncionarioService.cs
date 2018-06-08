using System.Collections.Generic;
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

        public ICollection<Funcionario> GetAllByLoja(long id_loja)
        {
            return funcionarioRepository.GetAllByLoja(id_loja);
        }

        public Funcionario GetByEmail(string email)
        {
            return funcionarioRepository.GetByEmail(email);
        }
        
        public bool Login(Funcionario funcionario)
        {
            var f = GetByEmail(funcionario.email);
            return f != null && f.Login(funcionario);
        }
    }
}
