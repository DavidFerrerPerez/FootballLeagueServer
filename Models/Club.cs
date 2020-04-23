using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeagueServer.Models
{
    public class Club
    {
        [Key]
        public string Name { get; set; }
        public int Position { get; set; }
        public int Points { get; set; }

        public int GoalDifference { get; set; }
    }
}
