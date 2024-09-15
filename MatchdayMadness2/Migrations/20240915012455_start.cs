using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    /// <inheritdoc />
    public partial class start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Shots = table.Column<int>(type: "int", nullable: false),
                    YellowCards = table.Column<int>(type: "int", nullable: false),
                    RedCards = table.Column<int>(type: "int", nullable: false),
                    Fouls = table.Column<int>(type: "int", nullable: false),
                    Substitutions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Corners = table.Column<int>(type: "int", nullable: false),
                    FreeKicks = table.Column<int>(type: "int", nullable: false),
                    Possession = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Standings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    MatchesPlayed = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Loses = table.Column<int>(type: "int", nullable: false),
                    Draws = table.Column<int>(type: "int", nullable: false),
                    GoalDifference = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    League = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coach = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Formation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stadium = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatchesPlayed = table.Column<int>(type: "int", nullable: true),
                    Wins = table.Column<int>(type: "int", nullable: true),
                    Loses = table.Column<int>(type: "int", nullable: true),
                    Draws = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    LeagueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Standingsid = table.Column<int>(type: "int", nullable: true),
                    Teamsid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueId);
                    table.ForeignKey(
                        name: "FK_Leagues_Standings_Standingsid",
                        column: x => x.Standingsid,
                        principalTable: "Standings",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Leagues_Teams_Teamsid",
                        column: x => x.Teamsid,
                        principalTable: "Teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stadium = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeTeamid = table.Column<int>(type: "int", nullable: false),
                    AwayTeamid = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teamsid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.id);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_AwayTeamid",
                        column: x => x.AwayTeamid,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HomeTeamid",
                        column: x => x.HomeTeamid,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_Teamsid",
                        column: x => x.Teamsid,
                        principalTable: "Teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Teamsid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Players_Teams_Teamsid",
                        column: x => x.Teamsid,
                        principalTable: "Teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "StandingsTeams",
                columns: table => new
                {
                    Standingsid = table.Column<int>(type: "int", nullable: false),
                    Teamsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandingsTeams", x => new { x.Standingsid, x.Teamsid });
                    table.ForeignKey(
                        name: "FK_StandingsTeams_Standings_Standingsid",
                        column: x => x.Standingsid,
                        principalTable: "Standings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandingsTeams_Teams_Teamsid",
                        column: x => x.Teamsid,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeagueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teamsid = table.Column<int>(type: "int", nullable: false),
                    Standings = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tables_Teams_Teamsid",
                        column: x => x.Teamsid,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    Userid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "LiveCommentary",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Commentator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptiveText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealTimeUpdates = table.Column<bool>(type: "bit", nullable: false),
                    Matchesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveCommentary", x => x.id);
                    table.ForeignKey(
                        name: "FK_LiveCommentary_Matches_Matchesid",
                        column: x => x.Matchesid,
                        principalTable: "Matches",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Winner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Events = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matchesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.id);
                    table.ForeignKey(
                        name: "FK_Results_Matches_Matchesid",
                        column: x => x.Matchesid,
                        principalTable: "Matches",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teamsid = table.Column<int>(type: "int", nullable: true),
                    PlayersID = table.Column<int>(type: "int", nullable: true),
                    Userid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.id);
                    table.ForeignKey(
                        name: "FK_Favorites_Players_PlayersID",
                        column: x => x.PlayersID,
                        principalTable: "Players",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Favorites_Teams_Teamsid",
                        column: x => x.Teamsid,
                        principalTable: "Teams",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Favorites_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "LiveMatchUpdates",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrenScoreHome = table.Column<int>(type: "int", nullable: false),
                    CurrenScoreAway = table.Column<int>(type: "int", nullable: false),
                    CurrentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notificationsid = table.Column<int>(type: "int", nullable: true),
                    Matchesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveMatchUpdates", x => x.id);
                    table.ForeignKey(
                        name: "FK_LiveMatchUpdates_Matches_Matchesid",
                        column: x => x.Matchesid,
                        principalTable: "Matches",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_LiveMatchUpdates_Notifications_Notificationsid",
                        column: x => x.Notificationsid,
                        principalTable: "Notifications",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_PlayersID",
                table: "Favorites",
                column: "PlayersID");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Teamsid",
                table: "Favorites",
                column: "Teamsid");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Userid",
                table: "Favorites",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_Standingsid",
                table: "Leagues",
                column: "Standingsid");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_Teamsid",
                table: "Leagues",
                column: "Teamsid");

            migrationBuilder.CreateIndex(
                name: "IX_LiveCommentary_Matchesid",
                table: "LiveCommentary",
                column: "Matchesid");

            migrationBuilder.CreateIndex(
                name: "IX_LiveMatchUpdates_Matchesid",
                table: "LiveMatchUpdates",
                column: "Matchesid");

            migrationBuilder.CreateIndex(
                name: "IX_LiveMatchUpdates_Notificationsid",
                table: "LiveMatchUpdates",
                column: "Notificationsid");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamid",
                table: "Matches",
                column: "AwayTeamid");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamid",
                table: "Matches",
                column: "HomeTeamid");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Teamsid",
                table: "Matches",
                column: "Teamsid");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_Userid",
                table: "Notifications",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Teamsid",
                table: "Players",
                column: "Teamsid");

            migrationBuilder.CreateIndex(
                name: "IX_Results_Matchesid",
                table: "Results",
                column: "Matchesid");

            migrationBuilder.CreateIndex(
                name: "IX_StandingsTeams_Teamsid",
                table: "StandingsTeams",
                column: "Teamsid");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_Teamsid",
                table: "Tables",
                column: "Teamsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "LiveCommentary");

            migrationBuilder.DropTable(
                name: "LiveMatchUpdates");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "StandingsTeams");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Standings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
