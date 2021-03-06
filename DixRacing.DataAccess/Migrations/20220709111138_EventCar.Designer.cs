// <auto-generated />
using System;
using DixRacing.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DixRacing.DataAccess.Migrations
{
    [DbContext(typeof(DixRacingDbContext))]
    [Migration("20220709111138_EventCar")]
    partial class EventCar
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("DixRacing.Domain.EventParticipants.EventParticipant", b =>
                {
                    b.Property<int>("Id")
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

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("TeamId");

                    b.ToTable("EventParticipants");
                });

            modelBuilder.Entity("DixRacing.Domain.Events.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("DixRacing.Domain.Events.EventCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("EventId");

                    b.ToTable("EventCars");
                });

            modelBuilder.Entity("DixRacing.Domain.Races.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PracticeDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PracticeLength")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("QualiDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("QualiLength")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RaceDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("RaceLength")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoundId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SessionType")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SigningTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoundId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("DixRacing.Domain.Races.RaceIncident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("IsSolved")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Lap")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Penalty")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PointPenalty")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RaceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReportedUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Time")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TimePenalty")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("RaceIncidents");
                });

            modelBuilder.Entity("DixRacing.Domain.Races.RaceLap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IsValid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Lap")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RaceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Split1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Split2")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Split3")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserSteamId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("RaceLaps");
                });

            modelBuilder.Entity("DixRacing.Domain.Races.RacePoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Points")
                        .HasColumnType("REAL");

                    b.Property<int>("Position")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RaceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("RacePoints");
                });

            modelBuilder.Entity("DixRacing.Domain.Races.RaceResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IsUserConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Position")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RaceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("RaceResults");
                });

            modelBuilder.Entity("DixRacing.Domain.Rounds.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RoundDay")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoundNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ServerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerPassword")
                        .HasColumnType("TEXT");

                    b.Property<int>("TrackId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("TrackId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("DixRacing.Domain.Teams.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("DixRacing.Domain.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DiscordId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("IsAdmin")
                        .HasColumnType("INTEGER");

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

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DixRacing.Domain.Utility.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CarName")
                        .HasColumnType("TEXT");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("DixRacing.Domain.Utility.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DixRacing.Domain.Utility.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("DixRacing.Domain.EventParticipants.EventParticipant", b =>
                {
                    b.HasOne("DixRacing.Domain.Events.Event", "Event")
                        .WithMany("EventParticipants")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DixRacing.Domain.Teams.Team", "Team")
                        .WithMany("Participants")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("DixRacing.Domain.Events.EventCar", b =>
                {
                    b.HasOne("DixRacing.Domain.Events.Event", "Event")
                        .WithMany("EventCars")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DixRacing.Domain.Utility.Car", "Car")
                        .WithMany("EventCars")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("DixRacing.Domain.Races.Race", b =>
                {
                    b.HasOne("DixRacing.Domain.Rounds.Round", "Round")
                        .WithMany("Races")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Round");
                });

            modelBuilder.Entity("DixRacing.Domain.Races.RaceIncident", b =>
                {
                    b.HasOne("DixRacing.Domain.Races.Race", "Race")
                        .WithMany("RaceIncidents")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");
                });

            modelBuilder.Entity("DixRacing.Domain.Races.RaceLap", b =>
                {
                    b.HasOne("DixRacing.Domain.Races.Race", "Race")
                        .WithMany("RaceLaps")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");
                });

            modelBuilder.Entity("DixRacing.Domain.Races.RacePoint", b =>
                {
                    b.HasOne("DixRacing.Domain.Races.Race", "Race")
                        .WithMany("RacePoints")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");
                });

            modelBuilder.Entity("DixRacing.Domain.Races.RaceResult", b =>
                {
                    b.HasOne("DixRacing.Domain.Races.Race", "Race")
                        .WithMany("RaceResults")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");
                });

            modelBuilder.Entity("DixRacing.Domain.Rounds.Round", b =>
                {
                    b.HasOne("DixRacing.Domain.Events.Event", "Event")
                        .WithMany("Rounds")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DixRacing.Domain.Utility.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("DixRacing.Domain.Events.Event", b =>
                {
                    b.Navigation("EventCars");

                    b.Navigation("EventParticipants");

                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("DixRacing.Domain.Races.Race", b =>
                {
                    b.Navigation("RaceIncidents");

                    b.Navigation("RaceLaps");

                    b.Navigation("RacePoints");

                    b.Navigation("RaceResults");
                });

            modelBuilder.Entity("DixRacing.Domain.Rounds.Round", b =>
                {
                    b.Navigation("Races");
                });

            modelBuilder.Entity("DixRacing.Domain.Teams.Team", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("DixRacing.Domain.Utility.Car", b =>
                {
                    b.Navigation("EventCars");
                });
#pragma warning restore 612, 618
        }
    }
}
