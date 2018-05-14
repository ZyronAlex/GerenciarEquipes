using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GerenciarEquipe.Painel.Models
{
    public partial class MetaModel
    {
        public MetaModel()
        {
            ambitos = new HashSet<AmbitoModel>();
            respostas = new HashSet<RespostaModel>();
        }

        [Key]
        public long id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [AllowHtml]
        [Display(Name = "Descrição")]
        public string descicao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Objetivo")]
        [Display(Name = "Objetivo")]
        public string objetivo { get; set; }

        [Display(Name = "Objetivo Parcial")]
        public string objetivo_parcial { get; set; }

        [Display(Name = "Objetivo Parcial Diário")]
        public string objetivo_parcial_dia { get; set; }

        [Display(Name = "Unidade")]
        public string unidade { get; set; }

        [Display(Name = "Referencia")]
        public string referencia { get; set; }

        [Display(Name = "Fonte")]
        public string fonte { get; set; }

        [Display(Name = "Grupo")]
        public string grupo { get; set; }

        [Display(Name = "Peso")]
        public int? peso { get; set; }

        [Display(Name = "Data Início")]
        public DateTime data_inicio { get; set; }

        [Display(Name = "Data Final")]
        public DateTime data_fim { get; set; }

        [Display(Name = "Cargo")]
        [ScaffoldColumn(true)]
        public long id_cargo { get; set; }

        [Display(Name = "Indicador")]
        [ScaffoldColumn(true)]
        public long id_indicador { get; set; }

        [Display(Name = "Data Cadastro")]
        [ScaffoldColumn(true)]
        public DateTime create_at { set; get; }

        [Display(Name = "Data Ultima Alteração")]
        [ScaffoldColumn(true)]
        public DateTime update_at { set; get; }

        public virtual CargoModel cargo { get; set; }

        public virtual IndicadorModel indicador { get; set; }

        public virtual ICollection<AmbitoModel> ambitos { get; set; }

        public virtual ICollection<RespostaModel> respostas { get; set; }
    }
}
