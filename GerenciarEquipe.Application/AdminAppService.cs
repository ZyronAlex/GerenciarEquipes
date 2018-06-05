﻿using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Application
{
    public class AdminAppService : AppServiceBase<Admin>, IAdminAppService
    {
        private readonly IAdminService adminService;
        public AdminAppService(IAdminService adminService) : base(adminService)
        {
            this.adminService = adminService;
        }

        public Admin GetByEmail(string email)
        {
            return adminService.GetByEmail(email);
        }

        public bool Login(Admin admin)
        {
            return adminService.Login(admin);
        }
    }
}
