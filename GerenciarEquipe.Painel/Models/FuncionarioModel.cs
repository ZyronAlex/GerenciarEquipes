using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciarEquipe.Painel.Models
{
    public partial class FuncionarioModel : UsuarioModel
    {
        public FuncionarioModel()
        {
            ranks = new HashSet<RankModel>();
            respostas = new HashSet<RespostaModel>();
        }  

        public FuncionarioModel(LoginModel loginModel)
        {
            this.email = loginModel.email;
            this.senha = loginModel.senha;
            ranks = new HashSet<RankModel>();
            respostas = new HashSet<RespostaModel>();
        }

        [Key]
        public long id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Matricula")]
        [Display(Name = "Matricula")]
        public long matricula { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime nascimento { get; set; }

        [Display(Name = "Genero")]
        public string genero { get; set; }

        [Display(Name = "Cidade")]
        public string cidade { get; set; }

        [Display(Name = "Estado")]
        public string estado { get; set; }

        [Display(Name = "Turno")]
        public string turno { get; set; }

        [ScaffoldColumn(true)]
        public long id_cargo { get; set; }

        [ScaffoldColumn(true)]
        public long id_loja {get; set;}

        public virtual LojaModel loja { get; set; }
        public virtual CargoModel cargo { get; set; }
        public virtual ICollection<RankModel> ranks { get; set; }
        public virtual ICollection<RespostaModel> respostas { get; set;}

    }
}
