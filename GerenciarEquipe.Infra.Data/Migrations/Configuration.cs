namespace GerenciarEquipe.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GerenciarEquipe.Infra.Data.Context.GerenciarEquipeModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GerenciarEquipe.Infra.Data.Context.GerenciarEquipeModelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Admin.AddOrUpdate(
                new Domain.Entities.Admin { id = 1, email = "root@gerenciarequipe.com.br", nome = "Administrador", senha = "e10adc3949ba59abbe56e057f20f883e", ativo = true,permissoes="Admin"}
            );
        }
    }
}
