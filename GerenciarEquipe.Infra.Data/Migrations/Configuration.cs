namespace GerenciarEquipe.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.GerenciarEquipeModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        //protected override void Seed(Context.BibliotecaModelContext context)
        //{
        //    context.Admin.AddOrUpdate(
        //       new Domain.Entities.Admin { AdminId = 1, Email = "root@mixxi.com.br", Nome = "Root Mixxi", Senha = "123456" }
        //    );
        //}
    }
}
