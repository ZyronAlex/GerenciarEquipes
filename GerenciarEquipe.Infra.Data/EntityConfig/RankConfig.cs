using GerenciarEquipe.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarEquipe.Infra.Data.EntityConfig
{
    class RankConfig : EntityTypeConfiguration<Rank>
    {
        public RankConfig()
        {
            HasKey(r => r.id);

            HasRequired(r => r.funcionario)
                 .WithMany(f => f.ranks)
                 .HasForeignKey(r => r.id_funcionairo);
           
        }
    }
}
