using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciarEquipe.Domain.Entities
{
    public abstract class Usuario
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public bool ativo { get; set; }
        public string foto { get; set; }
        public DateTime create_at { set; get; }
        public DateTime update_at { set; get; }

        public bool Login(Usuario usuario)
        {
            if ((string.IsNullOrEmpty(usuario.email) && string.IsNullOrEmpty(usuario.senha)) || !this.ativo)
                return false;
            else
                return usuario.email.ToUpper().Trim().Equals(this.email.ToUpper().Trim()) && usuario.senha.Equals(this.senha);
        }
    }
}
