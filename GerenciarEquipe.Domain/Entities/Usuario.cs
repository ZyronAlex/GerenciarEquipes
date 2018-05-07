using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Domain.Entities
{
    public abstract class Usuario
    {
        public Usuario()
        {
            Fotos = new HashSet<Foto>();
        }
        public long id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime create_at { set; get; }
        public DateTime update_at { set; get; }
        public virtual ICollection<Foto> Fotos { get; set; }
    }
}
