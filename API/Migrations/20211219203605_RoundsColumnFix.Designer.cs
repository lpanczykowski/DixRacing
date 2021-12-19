﻿// <auto-generated />
using System;
using DixRacing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211219203605_RoundsColumnFix")]
    partial class RoundsColumnFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("DixRacing.Data.Entites.EventParticipants", b =>
                {
                    b.Property<int>("EventParticipantsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Car")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Livery")
                        .HasColumnType("BLOB");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventParticipantsId");

                    b.ToTable("EventParticipants");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.Events", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("BLOB");

                    b.HasKey("EventId");

                    b.HasIndex("GameId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.Games", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("BLOB");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.HotLaps", b =>
                {
                    b.Property<int>("RaceHotLapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("RaceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Time")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RaceHotLapId");

                    b.HasIndex("RaceId");

                    b.HasIndex("UserId");

                    b.ToTable("RaceHotLaps");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.RaceConfirmations", b =>
                {
                    b.Property<int>("RaceConfirmationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Confrimed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RaceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RaceConfirmationId");

                    b.ToTable("RaceConfirmations");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.RaceLaps", b =>
                {
                    b.Property<int>("RaceLapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("RaceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Time")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RaceLapId");

                    b.HasIndex("RaceId");

                    b.HasIndex("UserId");

                    b.ToTable("RaceLaps");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.RacePoints", b =>
                {
                    b.Property<int>("RacePointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Points")
                        .HasColumnType("REAL");

                    b.Property<int>("Position")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RaceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RacePointId");

                    b.ToTable("RacePoints");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.RaceResults", b =>
                {
                    b.Property<int>("RaceResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PenaltyPoints")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Points")
                        .HasColumnType("REAL");

                    b.Property<int>("Position")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RaceId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RoundId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RaceResultId");

                    b.HasIndex("RoundId");

                    b.HasIndex("UserId");

                    b.ToTable("RaceResults");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.Races", b =>
                {
                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoundId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RoundsRoundId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SigningTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartingTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("WeatherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RaceId");

                    b.HasIndex("EventId");

                    b.HasIndex("RoundsRoundId");

                    b.HasIndex("WeatherId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.Rounds", b =>
                {
                    b.Property<int>("RoundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventsEventId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RoundDay")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerPassword")
                        .HasColumnType("TEXT");

                    b.Property<int>("TrackId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RoundId");

                    b.HasIndex("EventsEventId");

                    b.HasIndex("TrackId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.Tracks", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("BLOB");

                    b.HasKey("TrackId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nick")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("SteamId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.Weathers", b =>
                {
                    b.Property<int>("WeatherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("WeatherId");

                    b.ToTable("Weathers");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.Events", b =>
                {
                    b.HasOne("DixRacing.Data.Entites.Games", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.HotLaps", b =>
                {
                    b.HasOne("DixRacing.Data.Entites.Races", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DixRacing.Data.Entites.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.RaceLaps", b =>
                {
                    b.HasOne("DixRacing.Data.Entites.Races", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DixRacing.Data.Entites.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.RaceResults", b =>
                {
                    b.HasOne("DixRacing.Data.Entites.Races", "Race")
                        .WithMany()
                        .HasForeignKey("RoundId");

                    b.HasOne("DixRacing.Data.Entites.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.Races", b =>
                {
                    b.HasOne("DixRacing.Data.Entites.Events", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("DixRacing.Data.Entites.Rounds", null)
                        .WithMany("Races")
                        .HasForeignKey("RoundsRoundId");

                    b.HasOne("DixRacing.Data.Entites.Weathers", "Weather")
                        .WithMany()
                        .HasForeignKey("WeatherId");

                    b.Navigation("Event");

                    b.Navigation("Weather");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.Rounds", b =>
                {
                    b.HasOne("DixRacing.Data.Entites.Events", null)
                        .WithMany("Rounds")
                        .HasForeignKey("EventsEventId");

                    b.HasOne("DixRacing.Data.Entites.Tracks", "Track")
                        .WithMany()
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Track");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.Events", b =>
                {
                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("DixRacing.Data.Entites.Rounds", b =>
                {
                    b.Navigation("Races");
                });
#pragma warning restore 612, 618
        }
    }
}
