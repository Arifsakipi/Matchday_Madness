using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    /// <inheritdoc />
    public partial class fixedtableteamsrel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Teams_Teamsid",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "Teams",
                table: "Tables");

            migrationBuilder.AlterColumn<int>(
                name: "Teamsid",
                table: "Tables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Teams_Teamsid",
                table: "Tables",
                column: "Teamsid",
                principalTable: "Teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Teams_Teamsid",
                table: "Tables");

            migrationBuilder.AlterColumn<int>(
                name: "Teamsid",
                table: "Tables",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Teams",
                table: "Tables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Teams_Teamsid",
                table: "Tables",
                column: "Teamsid",
                principalTable: "Teams",
                principalColumn: "id");
        }
    }
}
