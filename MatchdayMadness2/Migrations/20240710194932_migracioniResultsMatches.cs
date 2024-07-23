using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    /// <inheritdoc />
    public partial class migracioniResultsMatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Matchesid",
                table: "Results",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_Matchesid",
                table: "Results",
                column: "Matchesid");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Matches_Matchesid",
                table: "Results",
                column: "Matchesid",
                principalTable: "Matches",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Matches_Matchesid",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_Matchesid",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Matchesid",
                table: "Results");
        }
    }
}
