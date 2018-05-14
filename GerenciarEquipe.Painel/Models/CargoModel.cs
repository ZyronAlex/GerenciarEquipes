using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GerenciarEquipe.Painel.Models
{
    public partial class CargoModel
    {
        public CargoModel()
        {
            metas = new HashSet<MetaModel>();
            ambitos = new HashSet<AmbitoModel>();

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

        public virtual ICollection<FuncionarioModel> funcionarios { get; set; }
        public virtual ICollection<MetaModel> metas { get; set; }
        public virtual ICollection<AmbitoModel> ambitos { get; set; }
    }
}
