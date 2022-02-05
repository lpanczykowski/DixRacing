using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DixRacing.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace DixRacing.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<HotLaps> RaceHotLaps { get; set; }
        public DbSet<RaceLaps> RaceLaps { get; set; }
        public DbSet<Tracks> Tracks { get; set; }
        public DbSet<EventParticipants> EventParticipants { get; set; }
        public DbSet<RaceResults> RaceResults { get; set; }
        public DbSet<Races> Races { get; set; }
        public DbSet<RaceConfirmations> RaceConfirmations { get; set; }
        public DbSet<Rounds> Rounds { get; set; }
        public DbSet<RacePoints> RacePoints { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // base.OnModelCreating(builder);
            // builder.Entity<Events>()
            //     .HasMany(s => s.Rounds)
            //     .WithOne(l => l.Event)
            //     .HasForeignKey(s => s.RoundId)
            //     .OnDelete(DeleteBehavior.Cascade);
            // builder.Entity<Rounds>()
            //     .HasOne(s=>s.Event)
            //     .WithMany(s=>s.Rounds);
        }
        
    }
}