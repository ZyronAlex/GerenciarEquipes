using GerenciarEquipe.Domain.Entities;

namespace GerenciarEquipe.Application.Interfaces
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        bool Login(Usuario usuario);

        Usuario GetByEmail(string email);
    }
}
