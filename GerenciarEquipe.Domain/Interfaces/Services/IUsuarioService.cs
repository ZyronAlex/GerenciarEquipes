using GerenciarEquipe.Domain.Entities;

namespace GerenciarEquipe.Domain.Interfaces.Services
{
    public interface IUsuarioService:IServiceBase<Usuario>
    {
        bool Login(Usuario usuario);

        Usuario GetByEmail(string email);
    }
}
