using GerenciarEquipe.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarEquipe.Infra.Data.EntityConfig
{
    class LojaConfig : EntityTypeConfiguration<Loja>
    {
        public LojaConfig()
        {
            HasKey(l => l.id);

            Property(l => l.nome)
             .IsRequired();
        }
    }
}
