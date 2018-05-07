using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Domain.Entities
{
    public partial class Foto
    {
        public long id { get; set; }
        public string nome { get; set; }
        public byte conteudo { get; set; }
        public string tipo { get; set; }
        public int tamanho { get; set; }
        public long id_usuario { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
        public virtual Usuario  usuario { get; set; }
        
    }
}
