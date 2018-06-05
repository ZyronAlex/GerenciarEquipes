﻿using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Application
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService usuarioService;
        public UsuarioAppService(IUsuarioService usuarioService) : base(usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        public Usuario GetByEmail(string email)
        {
            return usuarioService.GetByEmail(email);
        }

        public bool Login(Usuario usuario)
        {
            return usuarioService.Login(usuario);
        }
    }
}
