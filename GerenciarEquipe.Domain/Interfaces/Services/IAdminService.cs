using GerenciarEquipe.Domain.Entities;

namespace GerenciarEquipe.Domain.Interfaces.Services
{
    public interface IAdminService : IServiceBase<Admin>
    {
        bool Login(Admin admin);

        Admin GetByEmail(string email);
    }
}
