using GerenciarEquipe.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarEquipe.Infra.Data.EntityConfig
{
    class FuncionarioConfig : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfig()
        {
            HasKey(f => f.id);

            Property(f => f.matricula)
             .IsRequired();

            HasRequired(f => f.loja)
                 .WithMany(l => l.funcionarios)
                 .HasForeignKey(f => f.id_loja);

            HasRequired(f => f.cargo)
                 .WithMany(c => c.funcionarios)
                 .HasForeignKey(f => f.id_cargo);
        }
    }
}
