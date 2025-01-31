﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SFN_DATA.ENTITY;

#nullable disable

namespace SFN.Migrations
{
    [DbContext(typeof(SFN_BDContext))]
    partial class SFN_BDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SFN_DATA.ENTITY.EntityAudit", b =>
                {
                    b.Property<Guid>("IdAudit")
                        .HasColumnType("uuid")
                        .HasColumnName("IdAudit");

                    b.Property<string>("ActionAudit")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ActionAudit");

                    b.Property<DateTime>("DateCreationAudit")
                        .HasColumnType("date")
                        .HasColumnName("DateCreationAudit");

                    b.Property<string>("FonctAuditer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("FonctAuditer");

                    b.Property<string>("MatriculeUser")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("MatriculeUser");

                    b.HasKey("IdAudit")
                        .HasName("PK__AUDITS__DA0873FAA1E0D089");

                    b.ToTable("AUDITS", (string)null);
                });

            modelBuilder.Entity("SFN_DATA.ENTITY.EntityCompte", b =>
                {
                    b.Property<string>("NumCompte")
                        .HasColumnType("text")
                        .HasColumnName("NumCompte");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("Adresse");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("date")
                        .HasColumnName("DateCreation");

                    b.Property<DateTime?>("DateModification")
                        .HasColumnType("date")
                        .HasColumnName("DateModification");

                    b.Property<string>("LibelleCompte")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("LibelleCompte");

                    b.Property<string>("NomAgence")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("NomAgence");

                    b.Property<string>("NumeroCarte")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("NumeroCarte");

                    b.Property<bool>("StatutCompte")
                        .HasColumnType("boolean")
                        .HasColumnName("StatutCompte");

                    b.Property<string>("TypeCompte")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("TypeCompte");

                    b.HasKey("NumCompte")
                        .HasName("PK__COMPTES__DA0873FAA1E0D089");

                    b.ToTable("COMPTES", (string)null);
                });

            modelBuilder.Entity("SFN_DATA.ENTITY.EntityLogiciel", b =>
                {
                    b.Property<Guid>("IdLogiciel")
                        .HasColumnType("uuid")
                        .HasColumnName("IdLogiciel");

                    b.Property<string>("CodeLogiciel")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("CodeLogiciel");

                    b.Property<int>("TempsValiderToken")
                        .HasColumnType("integer")
                        .HasColumnName("TempsValiderToken");

                    b.Property<string>("TokenLogiciel")
                        .HasColumnType("text")
                        .HasColumnName("TokenLogiciel");

                    b.HasKey("IdLogiciel")
                        .HasName("PK__LOGICIELS__DA0873FAA1E0D089");

                    b.ToTable("LOGICIELS", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
