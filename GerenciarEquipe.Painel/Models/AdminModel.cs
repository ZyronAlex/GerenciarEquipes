using System.ComponentModel.DataAnnotations;

namespace GerenciarEquipe.Painel.Models
{
    public partial class AdminModel : UsuarioModel
    {
        public AdminModel()
        {
        }

        public AdminModel(LoginModel loginModel) : base(loginModel)
        {
        }

        [Required(ErrorMessage = "Preencha o campo Permissões")]
        [Display(Name = "Permissões")]
        public string permissoes { get; set; }
    }
}
