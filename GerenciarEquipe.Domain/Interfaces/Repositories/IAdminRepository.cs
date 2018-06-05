using GerenciarEquipe.Domain.Entities;

namespace GerenciarEquipe.Domain.Interfaces.Repositories
{
    public interface IAdminRepository : IRepositoryBase<Admin>
    {
        Admin GetByEmail(string email);
    }
}
