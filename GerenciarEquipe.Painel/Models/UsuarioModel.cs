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
                
        }
        public UsuarioModel(LoginModel loginModel)
        {
            this.email = loginModel.email;
            this.senha = loginModel.senha;
        }

        [Key]
        public long id { get; set; }       

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

        [ScaffoldColumn(false)]
        public bool ativo { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Cadastro")]
        [ScaffoldColumn(false)]
        public DateTime create_at { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Ultima Alteração")]
        [ScaffoldColumn(false)]
        public DateTime update_at { set; get; }

        [DataType(DataType.Upload)]
        [ScaffoldColumn(false)]
        public HttpPostedFileBase fotoFile { get; set; }

        [Display(Name ="Foto")]
        public string foto { get; set; }

    }
}
