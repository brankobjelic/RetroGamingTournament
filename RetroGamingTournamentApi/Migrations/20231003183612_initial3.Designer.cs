﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RetroGamingTournament.Models;

#nullable disable

namespace RetroGamingTournament.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231003183612_initial3")]
    partial class initial3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PlayerTournament", b =>
                {
                    b.Property<int>("TournamentPlayersId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentsId")
                        .HasColumnType("int");

                    b.HasKey("TournamentPlayersId", "TournamentsId");

                    b.HasIndex("TournamentsId");

                    b.ToTable("PlayerTournament");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Banner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mortal Kombat 2"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mortal Kombat 3"
                        });
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumberOfGroupContestants")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.GroupScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GroupScores");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPlayers")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.MatchPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.ToTable("MatchPlayers");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Boris"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Bran"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Name = "Krsh"
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            Name = "Broox"
                        },
                        new
                        {
                            Id = 5,
                            IsActive = true,
                            Name = "Peka"
                        },
                        new
                        {
                            Id = 6,
                            IsActive = true,
                            Name = "Dule"
                        },
                        new
                        {
                            Id = 7,
                            IsActive = true,
                            Name = "Saka"
                        },
                        new
                        {
                            Id = 8,
                            IsActive = true,
                            Name = "Milan"
                        },
                        new
                        {
                            Id = 9,
                            IsActive = true,
                            Name = "Bole"
                        },
                        new
                        {
                            Id = 10,
                            IsActive = true,
                            Name = "Miki"
                        },
                        new
                        {
                            Id = 11,
                            IsActive = true,
                            Name = "Rada"
                        },
                        new
                        {
                            Id = 12,
                            IsActive = true,
                            Name = "Laush"
                        });
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("StageTournament", b =>
                {
                    b.Property<int>("TournamentStagesId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentsId")
                        .HasColumnType("int");

                    b.HasKey("TournamentStagesId", "TournamentsId");

                    b.HasIndex("TournamentsId");

                    b.ToTable("StageTournament");
                });

            modelBuilder.Entity("PlayerTournament", b =>
                {
                    b.HasOne("RetroGamingTournament.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("TournamentPlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetroGamingTournament.Models.Tournament", null)
                        .WithMany()
                        .HasForeignKey("TournamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Group", b =>
                {
                    b.HasOne("RetroGamingTournament.Models.Tournament", "Tournament")
                        .WithMany("TournamentGroups")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.GroupScore", b =>
                {
                    b.HasOne("RetroGamingTournament.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetroGamingTournament.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Match", b =>
                {
                    b.HasOne("RetroGamingTournament.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetroGamingTournament.Models.Tournament", null)
                        .WithMany("TournamentMatches")
                        .HasForeignKey("TournamentId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.MatchPlayer", b =>
                {
                    b.HasOne("RetroGamingTournament.Models.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetroGamingTournament.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Player", b =>
                {
                    b.HasOne("RetroGamingTournament.Models.Group", null)
                        .WithMany("GroupPlayers")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Tournament", b =>
                {
                    b.HasOne("RetroGamingTournament.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("StageTournament", b =>
                {
                    b.HasOne("RetroGamingTournament.Models.Stage", null)
                        .WithMany()
                        .HasForeignKey("TournamentStagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetroGamingTournament.Models.Tournament", null)
                        .WithMany()
                        .HasForeignKey("TournamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Group", b =>
                {
                    b.Navigation("GroupPlayers");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Tournament", b =>
                {
                    b.Navigation("TournamentGroups");

                    b.Navigation("TournamentMatches");
                });
#pragma warning restore 612, 618
        }
    }
}
