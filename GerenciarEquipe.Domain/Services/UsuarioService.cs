using GerenciarEquipe.Domain.Entities;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using GerenciarEquipe.Domain.Interfaces.Services;

namespace GerenciarEquipe.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public Usuario GetByEmail(string email)
        {
            return usuarioRepository.GetByEmail(email);
        }

        public bool Login(Usuario usuario)
        {
            var u = GetByEmail(usuario.email);
            return u.Login(usuario);
        }
    }
}
