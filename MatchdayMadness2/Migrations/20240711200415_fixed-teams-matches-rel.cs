using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    /// <inheritdoc />
    public partial class fixedteamsmatchesrel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayTeam",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeTeam",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamid",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamid",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamid",
                table: "Matches",
                column: "AwayTeamid");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamid",
                table: "Matches",
                column: "HomeTeamid");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_AwayTeamid",
                table: "Matches",
                column: "AwayTeamid",
                principalTable: "Teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_HomeTeamid",
                table: "Matches",
                column: "HomeTeamid",
                principalTable: "Teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_AwayTeamid",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_HomeTeamid",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_AwayTeamid",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_HomeTeamid",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "AwayTeamid",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeTeamid",
                table: "Matches");

            migrationBuilder.AddColumn<string>(
                name: "AwayTeam",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeTeam",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
