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
        [ScaffoldColumn(true)]
        public long id_funcionario { get; set; }

        [ScaffoldColumn(true)]
        public long id_meta { get; set; }

        [Display(Name = "Data Cadastro")]
        [ScaffoldColumn(true)]
        public DateTime create_at { set; get; }

        [Display(Name = "Data Ultima Alteração")]
        [ScaffoldColumn(true)]
        public DateTime update_at { set; get; }

        public virtual FuncionarioModel funcionario { get; set; }

        public virtual MetaModel meta { get; set; }
    }
}
