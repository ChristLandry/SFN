using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_DATA.ENTITY
{
    public class SFN_BDContext:DbContext
    {
        public string coonection;
        public IConfigurationRoot configuration;
        public SFN_BDContext() {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            configuration = builder.Build();
            coonection = configuration.GetConnectionString("DefaultConnection").ToString();
        }
        public SFN_BDContext(DbContextOptions<SFN_BDContext> options) : base(options)
        {
        }


        public DbSet<EntityAudit> EntityAudit { get; set; }
        public DbSet<EntityCompte> EntityCompte { get; set; }
        public DbSet<EntityLogiciel> EntityLogiciel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityAudit>(entity =>
            {
                entity.HasKey(e => e.IdAudit).HasName("PK__AUDITS__DA0873FAA1E0D089");

                entity.ToTable("AUDITS");

                entity.Property(e => e.IdAudit)
                    .ValueGeneratedNever()
                    .HasColumnName("IdAudit");
                entity.Property(e => e.ActionAudit).HasColumnName("ActionAudit");
                entity.Property(e => e.DateCreationAudit)
                    .HasColumnType("date")
                    .HasColumnName("DateCreationAudit");
                entity.Property(e => e.FonctAuditer)
                    .HasMaxLength(100)
                    .HasColumnName("FonctAuditer");
                entity.Property(e => e.MatriculeUser)
                    .HasMaxLength(10)
                    .HasColumnName("MatriculeUser");
            });

            modelBuilder.Entity<EntityCompte>(entity =>
            {
                entity.HasKey(e => e.NumCompte).HasName("PK__COMPTES__DA0873FAA1E0D089");

                entity.ToTable("COMPTES");

                entity.Property(e => e.NumCompte)
                    .ValueGeneratedNever()
                    .HasColumnName("NumCompte");
                entity.Property(e => e.NumeroCarte).HasColumnName("NumeroCarte");
                entity.Property(e => e.DateCreation)
                    .HasColumnType("date")
                    .HasColumnName("DateCreation");
                entity.Property(e => e.Adresse)
                    .HasMaxLength(250)
                    .HasColumnName("Adresse");
                entity.Property(e => e.DateModification)
                   .HasColumnType("date")
                    .HasColumnName("DateModification");
                entity.Property(e => e.TypeCompte)
                   .HasMaxLength(50)
                   .HasColumnName("TypeCompte");
                entity.Property(e => e.NomAgence)
                   .HasMaxLength(250)
                   .HasColumnName("NomAgence");
                entity.Property(e => e.LibelleCompte)
                   .HasMaxLength(250)
                   .HasColumnName("LibelleCompte");
                entity.Property(e => e.StatutCompte).HasColumnName("StatutCompte");
            });

            modelBuilder.Entity<EntityLogiciel>(entity =>
            {
                entity.HasKey(e => e.IdLogiciel).HasName("PK__LOGICIELS__DA0873FAA1E0D089");

                entity.ToTable("LOGICIELS");

                entity.Property(e => e.IdLogiciel)
                    .ValueGeneratedNever()
                    .HasColumnName("IdLogiciel");
                entity.Property(e => e.TokenLogiciel).HasColumnName("TokenLogiciel");
                               entity.Property(e => e.TempsValiderToken)
                    //.HasMaxLength(100)
                    .HasColumnName("TempsValiderToken");
                entity.Property(e => e.CodeLogiciel)
                    .HasMaxLength(10)
                    .HasColumnName("CodeLogiciel");
            });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(coonection);
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5433;Database=SFN_BD;Username=postgres;Password=P@ssw0rd;");

        }
    }
}
