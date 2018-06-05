using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Domain.Entities
{
    public partial class Meta
    {
        public Meta()
        {
            ambitos = new HashSet<Ambito>();
            respostas = new HashSet<Resposta>();
            inquiridos = new HashSet<Inquirido>();
        }
        public long id { get; set; }
        public string descicao { get; set; }
        public string objetivo { get; set; }
        public string objetivo_parcial { get; set; }
        public string objetivo_parcial_dia { get; set; }
        public string unidade { get; set; }
        public string referencia { get; set; }
        public string fonte { get; set; }
        public string grupo { get; set; }
        public int? peso { get; set; }
        public long id_indicador { get; set; }
        public DateTime create_at { set; get; }
        public DateTime update_at { set; get; }
        public virtual Indicador indicador { get; set; }
        public virtual ICollection<Ambito> ambitos { get; set; }
        public virtual ICollection<Inquirido> inquiridos { get; set; }
        public virtual ICollection<Resposta> respostas { get; set; }
    }
}
