using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciarEquipe.Painel.Enums
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
        Store,
        [Display(Name = "Indicadores")]
        Index,
        [Display(Name = "Metas")]
        Goal,
        [Display(Name = "Administrador Geral")]
        Admin,
        [Display(Name = "Relatórios")]
        Report,
        [Display(Name = "Classificação Geral")]
        Rank,
        [Display(Name = "Formulario")]
        Forms,
    };
}