using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciarEquipe.Painel.Enums
{
    public enum TipoMeta
    {
        [Display(Name = "Estratégica",Description = "Metas estratégicas são alinhadas a objetivos estratégicos, tem peso e seus resultados são exibidos nos Cards Individuais.")]
        Estrategica,
        [Display(Name = "Pontual",Description = "Metas pontuais não tem peso e não geram resultado para os responsáveis.")]
        Pontual
    }
}