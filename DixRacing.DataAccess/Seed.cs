using DixRacing.Domain.Events;
using DixRacing.Domain.Races;
using DixRacing.Domain.Rounds;
using DixRacing.Domain.Teams;
using DixRacing.Domain.Users;
using DixRacing.Domain.Utility;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DixRacing.DataAccess
{
    public class Seed
    {
        public static async Task SeedUsers(DixRacingDbContext context)
        {
            if (await context.Users.AnyAsync()) return;
            var data = await System.IO.File.ReadAllTextAsync("../DixRacing.DataAccess/Seeds/UsersSeedData.json");
            var deserializedData = JsonConvert.DeserializeObject<List<User>>(data);
            using var hmac = new HMACSHA512();
            foreach (var item in deserializedData)
            {
                item.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("admin"));
                item.PasswordSalt = hmac.Key;
                context.Users.Add(item);
            }
            await context.SaveChangesAsync();

        }
        // public static async Task SeedGames(DixRacingDbContext context)
        // {

        //     if (await context.Games.AnyAsync()) return;

        //     var gamesData = await System.IO.File.ReadAllTextAsync("../DixRacing.DataAccess/Seeds/GamesSeedData.json");
        //     var games = JsonConvert.DeserializeObject<List<Game>>(gamesData);
        //     foreach (var game in games)
        //     {
        //         context.Games.Add(game);
        //     }
        //     await context.SaveChangesAsync();
        // }

        public static async Task SeedTracks(DixRacingDbContext context)
        {
            if (await context.Tracks.AnyAsync()) return;

            var tracksData = await System.IO.File.ReadAllTextAsync("../DixRacing.DataAccess/Seeds/TracksSeedData.json");
            var tracks = JsonConvert.DeserializeObject<List<Track>>(tracksData);
            foreach (var track in tracks)
            {
                context.Tracks.Add(track);
            }
            await context.SaveChangesAsync();
        }
        public static async Task SeedEvents(DixRacingDbContext context)
        {
            if (await context.Events.AnyAsync()) return;
            var data = await System.IO.File.ReadAllTextAsync("../DixRacing.DataAccess/Seeds/EventsSeedData.json");
            var deserializedData = JsonConvert.DeserializeObject<List<Event>>(data);
            foreach (var item in deserializedData)
            {
                context.Events.Add(item);

            }
            await context.SaveChangesAsync();
        }
        public static async Task SeedRounds(DixRacingDbContext context)
        {
            if (await context.Rounds.AnyAsync()) return;
            var data = await System.IO.File.ReadAllTextAsync("../DixRacing.DataAccess/Seeds/RoundsSeedData.json");
            var deserializedData = JsonConvert.DeserializeObject<List<Round>>(data);
            foreach (var item in deserializedData)
            {
                context.Rounds.Add(item);
            }
            await context.SaveChangesAsync();
        }
        public static async Task SeedRaces(DixRacingDbContext context)
        {
            if (await context.Races.AnyAsync()) return;

            var data = await System.IO.File.ReadAllTextAsync("../DixRacing.DataAccess/Seeds/RacesSeedData.json");
            var deserializedData = JsonConvert.DeserializeObject<List<Race>>(data);
            foreach (var item in deserializedData)
            {
                context.Races.Add(item);
            }
            await context.SaveChangesAsync();
        }
        // public static async Task SeedRacePoints(DixRacingDbContext context)
        // {
        //     if (await context.RacePoints.AnyAsync()) return;

        //     var data = await System.IO.File.ReadAllTextAsync("../DixRacing.DataAccess/Seeds/RacePointsSeedData.json");
        //     var deserializedData = JsonConvert.DeserializeObject<List<RacePoint>>(data);
        //     foreach (var item in deserializedData)
        //     {
        //         context.RacePoints.Add(item);
        //     }
        //     await context.SaveChangesAsync();
        // }

        public static async Task SeedParticipants(DixRacingDbContext context)
        {
            if (await context.EventParticipants.AnyAsync()) return;
            var data = await System.IO.File.ReadAllTextAsync("../DixRacing.DataAccess/Seeds/ParcipitiansSeedData.json");
            var deserializedData = JsonConvert.DeserializeObject<List<EventParticipant>>(data);
            foreach (var item in deserializedData)
            {
                context.EventParticipants.Add(item);
            }
            await context.SaveChangesAsync();
        }
         public static async Task SeedTeams(DixRacingDbContext context)
        {
            if (await context.Teams.AnyAsync()) return;
            var data = await System.IO.File.ReadAllTextAsync("../DixRacing.DataAccess/Seeds/TeamsSeedData.json");
            var deserializedData = JsonConvert.DeserializeObject<List<Team>>(data);
            foreach (var item in deserializedData)
            {
                context.Teams.Add(item);
            }
            await context.SaveChangesAsync();
        }

    }
}