using System.Data.Entity.ModelConfiguration.Conventions;

namespace GerenciarEquipe.Infra.Data.EntityConfig
{
    public class CustomSchemaConvention : Convention
    {
        public CustomSchemaConvention()
        {
            //Types().Configure(c => c.ToTable(c.ClrType.Name, c.ClrType.Namespace.Substring(c.ClrType.Namespace.LastIndexOf('.') + 1)));
            Types().Configure(c => c.ToTable(c.ClrType.Name, "GerenciarEquipe"));
        }
    }
}

