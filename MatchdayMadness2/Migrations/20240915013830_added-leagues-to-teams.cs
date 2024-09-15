using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    /// <inheritdoc />
    public partial class addedleaguestoteams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "League",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "Leagueid",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Leagueid",
                table: "Teams");

            migrationBuilder.AddColumn<string>(
                name: "League",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
