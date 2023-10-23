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
    [Migration("20231023230812_modified model 2")]
    partial class modifiedmodel2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GroupPlayer", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<int>("PlayersId")
                        .HasColumnType("int");

                    b.HasKey("GroupsId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("GroupPlayer");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BannerFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameType")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

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
                            GameType = "A",
                            Name = "Mortal Kombat 3"
                        },
                        new
                        {
                            Id = 2,
                            GameType = "B",
                            Name = "Micro Machines"
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

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("NameAudioFile")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

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

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("GameId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("StageTournament", b =>
                {
                    b.Property<int>("StagesId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentsId")
                        .HasColumnType("int");

                    b.HasKey("StagesId", "TournamentsId");

                    b.HasIndex("TournamentsId");

                    b.ToTable("StageTournament");
                });

            modelBuilder.Entity("GroupPlayer", b =>
                {
                    b.HasOne("RetroGamingTournament.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetroGamingTournament.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Group", b =>
                {
                    b.HasOne("RetroGamingTournament.Models.Tournament", "Tournament")
                        .WithMany("Groups")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Tournament", b =>
                {
                    b.HasOne("RetroGamingTournament.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetroGamingTournament.Models.Game", "Game")
                        .WithMany("Tournaments")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("StageTournament", b =>
                {
                    b.HasOne("RetroGamingTournament.Models.Stage", null)
                        .WithMany()
                        .HasForeignKey("StagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetroGamingTournament.Models.Tournament", null)
                        .WithMany()
                        .HasForeignKey("TournamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Game", b =>
                {
                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("RetroGamingTournament.Models.Tournament", b =>
                {
                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}
