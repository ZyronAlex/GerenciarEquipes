using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciarEquipe.Painel.Models
{
    public partial class AmbitoModel
    {
        [Key]
        public long id { get; set; }

        [ScaffoldColumn(true)]
        public long id_cargo { get; set; }

        [ScaffoldColumn(true)]
        public long id_meta { get; set; }

        [Display(Name = "Data Cadastro")]
        [ScaffoldColumn(true)]
        public DateTime create_at { set; get; }

        [Display(Name = "Data Ultima Alteração")]
        [ScaffoldColumn(true)]
        public DateTime update_at { set; get; }

        public virtual CargoModel cargo { get; set; }

        public virtual MetaModel meta { get; set; }
    }
}
