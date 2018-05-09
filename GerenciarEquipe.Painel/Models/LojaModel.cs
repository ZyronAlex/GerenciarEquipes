using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Painel.Models
{
    public partial class LojaModel
    {
        public LojaModel()
        {
            funcionarios = new HashSet<FuncionarioModel>();
        }

        [Key]
        public long id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(300, ErrorMessage = "Máximo caracteres")]
        [MinLength(3, ErrorMessage = "Minimo caracteres")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Display(Name = "Telefone")]
        public int telefone { get; set; }

        [Display(Name = "Data Cadastro")]
        [ScaffoldColumn(true)]
        public DateTime create_at { set; get; }

        [Display(Name = "Data Ultima Alteração")]
        [ScaffoldColumn(true)]
        public DateTime update_at { set; get; }

        public ICollection<FuncionarioModel> funcionarios { get; set; }
    }
}
