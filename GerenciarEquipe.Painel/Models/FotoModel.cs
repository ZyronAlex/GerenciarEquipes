using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciarEquipe.Painel.Models
{
    public partial class FotoModel
    {
        [Key]
        public long id { get; set; }

        [Display(Name = "Nome")]
        public string nome { get; set; }

        [DataType(DataType.Upload)]
        [ScaffoldColumn(true)]
        public byte conteudo { get; set; }

        [Display(Name = "Tipo")]
        public string tipo { get; set; }

        [Display(Name = "Tamanho")]
        public int tamanho { get; set; }

        [ScaffoldColumn(true)]
        public long id_usuario { get; set; }

        [Display(Name = "Data Cadastro")]
        [ScaffoldColumn(true)]
        public DateTime create_at { get; set; }

        [Display(Name = "Data Ultima Alteração")]
        [ScaffoldColumn(true)]
        public DateTime update_at { get; set; }

        public virtual UsuarioModel  usuario { get; set; }
        
    }
}
