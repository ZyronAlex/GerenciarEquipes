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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM}", ApplyFormatInEditMode = true)]
        [Display(Name = "Mes")]
        [ScaffoldColumn(false)]
        public DateTime mes { get; set; }
        
        [Display(Name = "Cargo")]
        [ScaffoldColumn(false)]
        public long id_cargo { get; set; }

        [Display(Name = "Indicador")]
        [ScaffoldColumn(false)]
        public long id_indicador { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Cadastro")]
        [ScaffoldColumn(false)]
        public DateTime create_at { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Ultima Alteração")]
        [ScaffoldColumn(false)]
        public DateTime update_at { set; get; }

        public virtual CargoModel cargo { get; set; }

        public virtual IndicadorModel indicador { get; set; }

        public virtual ICollection<AmbitoModel> ambitos { get; set; }

        public virtual ICollection<RespostaModel> respostas { get; set; }
    }
}
