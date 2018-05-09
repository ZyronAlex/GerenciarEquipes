using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Domain.Entities
{
    public partial class Rank
    {
        public long id { get; set; }
        public int posicao { get; set; }
        public int pontos { get; set; }
        public DateTime mes { get; set; }
        public long id_funcionairo { get; set; }
        public DateTime create_at { set; get; }
        public DateTime update_at { set; get; }
        public virtual Funcionario funcionario { get; set; }
    }
}
