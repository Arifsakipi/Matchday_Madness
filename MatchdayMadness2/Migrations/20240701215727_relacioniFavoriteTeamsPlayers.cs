using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    /// <inheritdoc />
    public partial class relacioniFavoriteTeamsPlayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayersID",
                table: "Favorites",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Teamsid",
                table: "Favorites",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_PlayersID",
                table: "Favorites",
                column: "PlayersID");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Teamsid",
                table: "Favorites",
                column: "Teamsid");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Players_PlayersID",
                table: "Favorites",
                column: "PlayersID",
                principalTable: "Players",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Teams_Teamsid",
                table: "Favorites",
                column: "Teamsid",
                principalTable: "Teams",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Players_PlayersID",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Teams_Teamsid",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_PlayersID",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_Teamsid",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "PlayersID",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "Teamsid",
                table: "Favorites");
        }
    }
}
