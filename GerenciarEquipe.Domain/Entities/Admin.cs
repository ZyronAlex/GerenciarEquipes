﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Domain.Entities
{
    public partial class Admin : Usuario
    {
        public long id { get; set; }
        public string permissoes { get; set; }
    }
}
