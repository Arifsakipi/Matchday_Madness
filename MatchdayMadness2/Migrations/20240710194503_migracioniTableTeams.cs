using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    /// <inheritdoc />
    public partial class migracioniTableTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Teamsid",
                table: "Tables",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tables_Teamsid",
                table: "Tables",
                column: "Teamsid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Teams_Teamsid",
                table: "Tables",
                column: "Teamsid",
                principalTable: "Teams",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Teams_Teamsid",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_Teamsid",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "Teamsid",
                table: "Tables");
        }
    }
}
