using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciarEquipe.Painel.Models
{
    public enum Unidade
    {
        [Display(Name = "R$")]
        Monetario,
        [Display(Name = "%")]
        Porcentagem,
        [Display(Name = "Unidade")]
        Unidade
    }
}