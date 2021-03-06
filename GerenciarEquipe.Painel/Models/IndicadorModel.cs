﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciarEquipe.Painel.Models
{
    public partial class IndicadorModel
    {
        public IndicadorModel()
        {
            metas = new HashSet<MetaModel>();
        }

        [Key]
        public long id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(300, ErrorMessage = "Máximo caracteres")]
        [MinLength(3, ErrorMessage = "Minimo caracteres")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name = "Indicativa")]
        public string indicativa { get; set; }

        [Display(Name = "Loja")]
        [ScaffoldColumn(false)]
        public long id_loja { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Cadastro")]
        [ScaffoldColumn(false)]
        public DateTime create_at { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Ultima Alteração")]
        [ScaffoldColumn(false)]
        public DateTime update_at { set; get; }

        [Display(Name = "Loja")]
        [ScaffoldColumn(false)]
        public virtual LojaModel loja { get; set; }

        public virtual ICollection<MetaModel> metas { get; set; }
    }
}
