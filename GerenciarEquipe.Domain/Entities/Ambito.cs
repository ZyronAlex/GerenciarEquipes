using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Domain.Entities
{
    public partial class Ambito
    {
        public long id { get; set; }
        public long id_cargo { get; set; }
        public long id_meta { get; set; }
        public DateTime create_at { set; get; }
        public DateTime update_at { set; get; }
        public virtual Cargo cargo { get; set; }
        public virtual Meta meta { get; set; }
    }
}
