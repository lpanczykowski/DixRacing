﻿// <auto-generated />
using System;
using DixRacing.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DixRacing.DataAccess.Migrations
{
    [DbContext(typeof(DixRacingDbContext))]
    [Migration("20220217195614_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.14");

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

                    b.Property<DateTime>("SigningTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoundId");

                    b.ToTable("Races");
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

            modelBuilder.Entity("DixRacing.Domain.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DiscordId")
                        .HasColumnType("TEXT");

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

                    b.HasKey("Id");

                    b.ToTable("Users");
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

            modelBuilder.Entity("DixRacing.Domain.Races.Race", b =>
                {
                    b.HasOne("DixRacing.Domain.Rounds.Round", "Round")
                        .WithMany("Races")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Round");
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
                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("DixRacing.Domain.Rounds.Round", b =>
                {
                    b.Navigation("Races");
                });
#pragma warning restore 612, 618
        }
    }
}
