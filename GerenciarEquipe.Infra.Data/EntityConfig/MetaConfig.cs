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
            
            HasRequired(m => m.indicador)
                 .WithMany(i => i.metas)
                 .HasForeignKey(m => m.id_indicador);

            HasRequired(m => m.loja)
               .WithMany(l => l.metas)
               .HasForeignKey(m => m.id_loja);

        }
    }
}
