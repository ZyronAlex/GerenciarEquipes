using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Domain.Entities
{
    public partial class Indicador
    {
        public Indicador()
        {
            metas = new HashSet<Meta>();
        }
        public long id { get; set; }
        public string nome { get; set; }
        public string indicativa { get; set; }
        public long id_loja { get; set; }
        public DateTime create_at { set; get; }
        public DateTime update_at { set; get; }
        public virtual Loja loja { get; set; }
        public virtual ICollection<Meta> metas { get; set; }
    }
}
