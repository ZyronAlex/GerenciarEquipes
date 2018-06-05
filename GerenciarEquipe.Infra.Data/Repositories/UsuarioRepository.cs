using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using System.Linq;

namespace GerenciarEquipe.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario GetByEmail(string email)
        {
            return Getall().First(u => u.email == email);
        }
    }
}
