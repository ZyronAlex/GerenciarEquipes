using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using System.Linq;

namespace GerenciarEquipe.Infra.Data.Repositories
{
    public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
    {
        public Admin GetByEmail(string email)
        {
            return Getall().First(u => u.email == email);
        }
    }
}
