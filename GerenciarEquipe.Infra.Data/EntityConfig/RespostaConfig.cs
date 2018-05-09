using GerenciarEquipe.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarEquipe.Infra.Data.EntityConfig
{
    class RespostaConfig : EntityTypeConfiguration<Resposta>
    {
        public RespostaConfig()
        {
            HasKey(r => r.id);

            Property(r => r.autor)
             .IsRequired();

            HasRequired(r => r.funcionario)
                 .WithMany()
                 .HasForeignKey(r => r.id_funcionario);

            HasRequired(r => r.meta)
                 .WithMany()
                 .HasForeignKey(r => r.id_meta);
        }
    }
}
