using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    /// <inheritdoc />
    public partial class migracioniLiveMatchUpdatesMatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Matchesid",
                table: "LiveMatchUpdates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LiveMatchUpdates_Matchesid",
                table: "LiveMatchUpdates",
                column: "Matchesid");

            migrationBuilder.AddForeignKey(
                name: "FK_LiveMatchUpdates_Matches_Matchesid",
                table: "LiveMatchUpdates",
                column: "Matchesid",
                principalTable: "Matches",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiveMatchUpdates_Matches_Matchesid",
                table: "LiveMatchUpdates");

            migrationBuilder.DropIndex(
                name: "IX_LiveMatchUpdates_Matchesid",
                table: "LiveMatchUpdates");

            migrationBuilder.DropColumn(
                name: "Matchesid",
                table: "LiveMatchUpdates");
        }
    }
}
