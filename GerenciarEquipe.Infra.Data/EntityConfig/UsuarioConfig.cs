using GerenciarEquipe.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarEquipe.Infra.Data.EntityConfig
{
    class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(u => u.id);

            Property(u => u.nome)
             .IsRequired();

            Property(u => u.email)
             .IsRequired()
             .IsUnicode();

            Property(u => u.senha)
             .IsRequired()
             .IsMaxLength();
        }
    }
}
