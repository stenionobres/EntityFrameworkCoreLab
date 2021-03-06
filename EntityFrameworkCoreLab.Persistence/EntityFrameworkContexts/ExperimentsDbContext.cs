﻿using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts
{
    public class ExperimentsDbContext : DbContext
    {
        private const string ConnectionString = @"Server=192.168.1.14,22331;Database=Experiments;User ID=sa;Password=sqlserver.252707;
                                                  Encrypt=False;Trusted_Connection=False;Connection Timeout=3000;";

        public DbSet<DTODataType> DTODataType { get; set; }
        public DbSet<PrincipalEntityByConventionOTM> PrincipalEntityByConventionOTM { get; set; }
        public DbSet<DependentEntityByConventionOTM> DependentEntityByConventionOTM { get; set; }
        public DbSet<PrincipalEntityByDataAnnotationOTM> PrincipalEntityByDataAnnotationOTM { get; set; }
        public DbSet<DependentEntityByDataAnnotationOTM> DependentEntityByDataAnnotationOTM { get; set; }
        public DbSet<PrincipalEntityByFluentApiOTM> PrincipalEntityByFluentApiOTM { get; set; }
        public DbSet<DependentEntityByFluentApiOTM> DependentEntityByFluentApiOTM { get; set; }
        public DbSet<PrincipalEntityByConventionOTO> PrincipalEntityByConventionOTO { get; set; }
        public DbSet<DependentEntityByConventionOTO> DependentEntityByConventionOTO { get; set; }
        public DbSet<PrincipalEntityByDataAnnotationOTO> PrincipalEntityByDataAnnotationOTO { get; set; }
        public DbSet<DependentEntityByDataAnnotationOTO> DependentEntityByDataAnnotationOTO { get; set; }
        public DbSet<PrincipalEntityByFluentApiOTO> PrincipalEntityByFluentApiOTO { get; set; }
        public DbSet<DependentEntityByFluentApiOTO> DependentEntityByFluentApiOTO { get; set; }
        public DbSet<PrincipalEntityByConventionMTM> PrincipalEntityByConventionMTM { get; set; }
        public DbSet<MiddleEntityByConventionMTM> MiddleEntityByConventionMTM { get; set; }
        public DbSet<DependentEntityByConventionMTM> DependentEntityByConventionMTM { get; set; }
        public DbSet<PrincipalEntityByDataAnnotationMTM> PrincipalEntityByDataAnnotationMTM { get; set; }
        public DbSet<MiddleEntityByDataAnnotationMTM> MiddleEntityByDataAnnotationMTM { get; set; }
        public DbSet<DependentEntityByDataAnnotationMTM> DependentEntityByDataAnnotationMTM { get; set; }
        public DbSet<PrincipalEntityByFluentApiMTM> PrincipalEntityByFluentApiMTM { get; set; }
        public DbSet<MiddleEntityByFluentApiMTM> MiddleEntityByFluentApiMTM { get; set; }
        public DbSet<DependentEntityByFluentApiMTM> DependentEntityByFluentApiMTM { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrincipalEntityByFluentApiOTM>()
                        .HasMany(p => p.DependentsEntitiesByFluentApiOTM)
                        .WithOne()
                        .HasForeignKey(d => d.ForeignKeyToPrincipalEntity);

            modelBuilder.Entity<PrincipalEntityByFluentApiOTO>()
                        .HasOne(p => p.DependentEntityByFluentApiOTO);

            modelBuilder.Entity<MiddleEntityByFluentApiMTM>()
                        .HasOne(p => p.PrincipalEntityByFluentApiMTM)
                        .WithMany(m => m.MiddleEntitiesByFluentApiMTM)
                        .HasForeignKey(m => m.ForeignKeyToPrincipalEntity);

            modelBuilder.Entity<MiddleEntityByFluentApiMTM>()
                      .HasOne(p => p.DependentEntityByFluentApiMTM)
                      .WithMany(m => m.MiddleEntitiesByFluentApiMTM)
                      .HasForeignKey(m => m.ForeignKeyToDependentEntity);

        }
    }
}
