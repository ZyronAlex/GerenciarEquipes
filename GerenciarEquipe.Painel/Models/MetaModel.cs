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
            inquiridos = new HashSet<InquiridoModel>();
            cargoAmbitos = new List<long>();
            cargoInquiridos = new List<long>();
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

        [Display(Name = "Respondida por Terceiros")]
        public bool terceiros { get; set; }

        [Display(Name = "Peso")]
        public int? peso { get; set; }

        [Display(Name = "Indicador")]
        [ScaffoldColumn(false)]
        public long id_indicador { get; set; }

        [Display(Name = "Loja")]
        [ScaffoldColumn(false)]
        public long id_loja { get; set; }

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

        [Display(Name = "Indicador")]
        [ScaffoldColumn(false)]
        public virtual IndicadorModel indicador { get; set; }

        [Display(Name = "Loja")]
        [ScaffoldColumn(false)]
        public virtual LojaModel loja { get; set; }
        
        [Display(Name = "Ambitos")]
        [ScaffoldColumn(false)]
        public virtual ICollection<AmbitoModel> ambitos { get; set; }

        [Display(Name = "Respostas")]
        [ScaffoldColumn(false)]
        public virtual ICollection<RespostaModel> respostas { get; set; }

        [Display(Name = "Inquiridos")]
        [ScaffoldColumn(false)]
        public virtual ICollection<InquiridoModel> inquiridos { get; set; }

        [Display(Name = "Ambitos",Description = "Os cargos  que serão subimetidos à essa meta")]
        [ScaffoldColumn(false)]
        public List<long> cargoAmbitos { get; set; }

        [Display(Name = "Inquiridos",Description = "Os cargos responderão os questionairos dessa meta")]
        [ScaffoldColumn(false)]
        public List<long> cargoInquiridos { get; set; }
    }
}
