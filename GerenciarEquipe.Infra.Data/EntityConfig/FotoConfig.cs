using GerenciarEquipe.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarEquipe.Infra.Data.EntityConfig
{
    class FotoConfig : EntityTypeConfiguration<Foto>
    {
        public FotoConfig()
        {
            HasKey(f => f.id);

            Property(f => f.conteudo)
              .IsRequired();

            Property(f => f.tipo)
              .IsRequired();

            HasRequired(f => f.usuario)
                 .WithMany()
                 .HasForeignKey(f => f.id_usuario);

        }
    }
}
