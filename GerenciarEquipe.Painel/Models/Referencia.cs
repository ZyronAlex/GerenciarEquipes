using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciarEquipe.Painel.Models
{
    public enum Referencia
    {
        [Display(Name = "Mais é Melhor")]
        Mais,
        [Display(Name = "Menos é Melhor")]
        Menos
    }
}