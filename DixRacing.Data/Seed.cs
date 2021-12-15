using DixRacing.Data.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DixRacing.Data
{
    public class Seed
    {
         public static async Task SeedGames(DataContext context)
        {
            if (await context.Games.AnyAsync()) return;

            var gamesData = await System.IO.File.ReadAllTextAsync("../DixRacing.Data/GamesSeedData.json");
            var games = JsonSerializer.Deserialize<List<Games>>(gamesData);
            foreach (var game in games)
            {
                context.Games.Add(game);
            }
        await context.SaveChangesAsync();
        }
        
    }
}