using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    /// <inheritdoc />
    public partial class migracioniMatchesTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Teamsid",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Teamsid",
                table: "Matches",
                column: "Teamsid");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_Teamsid",
                table: "Matches",
                column: "Teamsid",
                principalTable: "Teams",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_Teamsid",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Teamsid",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Teamsid",
                table: "Matches");
        }
    }
}
