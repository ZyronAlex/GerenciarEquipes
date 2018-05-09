using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Domain.Entities
{
    public partial class Resposta
    {
        public long id { get; set; }
        public long autor { get; set; }
        public string resultado { get; set; }
        public string justificativa { get; set; }
        public long id_funcionario { get; set; }
        public long id_meta { get; set; }
        public DateTime create_at { set; get; }
        public DateTime update_at { set; get; }
        public virtual Funcionario funcionario { get; set; }
        public virtual Meta meta { get; set; }
    }
}
