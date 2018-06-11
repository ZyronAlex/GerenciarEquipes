using GerenciarEquipe.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Painel.Models
{
    public partial class RespostaModel
    {
        [Key]
        public long id { get; set; }

        [Display(Name = "Autor")]
        public long autor { get; set; }

        [Display(Name = "Resultado")]
        public string resultado { get; set; }

        [Display(Name = "Justificativa")]
        public string justificativa { get; set; }

        [Display(Name = "Funcionario")]
        [ScaffoldColumn(false)]
        public long id_funcionario { get; set; }

        [ScaffoldColumn(false)]
        public long id_meta { get; set; }

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

        [Display(Name = "Funcionario")]
        public virtual FuncionarioModel funcionario { get; set; }

        [Display(Name = "Meta")]
        public virtual MetaModel meta { get; set; }
    }
}
