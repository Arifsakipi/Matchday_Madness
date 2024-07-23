using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    /// <inheritdoc />
    public partial class removebuggycolumnmatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
