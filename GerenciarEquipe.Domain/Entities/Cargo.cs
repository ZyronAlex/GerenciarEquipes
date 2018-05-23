using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Domain.Entities
{
    public partial class Cargo
    {
        public Cargo()
        {
            ambitos = new HashSet<Meta>();
            inquiridos = new HashSet<Meta>();

        }
        public long id { get; set; }
        public string nome { get; set; }
        public string descicao { get; set; }
        public string permissoes { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
        public virtual ICollection<Funcionario> funcionarios { get; set; }
        public virtual ICollection<Meta> ambitos { get; set; }
        public virtual ICollection<Meta> inquiridos { get; set; }
    }
}
