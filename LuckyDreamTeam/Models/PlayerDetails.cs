using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuckyDreamTeam.Models
{
    public class PlayerDetails
    {
        public int PlayerNo { get; set; }
        public string PlayerNameA { get; set; }
        public PlayerTypes PlayerTypeA { get; set; }
        public double? PlayerCreditA { get; set; }
        public string PlayerNameB { get; set; }
        public PlayerTypes PlayerTypeB { get; set; }
        public double? PlayerCreditB { get; set; }
    }
}
