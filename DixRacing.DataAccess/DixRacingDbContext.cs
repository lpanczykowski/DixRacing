using DixRacing.Domain.EventParticipants;
using DixRacing.Domain.Events;
using DixRacing.Domain.Races;
using DixRacing.Domain.Rounds;
using DixRacing.Domain.Teams;
using DixRacing.Domain.Users;
using DixRacing.Domain.Utility;
using Microsoft.EntityFrameworkCore;

namespace DixRacing.DataAccess
{
    public class DixRacingDbContext : DbContext
    {
        public DixRacingDbContext()
        {

        }
        public DixRacingDbContext(DbContextOptions<DixRacingDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=../DixRacing.DataAccess/dixracing.db");
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<RaceResult> RaceResults { get; set; }
        public DbSet<RaceLap> RaceLaps { get; set; }
        public DbSet<RacePoint> RacePoints { get; set; }
        public DbSet<RaceIncident> RaceIncidents { get; set; }
        public DbSet<Game> Games {get; set;}
        public DbSet<Car> Cars {get; set;}
        public DbSet<EventCar> EventCars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}