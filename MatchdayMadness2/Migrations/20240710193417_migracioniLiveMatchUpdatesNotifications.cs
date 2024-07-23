using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    /// <inheritdoc />
    public partial class migracioniLiveMatchUpdatesNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayTeam",
                table: "LiveMatchUpdates");

            migrationBuilder.DropColumn(
                name: "HomeTeam",
                table: "LiveMatchUpdates");

            migrationBuilder.AddColumn<int>(
                name: "Notificationsid",
                table: "LiveMatchUpdates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LiveMatchUpdates_Notificationsid",
                table: "LiveMatchUpdates",
                column: "Notificationsid");

            migrationBuilder.AddForeignKey(
                name: "FK_LiveMatchUpdates_Notifications_Notificationsid",
                table: "LiveMatchUpdates",
                column: "Notificationsid",
                principalTable: "Notifications",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiveMatchUpdates_Notifications_Notificationsid",
                table: "LiveMatchUpdates");

            migrationBuilder.DropIndex(
                name: "IX_LiveMatchUpdates_Notificationsid",
                table: "LiveMatchUpdates");

            migrationBuilder.DropColumn(
                name: "Notificationsid",
                table: "LiveMatchUpdates");

            migrationBuilder.AddColumn<string>(
                name: "AwayTeam",
                table: "LiveMatchUpdates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeTeam",
                table: "LiveMatchUpdates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
