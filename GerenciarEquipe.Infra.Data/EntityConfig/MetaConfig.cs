using GerenciarEquipe.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarEquipe.Infra.Data.EntityConfig
{
    class MetaConfig : EntityTypeConfiguration<Meta>
    {
        public MetaConfig()
        {
            HasKey(m => m.id);

            Property(m => m.descicao)
             .IsRequired();

            Property(m => m.objetivo)
             .IsRequired();

            Property(m => m.unidade)
             .IsRequired();

            HasRequired(m => m.cargo)
                 .WithMany()
                 .HasForeignKey(m => m.id_cargo);

            HasRequired(m => m.indicador)
                 .WithMany()
                 .HasForeignKey(m => m.id_indicador);
        }
    }
}
