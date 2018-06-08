using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Domain.Entities
{
    public partial class Loja
    {
        public Loja()
        {
            funcionarios = new HashSet<Funcionario>();
            cargos = new HashSet<Cargo>();
            indicadores = new HashSet<Indicador>();
            metas = new HashSet<Meta>();
        }
        public long id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string endereco { get; set; }
        public int telefone { get; set; }
        public DateTime create_at { set; get; }
        public DateTime update_at { set; get; }
        public ICollection<Funcionario> funcionarios { get; set; }
        public ICollection<Cargo> cargos { get; set; }
        public ICollection<Indicador> indicadores { get; set; }
        public ICollection<Meta> metas { get; set; }
    }
}
