using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SFN.Migrations
{
    /// <inheritdoc />
    public partial class MySecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LOGICIELS",
                columns: new[] { "IdLogiciel", "CodeLogiciel", "TempsValiderToken", "TokenLogiciel" },
                values: new object[] { Guid.NewGuid(), "SFN", "365", "" }
                //schema: "public"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
