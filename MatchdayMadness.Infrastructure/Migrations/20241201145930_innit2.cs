using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class innit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HomeTeamid",
                table: "Matches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AwayTeamid",
                table: "Matches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Teamsid1",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Teamsid2",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Teamsid1",
                table: "Matches",
                column: "Teamsid1");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Teamsid2",
                table: "Matches",
                column: "Teamsid2");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_Teamsid1",
                table: "Matches",
                column: "Teamsid1",
                principalTable: "Teams",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_Teamsid2",
                table: "Matches",
                column: "Teamsid2",
                principalTable: "Teams",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_Teamsid1",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_Teamsid2",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Teamsid1",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Teamsid2",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Teamsid1",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Teamsid2",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "HomeTeamid",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AwayTeamid",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
