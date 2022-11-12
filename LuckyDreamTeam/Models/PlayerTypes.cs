using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuckyDreamTeam.Models
{
    public enum PlayerTypes
    {
        NotSelected = 0,
        WicketKeeper = 1,
        Batsmen = 2,
        AllRounder = 3,
        Bowler = 4
    }

    public enum PlayerValue
    {
        Player = 0,
        Captain = 1,
        ViceCaptain = 2,
    }
}
