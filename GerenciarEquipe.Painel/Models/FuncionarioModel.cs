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

        public FuncionarioModel(LoginModel loginModel):base(loginModel)
        {
            ranks = new HashSet<RankModel>();
            respostas = new HashSet<RespostaModel>();
        }      

        [Required(ErrorMessage = "Preencha o campo Matricula")]
        [Display(Name = "Matricula")]
        public long matricula { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]
        public DateTime nascimento { get; set; }

        [Display(Name = "Genero")]
        public Genero? genero { get; set; }

        [Display(Name = "Cidade")]
        public string cidade { get; set; }

        [Display(Name = "Estado")]
        public string estado { get; set; }

        [Display(Name = "Turno")]
        public Turno? turno { get; set; }

        [Display(Name = "Cargo")]
        [ScaffoldColumn(false)]
        public long id_cargo { get; set; }

        [Display(Name = "Loja")]
        [ScaffoldColumn(false)]
        public long id_loja {get; set;}

        public virtual LojaModel loja { get; set; }
        public virtual CargoModel cargo { get; set; }
        public virtual ICollection<RankModel> ranks { get; set; }
        public virtual ICollection<RespostaModel> respostas { get; set;}
    }
}
