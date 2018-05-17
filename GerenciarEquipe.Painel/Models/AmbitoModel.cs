using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciarEquipe.Painel.Models
{
    public partial class AmbitoModel
    {
        [Key]
        public long id { get; set; }

        [Display(Name = "Cargo")]
        [ScaffoldColumn(false)]
        public long id_cargo { get; set; }

        [Display(Name = "Meta")]
        [ScaffoldColumn(false)]
        public long id_meta { get; set; }

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

        public virtual CargoModel cargo { get; set; }

        public virtual MetaModel meta { get; set; }
    }
}
