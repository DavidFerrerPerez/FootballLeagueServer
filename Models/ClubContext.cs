using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueServer.Models
{
    public class ClubContext : DbContext
    {
        public ClubContext(DbContextOptions<ClubContext> options)
            : base(options)
        {
        }

        public DbSet<Club> Clubs { get; set; }
    }
}
