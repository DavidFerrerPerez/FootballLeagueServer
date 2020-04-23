using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballLeagueServer.Models;

namespace FootballLeagueServer.Controllers
{
    public static class DBSeeder
    {
        public static void SeedDB(ClubContext context)
        {
            context.Database.EnsureCreated();
            context.Clubs.Add(
                new Club() { Name = "Valencia", Position = 1, GoalDifference = +25, Points = 78 }
                );
            context.Clubs.Add(
                new Club() { Name = "Levante", Position = 2, GoalDifference = +21, Points = 70 }
                );
            context.Clubs.Add(
                new Club() { Name = "Vila-real", Position = 3, GoalDifference = +24, Points = 69 }
                );
            context.Clubs.Add(
                new Club() { Name = "Betis", Position = 4, GoalDifference = +14, Points = 64 }
                );
            context.Clubs.Add(
                new Club() { Name = "Real Sociedad", Position = 5, GoalDifference = +13, Points = 58 }
                );
            context.Clubs.Add(
                new Club() { Name = "Espanyol", Position = 6, GoalDifference = +4, Points = 55 }
                );
            context.Clubs.Add(
                new Club() { Name = "Sevilla", Position = 7, GoalDifference = -9, Points = 54 }
                );
            context.Clubs.Add(
                new Club() { Name = "Bilbao", Position = 8, GoalDifference = -12, Points = 52 }
                );
            context.Clubs.Add(
                new Club() { Name = "Granada", Position = 9, GoalDifference = -14, Points = 50 }
                );
            context.Clubs.Add(
                new Club() { Name = "Elche", Position = 10, GoalDifference = -20, Points = 44 }
                );
            context.SaveChanges();
        }
    }
}
