using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GerenciarEquipe.Painel.Models
{
    public partial class CargoModel
    {
        public CargoModel()
        {
            ambitos = new HashSet<AmbitoModel>();
            inquiridos = new HashSet<InquiridoModel>();
        }
        [Key]
        public long id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(300, ErrorMessage = "Máximo caracteres")]
        [MinLength(3, ErrorMessage = "Minimo caracteres")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        [Display(Name = "Descrição")]
        public string descicao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Permissões")]
        [Display(Name = "Permissões")]
        public string permissoes { get; set; }

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

        public virtual ICollection<FuncionarioModel> funcionarios { get; set; }
        public virtual ICollection<AmbitoModel> ambitos { get; set; }
        public virtual ICollection<InquiridoModel> inquiridos { get; set; }
    }
}
