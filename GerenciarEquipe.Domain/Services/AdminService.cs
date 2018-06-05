using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Domain.Services
{
    public class AdminService : ServiceBase<Admin>, IAdminService
    {
        private readonly IAdminRepository adminRepository;
        public AdminService(IAdminRepository adminRepository) : base(adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        public Admin GetByEmail(string email)
        {
            return adminRepository.GetByEmail(email);
        }

        public bool Login(Admin admin)
        {
            var a = GetByEmail(admin.email);
            return a.Login(admin);
        }
    }
}
