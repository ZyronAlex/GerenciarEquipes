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

        [ScaffoldColumn(true)]
        public long id_funcionairo { get; set; }

        [Display(Name = "Data Cadastro")]
        [ScaffoldColumn(true)]
        public DateTime create_at { set; get; }

        [Display(Name = "Data Ultima Alteração")]
        [ScaffoldColumn(true)]
        public DateTime update_at { set; get; }

        public virtual FuncionarioModel funcionario { get; set; }
    }
}
