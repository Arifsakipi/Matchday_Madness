﻿// <auto-generated />
using System;
using MatchdayMadness2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    [DbContext(typeof(DB))]
    [Migration("20240710191408_migracioniMatchesTeams")]
    partial class migracioniMatchesTeams
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MatchdayMadness2.Models.Events", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Corners")
                        .HasColumnType("int");

                    b.Property<int>("Fouls")
                        .HasColumnType("int");

                    b.Property<int>("FreeKicks")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<float>("Possession")
                        .HasColumnType("real");

                    b.Property<int>("RedCards")
                        .HasColumnType("int");

                    b.Property<int>("Shots")
                        .HasColumnType("int");

                    b.Property<string>("Substitutions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YellowCards")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.Favorites", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("FavoritePlayer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavoriteTeam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayersID")
                        .HasColumnType("int");

                    b.Property<int?>("Teamsid")
                        .HasColumnType("int");

                    b.Property<int?>("Userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("PlayersID");

                    b.HasIndex("Teamsid");

                    b.HasIndex("Userid");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.LiveCommentary", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Commentator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptiveText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RealTimeUpdates")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("LiveCommentary");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.LiveMatchUpdates", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("AwayTeam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrenScoreAway")
                        .HasColumnType("int");

                    b.Property<int>("CurrenScoreHome")
                        .HasColumnType("int");

                    b.Property<DateTime>("CurrentTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("HomeTeam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("LiveMatchUpdates");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.Matches", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("AwayTeam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("HomeTeam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stadium")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Teamsid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Teamsid");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.Notifications", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Userid");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.Players", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Age")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Teamsid")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Teamsid");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.Results", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Events")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Loser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Winner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.Standings", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Draws")
                        .HasColumnType("int");

                    b.Property<int>("GoalDifference")
                        .HasColumnType("int");

                    b.Property<int>("Loses")
                        .HasColumnType("int");

                    b.Property<int>("MatchesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Team")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Standings");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.Table", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("LeagueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Standings")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Teams")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.Teams", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Coach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Draws")
                        .HasColumnType("int");

                    b.Property<string>("Formation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("League")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Loses")
                        .HasColumnType("int");

                    b.Property<int>("MatchesPlayed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stadium")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("dateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.Favorites", b =>
                {
                    b.HasOne("MatchdayMadness2.Models.Players", "Players")
                        .WithMany("Favorites")
                        .HasForeignKey("PlayersID");

                    b.HasOne("MatchdayMadness2.Models.Teams", "Teams")
                        .WithMany("Favorites")
                        .HasForeignKey("Teamsid");

                    b.HasOne("MatchdayMadness2.Models.User", "Users")
                        .WithMany("Favorites")
                        .HasForeignKey("Userid");

                    b.Navigation("Players");

                    b.Navigation("Teams");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.Matches", b =>
                {
                    b.HasOne("MatchdayMadness2.Models.Teams", "Teams")
                        .WithMany("Matches")
                        .HasForeignKey("Teamsid");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.Notifications", b =>
                {
                    b.HasOne("MatchdayMadness2.Models.User", "Users")
                        .WithMany("Notifications")
                        .HasForeignKey("Userid");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.Players", b =>
                {
                    b.HasOne("MatchdayMadness2.Models.Teams", "Teams")
                        .WithMany("Players")
                        .HasForeignKey("Teamsid");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.Players", b =>
                {
                    b.Navigation("Favorites");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.Teams", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("Matches");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("MatchdayMadness2.Models.User", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
