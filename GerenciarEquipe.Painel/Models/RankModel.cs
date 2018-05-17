using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Painel.Models
{
    public partial class RankModel
    {
        [Key]
        public long id { get; set; }

        [Display(Name = "Posição")]
        public int posicao { get; set; }

        [Display(Name = "Pontos")]
        public int pontos { get; set; }

        [Display(Name = "Mês")]
        public DateTime mes { get; set; }

        [Display(Name = "Funcionario")]
        [ScaffoldColumn(false)]
        public long id_funcionairo { get; set; }

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

        public virtual FuncionarioModel funcionario { get; set; }
    }
}
