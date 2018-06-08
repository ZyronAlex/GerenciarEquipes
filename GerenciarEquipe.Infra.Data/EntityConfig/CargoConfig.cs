﻿using GerenciarEquipe.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarEquipe.Infra.Data.EntityConfig
{
    class CargoConfig : EntityTypeConfiguration<Cargo>
    {
        public CargoConfig()
        {
            HasKey(c => c.id);

            Property(c => c.nome)
              .IsRequired();

            Property(c => c.permissoes)
              .IsRequired();

            HasRequired(c => c.loja)
               .WithMany(l => l.cargos)
               .HasForeignKey(c => c.id_loja);
        }
    }
}
