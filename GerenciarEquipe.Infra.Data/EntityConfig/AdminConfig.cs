using GerenciarEquipe.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarEquipe.Infra.Data.EntityConfig
{
    class AdminConfig : EntityTypeConfiguration<Admin>
    {
        public AdminConfig()
        {
            HasKey(a => a.id);
            Property(a => a.permissoes)
               .IsRequired();

        }
    }
}
