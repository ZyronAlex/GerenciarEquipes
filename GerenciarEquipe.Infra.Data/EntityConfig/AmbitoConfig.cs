using GerenciarEquipe.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarEquipe.Infra.Data.EntityConfig
{
    class AmbitoConfig : EntityTypeConfiguration<Ambito>
    {
        public AmbitoConfig()
        {
            HasKey(a => a.id);

            HasRequired(a => a.cargo)
              .WithMany(c => c.ambitos)
              .HasForeignKey(a => a.id_cargo);

            HasRequired(a => a.meta)
             .WithMany(m => m.ambitos)
             .HasForeignKey(a => a.id_meta);

            Property(a => a.id_cargo)
              .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Result_Unique", 1) { IsUnique = true }));

            Property(a => a.id_meta)
                 .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Result_Unique", 2) { IsUnique = true }));
        }
    }
}
