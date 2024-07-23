using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    /// <inheritdoc />
    public partial class migracioniNotificationsUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_Userid",
                table: "Notifications",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_Userid",
                table: "Notifications",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_Userid",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_Userid",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Notifications");
        }
    }
}
