using GerenciarEquipe.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarEquipe.Infra.Data.EntityConfig
{
    class InquiridoConfig : EntityTypeConfiguration<Inquirido>
    {
        public InquiridoConfig()
        {
            HasKey(i => i.id);

            HasRequired(i => i.cargo)
              .WithMany(c => c.inquiridos)
              .HasForeignKey(i => i.id_cargo);

            HasRequired(i => i.meta)
             .WithMany(m => m.inquiridos)
             .HasForeignKey(i => i.id_meta);

            Property(i => i.id_cargo)
              .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Result_Unique", 1) { IsUnique = true }));

            Property(i => i.id_meta)
                 .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Result_Unique", 2) { IsUnique = true }));
        }
    }
}
