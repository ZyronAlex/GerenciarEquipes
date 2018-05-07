namespace GerenciarEquipe.Infra.Data.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GerenciarEquipeModelContext : DbContext
    {
        public GerenciarEquipeModelContext()
            : base("name=GerenciarEquipeModelContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
