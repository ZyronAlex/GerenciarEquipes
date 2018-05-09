using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Domain.Entities
{
    public partial class Funcionario : Usuario
    {
        public Funcionario()
        {
            ranks = new HashSet<Rank>();
            respostas = new HashSet<Resposta>();
        }
        public long id { get; set; }
        public long matricula { get; set; }
        public DateTime nascimento { get; set; }
        public string genero { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string turno { get; set; }
        public long id_cargo { get; set; }
        public long id_loja {get; set;}
        public virtual Loja loja { get; set; }
        public virtual Cargo cargo { get; set; }
        public virtual ICollection<Rank> ranks { get; set; }
        public virtual ICollection<Resposta> respostas { get; set;}

    }
}
