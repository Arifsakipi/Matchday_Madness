using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    /// <inheritdoc />
    public partial class migracioniLiveCommentaryMatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Matchesid",
                table: "LiveCommentary",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LiveCommentary_Matchesid",
                table: "LiveCommentary",
                column: "Matchesid");

            migrationBuilder.AddForeignKey(
                name: "FK_LiveCommentary_Matches_Matchesid",
                table: "LiveCommentary",
                column: "Matchesid",
                principalTable: "Matches",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiveCommentary_Matches_Matchesid",
                table: "LiveCommentary");

            migrationBuilder.DropIndex(
                name: "IX_LiveCommentary_Matchesid",
                table: "LiveCommentary");

            migrationBuilder.DropColumn(
                name: "Matchesid",
                table: "LiveCommentary");
        }
    }
}
