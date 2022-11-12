using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuckyDreamTeam.Models
{
    public class PlayersDataList
    {
        public string PlayerName { get; set; }
        public string TeamName { get; set; }
        public double? PlayerCredits { get; set; }
        public string PlayerType { get; set; }
        public PlayerValue PlayerDesignation { get; set; }
    }
}
