using LuckyDreamTeam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LuckyDreamTeam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public string PostedData(string playerList)
        {
            List<PlayerDetails> playersDetails = JsonConvert.DeserializeObject<List<PlayerDetails>>(playerList);

            int minWicketKeepers = 1;
            int maxWicketKeepers = 3;
            int minBatsmen = 3;
            int maxBatsmen = 5;
            int minAllRounders = 1;
            int maxAllRounders = 3;
            int minBowlers = 3;

            int totalCount = 11;
            int maxPlayerPerTeam = 7;
            int maxCredit = 100;

            List<PlayersDataList> TeamWicketKeepers = new List<PlayersDataList>();
            List<PlayersDataList> TeamBatsmens = new List<PlayersDataList>();
            List<PlayersDataList> TeamAllRounders = new List<PlayersDataList>();
            List<PlayersDataList> TeamBowlers = new List<PlayersDataList>();

            List<PlayersDataList> OutputPlayers = new List<PlayersDataList>();

            foreach (PlayerDetails players in playersDetails)
            {
                if(players.PlayerTypeA == PlayerTypes.WicketKeeper)
                {
                    PlayersDataList TeamWicketKeepersData = new PlayersDataList();
                    TeamWicketKeepersData.PlayerName = players.PlayerNameA;
                    TeamWicketKeepersData.PlayerCredits = players.PlayerCreditA;
                    TeamWicketKeepersData.TeamName = TeamNames.TeamA.ToString();
                    TeamWicketKeepersData.PlayerType = players.PlayerTypeA.ToString();
                    TeamWicketKeepersData.PlayerDesignation = PlayerValue.Player;
                    TeamWicketKeepers.Add(TeamWicketKeepersData);
                }
                if(players.PlayerTypeB == PlayerTypes.WicketKeeper)
                {
                    PlayersDataList TeamWicketKeepersData = new PlayersDataList();
                    TeamWicketKeepersData.PlayerName = players.PlayerNameB;
                    TeamWicketKeepersData.PlayerCredits = players.PlayerCreditB;
                    TeamWicketKeepersData.TeamName = TeamNames.TeamB.ToString();
                    TeamWicketKeepersData.PlayerType = players.PlayerTypeB.ToString();
                    TeamWicketKeepersData.PlayerDesignation = PlayerValue.Player;
                    TeamWicketKeepers.Add(TeamWicketKeepersData);
                }
                if (players.PlayerTypeA == PlayerTypes.Batsmen)
                {
                    PlayersDataList TeamBatsmensData = new PlayersDataList();
                    TeamBatsmensData.PlayerName = players.PlayerNameA;
                    TeamBatsmensData.PlayerCredits = players.PlayerCreditA;
                    TeamBatsmensData.TeamName = TeamNames.TeamA.ToString();
                    TeamBatsmensData.PlayerType = players.PlayerTypeA.ToString();
                    TeamBatsmensData.PlayerDesignation = PlayerValue.Player;
                    TeamBatsmens.Add(TeamBatsmensData);
                }
                if (players.PlayerTypeB == PlayerTypes.Batsmen)
                {
                    PlayersDataList TeamBatsmensData = new PlayersDataList();
                    TeamBatsmensData.PlayerName = players.PlayerNameB;
                    TeamBatsmensData.PlayerCredits = players.PlayerCreditB;
                    TeamBatsmensData.TeamName = TeamNames.TeamB.ToString();
                    TeamBatsmensData.PlayerType = players.PlayerTypeB.ToString();
                    TeamBatsmensData.PlayerDesignation = PlayerValue.Player;
                    TeamBatsmens.Add(TeamBatsmensData);
                }
                if (players.PlayerTypeA == PlayerTypes.AllRounder)
                {
                    PlayersDataList TeamAllRoundersData = new PlayersDataList();
                    TeamAllRoundersData.PlayerName = players.PlayerNameA;
                    TeamAllRoundersData.PlayerCredits = players.PlayerCreditA;
                    TeamAllRoundersData.TeamName = TeamNames.TeamA.ToString();
                    TeamAllRoundersData.PlayerType = players.PlayerTypeA.ToString();
                    TeamAllRoundersData.PlayerDesignation = PlayerValue.Player;
                    TeamAllRounders.Add(TeamAllRoundersData);
                }
                if (players.PlayerTypeB == PlayerTypes.AllRounder)
                {
                    PlayersDataList TeamAllRoundersData = new PlayersDataList();
                    TeamAllRoundersData.PlayerName = players.PlayerNameB;
                    TeamAllRoundersData.PlayerCredits = players.PlayerCreditB;
                    TeamAllRoundersData.TeamName = TeamNames.TeamB.ToString();
                    TeamAllRoundersData.PlayerType = players.PlayerTypeB.ToString();
                    TeamAllRoundersData.PlayerDesignation = PlayerValue.Player;
                    TeamAllRounders.Add(TeamAllRoundersData);
                }
                if (players.PlayerTypeA == PlayerTypes.Bowler)
                {
                    PlayersDataList TeamBowlersData = new PlayersDataList();
                    TeamBowlersData.PlayerName = players.PlayerNameA;
                    TeamBowlersData.PlayerCredits = players.PlayerCreditA;
                    TeamBowlersData.TeamName = TeamNames.TeamA.ToString();
                    TeamBowlersData.PlayerType = players.PlayerTypeA.ToString();
                    TeamBowlersData.PlayerDesignation = PlayerValue.Player;
                    TeamBowlers.Add(TeamBowlersData);
                }
                if (players.PlayerTypeB == PlayerTypes.Bowler)
                {
                    PlayersDataList TeamBowlersData = new PlayersDataList();
                    TeamBowlersData.PlayerName = players.PlayerNameB;
                    TeamBowlersData.PlayerCredits = players.PlayerCreditB;
                    TeamBowlersData.TeamName = TeamNames.TeamB.ToString();
                    TeamBowlersData.PlayerType = players.PlayerTypeB.ToString();
                    TeamBowlersData.PlayerDesignation = PlayerValue.Player;
                    TeamBowlers.Add(TeamBowlersData);
                } 
            }

            Random rd = new Random();

            int randomWicketKeeperNumber = minWicketKeepers;
            int randomBatsmenNumber = minBatsmen;
            int randomAllRoundersNumber = minAllRounders;
            int randomBowelrsNumber = minBowlers;
            int countOfOneTeam;
            double totalCredits;

            do
            {
                OutputPlayers.Clear();

                do
                {
                    randomWicketKeeperNumber = rd.Next(minWicketKeepers, maxWicketKeepers + 1);
                } while ((totalCount - randomWicketKeeperNumber) < (minBatsmen + minAllRounders + minBowlers));

                do
                {
                    randomBatsmenNumber = rd.Next(minBatsmen, maxBatsmen + 1);
                } while ((totalCount - randomWicketKeeperNumber - randomBatsmenNumber) < (minAllRounders + minBowlers));

                do
                {
                    randomAllRoundersNumber = rd.Next(minAllRounders, maxAllRounders + 1);
                } while ((totalCount - randomWicketKeeperNumber - randomBatsmenNumber - randomAllRoundersNumber) < (minBowlers));

                randomBowelrsNumber = totalCount - randomWicketKeeperNumber - randomBatsmenNumber - randomAllRoundersNumber;

                OutputPlayers.AddRange(GetRandomElements(TeamWicketKeepers, randomWicketKeeperNumber));
                OutputPlayers.AddRange(GetRandomElements(TeamBatsmens, randomBatsmenNumber));
                OutputPlayers.AddRange(GetRandomElements(TeamAllRounders, randomAllRoundersNumber));
                OutputPlayers.AddRange(GetRandomElements(TeamBowlers, randomBowelrsNumber));

                countOfOneTeam = OutputPlayers.Where(x => x.TeamName == TeamNames.TeamA.ToString()).Count();
                totalCredits = OutputPlayers.Select(x => x.PlayerCredits ?? 0).Sum();
            } while (countOfOneTeam <= (totalCount-maxPlayerPerTeam) || countOfOneTeam >= maxPlayerPerTeam || totalCredits > maxCredit);

            int? indexCaptain = null;
            int indexViceCaptain = 0;
            for (int i = 0; i < 2; i++)
            {
                if (indexCaptain == null)
                {
                    indexCaptain = rd.Next(OutputPlayers.Count);
                    OutputPlayers[(int)indexCaptain].PlayerDesignation = PlayerValue.Captain;
                }
                else
                {
                    do
                    {
                        indexViceCaptain = rd.Next(OutputPlayers.Count);
                    } while (indexViceCaptain == (int)indexCaptain);
                    OutputPlayers[(int)indexViceCaptain].PlayerDesignation = PlayerValue.ViceCaptain;
                }
            }

            return JsonConvert.SerializeObject(OutputPlayers);
        }

        public List<T> GetRandomElements<T>(IEnumerable<T> list, int count) {
            return list.OrderBy(x => Guid.NewGuid()).Take(count).ToList();
        }
    }
}
