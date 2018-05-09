﻿using System;
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
            metas = new HashSet<Meta>();
            ambitos = new HashSet<Ambito>();

        }
        public long id { get; set; }
        public string nome { get; set; }
        public string descicao { get; set; }
        public string permissoes { get; set; }
        public virtual ICollection<Funcionario> funcionarios { get; set; }
        public virtual ICollection<Meta> metas { get; set; }
        public virtual ICollection<Ambito> ambitos { get; set; }
    }
}
