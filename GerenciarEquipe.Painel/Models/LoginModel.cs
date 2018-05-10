using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciarEquipe.Painel.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(300, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(3, ErrorMessage = "Minimo {0} caracteres")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha")]
        [MinLength(6, ErrorMessage = "Minimo {0} caracteres")]
        [Display(Name = "Senha")]
        public string senha { get; set; }

    }
}