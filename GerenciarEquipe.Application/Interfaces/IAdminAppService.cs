using GerenciarEquipe.Domain.Entities;

namespace GerenciarEquipe.Application.Interfaces
{
    public interface IAdminAppService : IAppServiceBase<Admin>
    {
        bool Login(Admin admin);

        Admin GetByEmail(string email);
    }
}
