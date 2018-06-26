using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciarEquipe.Painel.Enums
{
    public enum Grupo
    {
        [Display(Name = "Produto")]
        Produto,
        [Display(Name = "Preço")]
        Preco,
        [Display(Name = "Promoção")]
        Promocao,
        [Display(Name = "Ambiente de Loja")]
        Ambiente,
        [Display(Name = "Atendimento")]
        Atendimento
    }
}