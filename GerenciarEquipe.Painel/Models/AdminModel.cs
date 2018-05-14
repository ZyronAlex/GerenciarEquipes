using System.ComponentModel.DataAnnotations;

namespace GerenciarEquipe.Painel.Models
{
    public partial class AdminModel : UsuarioModel
    {
        public AdminModel()
        {

        }

        public AdminModel(LoginModel loginModel)
        {
            this.email = loginModel.email;
            this.senha = loginModel.senha;
        }

        [Required(ErrorMessage = "Preencha o campo Permissões")]
        [Display(Name = "Permissões")]
        public string permissoes { get; set; }
    }
}
