using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace GerenciarEquipe.Painel.Models
{
    public abstract class UsuarioModel
    {
        public UsuarioModel()
        {
            fotos = new HashSet<FotoModel>();
        }

        [Key]
        public long id { get; set; }

        [DataType(DataType.Upload)]
        [ScaffoldColumn(true)]
        public HttpPostedFileBase foto { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(300, ErrorMessage = "Máximo caracteres")]
        [MinLength(3, ErrorMessage = "Minimo caracteres")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(300, ErrorMessage = "Máximo caracteres")]
        [MinLength(3, ErrorMessage = "Minimo caracteres")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha")]
        [MinLength(6, ErrorMessage = "Minimo caracteres")]
        [Display(Name = "Senha")]
        public string senha { get; set; }

        [ScaffoldColumn(true)]
        public bool ativo { get; set; }

        [Display(Name = "Data Cadastro")]
        [ScaffoldColumn(true)]
        public DateTime create_at { set; get; }

        [Display(Name = "Data Ultima Alteração")]
        [ScaffoldColumn(true)]
        public DateTime update_at { set; get; }

        public virtual ICollection<FotoModel> fotos { get; set; }

        public bool Login(UsuarioModel usuario)
        {
            if ((string.IsNullOrEmpty(usuario.email) && string.IsNullOrEmpty(usuario.senha)) || this.ativo)
                return false;
            else
                return usuario.email.ToUpper().Trim().Equals(this.email.ToUpper().Trim()) && usuario.senha.Equals(this.senha);
        }
    }
}
