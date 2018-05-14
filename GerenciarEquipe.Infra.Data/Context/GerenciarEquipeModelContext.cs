using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using GerenciarEquipe.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using GerenciarEquipe.Infra.Data.EntityConfig;

namespace GerenciarEquipe.Infra.Data.Context
{
    public partial class GerenciarEquipeModelContext : DbContext
    {
        public GerenciarEquipeModelContext()
            : base("name=GerenciarEquipeModelContext")
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Ambito> Ambito { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Indicador> Indicador { get; set; }
        public virtual DbSet<Loja> Loja { get; set; }
        public virtual DbSet<Meta> Meta { get; set; }
        public virtual DbSet<Rank> Rank { get; set; }
        public virtual DbSet<Resposta> Resposta { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Add(new CustomSchemaConvention());


            modelBuilder.Properties()
                .Where(p => p.Name == "id")
                .Configure(p => p.IsKey());
            
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(800));

            modelBuilder.Configurations.Add(new AdminConfig());
            modelBuilder.Configurations.Add(new AmbitoConfig());
            modelBuilder.Configurations.Add(new CargoConfig());
            modelBuilder.Configurations.Add(new FuncionarioConfig());
            modelBuilder.Configurations.Add(new IndicadorConfig());
            modelBuilder.Configurations.Add(new LojaConfig());
            modelBuilder.Configurations.Add(new MetaConfig());
            modelBuilder.Configurations.Add(new RankConfig());
            modelBuilder.Configurations.Add(new RespostaConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("create_at") != null && entry.Entity.GetType().GetProperty("update_at") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("create_at").CurrentValue = DateTime.Now;
                    entry.Property("update_at").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("update_at").CurrentValue = DateTime.Now;
                    entry.Property("create_at").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
