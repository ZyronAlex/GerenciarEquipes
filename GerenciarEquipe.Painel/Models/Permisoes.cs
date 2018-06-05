using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciarEquipe.Painel.Models
{
    public enum Permisoes
    {        
        [Display(Name = "Dashboard")]
        Dash,
        [Display(Name = "Equipe")]
        Equip,
        [Display(Name = "Cargos")]
        Office,
        [Display(Name = "Lojas")]
        Strore,
        [Display(Name = "Indicadores")]
        Index,
        [Display(Name = "Metas")]
        Goal,
        [Display(Name = "Administradores")]
        Admin,
        [Display(Name = "Relatórios")]
        Report,
        [Display(Name = "Classificação Geral")]
        Rank,
        [Display(Name = "Formulario")]
        Forms,
    };
}