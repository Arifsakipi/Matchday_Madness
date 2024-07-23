using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    /// <inheritdoc />
    public partial class migracioniFavoritesUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Favorites",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Userid",
                table: "Favorites",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_Userid",
                table: "Favorites",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_Userid",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_Userid",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Favorites");
        }
    }
}
