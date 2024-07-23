using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SFN.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUDITS",
                columns: table => new
                {
                    IdAudit = table.Column<Guid>(type: "uuid", nullable: false),
                    FonctAuditer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ActionAudit = table.Column<string>(type: "text", nullable: false),
                    MatriculeUser = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    DateCreationAudit = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AUDITS__DA0873FAA1E0D089", x => x.IdAudit);
                });

            migrationBuilder.CreateTable(
                name: "COMPTES",
                columns: table => new
                {
                    NumCompte = table.Column<string>(type: "text", nullable: false),
                    NomAgence = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    LibelleCompte = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    TypeCompte = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    StatutCompte = table.Column<bool>(type: "boolean", nullable: false),
                    NumeroCarte = table.Column<string>(type: "text", nullable: false),
                    Adresse = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    DateCreation = table.Column<DateTime>(type: "date", nullable: false),
                    DateModification = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__COMPTES__DA0873FAA1E0D089", x => x.NumCompte);
                });

            migrationBuilder.CreateTable(
                name: "LOGICIELS",
                columns: table => new
                {
                    IdLogiciel = table.Column<Guid>(type: "uuid", nullable: false),
                    CodeLogiciel = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    TokenLogiciel = table.Column<string>(type: "text", nullable: true),
                    TempsValiderToken = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOGICIELS__DA0873FAA1E0D089", x => x.IdLogiciel);
                });

            //migrationBuilder.Sql(@"INSERT INTO LOGICIELS (IdLogiciel, CodeLogiciel,TempsValiderToken,TokenLogiciel) 
                        //VALUES ('"+ Guid.NewGuid() + "', 'SFN','365','')");

            //migrationBuilder.InsertData(
            //    table: "LOGICIELS",
            //    columns: new[] { "IdLogiciel", "CodeLogiciel", "TempsValiderToken", "TokenLogiciel" },
            //    values: new object[] { Guid.NewGuid(), "SFN",365,""},
            //    schema: "public"
            //);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUDITS");

            migrationBuilder.DropTable(
                name: "COMPTES");

            migrationBuilder.DropTable(
                name: "LOGICIELS");
        }
    }
}
