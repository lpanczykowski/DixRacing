using DixRacing.Data.Entites;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DixRacing.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;
            var data = await System.IO.File.ReadAllTextAsync("../DixRacing.Data/Seeds/UsersSeedData.json");
            var deserializedData = JsonConvert.DeserializeObject<List<Users>>(data);
            using var hmac = new HMACSHA512();
            foreach (var item in deserializedData)
            {
                item.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("admin"));
                item.PasswordSalt = hmac.Key;
                context.Users.Add(item);
            }
            await context.SaveChangesAsync();

        }
        public static async Task SeedGames(DataContext context)
        {

            if (await context.Games.AnyAsync()) return;

            var gamesData = await System.IO.File.ReadAllTextAsync("../DixRacing.Data/Seeds/GamesSeedData.json");
            var games = JsonConvert.DeserializeObject<List<Games>>(gamesData);
            foreach (var game in games)
            {
                context.Games.Add(game);
            }
            await context.SaveChangesAsync();
        }

        public static async Task SeedTracks(DataContext context)
        {
            if (await context.Tracks.AnyAsync()) return;

            var tracksData = await System.IO.File.ReadAllTextAsync("../DixRacing.Data/Seeds/TracksSeedData.json");
            var tracks = JsonConvert.DeserializeObject<List<Tracks>>(tracksData);
            foreach (var track in tracks)
            {
                context.Tracks.Add(track);
            }
            await context.SaveChangesAsync();
        }
        public static async Task SeedEvents(DataContext context)
        {
            if (await context.Events.AnyAsync()) return;
            var data = await System.IO.File.ReadAllTextAsync("../DixRacing.Data/Seeds/EventsSeedData.json");
            var deserializedData = JsonConvert.DeserializeObject<List<Events>>(data);
            foreach (var item in deserializedData)
            {
                context.Events.Add(item);
            }
            await context.SaveChangesAsync();
        }
        public static async Task SeedRounds(DataContext context)
        {
            if (await context.Rounds.AnyAsync()) return;
            var data = await System.IO.File.ReadAllTextAsync("../DixRacing.Data/Seeds/RoundsSeedData.json");
            var deserializedData = JsonConvert.DeserializeObject<List<Rounds>>(data);
            foreach (var item in deserializedData)
            {
                context.Rounds.Add(item);
            }
            await context.SaveChangesAsync();
        }
        public static async Task SeedRaces(DataContext context)
        {
            if (await context.Races.AnyAsync()) return;

            var data = await System.IO.File.ReadAllTextAsync("../DixRacing.Data/Seeds/RacesSeedData.json");
            var deserializedData = JsonConvert.DeserializeObject<List<Races>>(data);
            foreach (var item in deserializedData)
            {
                context.Races.Add(item);
            }
            await context.SaveChangesAsync();
        }
        public static async Task SeedRacePoints(DataContext context)
        {
            if (await context.RacePoints.AnyAsync()) return;

            var data = await System.IO.File.ReadAllTextAsync("../DixRacing.Data/Seeds/RacePointsSeedData.json");
            var deserializedData = JsonConvert.DeserializeObject<List<RacePoints>>(data);
            foreach (var item in deserializedData)
            {
                context.RacePoints.Add(item);
            }
            await context.SaveChangesAsync();
        }

        public static async Task SeedParcipitians(DataContext context)
        {
            if (await context.EventParticipants.AnyAsync()) return;
            var data = await System.IO.File.ReadAllTextAsync("../DixRacing.Data/Seeds/ParcipitiansSeedData.json");
            var deserializedData = JsonConvert.DeserializeObject<List<EventParticipants>>(data);
            foreach (var item in deserializedData)
            {
                context.EventParticipants.Add(item);
            }
            await context.SaveChangesAsync();
        }

    }
}