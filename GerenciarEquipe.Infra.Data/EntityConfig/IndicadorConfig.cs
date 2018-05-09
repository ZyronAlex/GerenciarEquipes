using GerenciarEquipe.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarEquipe.Infra.Data.EntityConfig
{
    class IndicadorConfig : EntityTypeConfiguration<Indicador>
    {
        public IndicadorConfig()
        {
            HasKey(i => i.id);

            Property(i => i.nome)
              .IsRequired();
        }
    }
}
