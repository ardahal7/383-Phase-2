using Android.App;
using Android.App.Usage;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Java.Sql;
using Newtonsoft.Json;
using RiotSharp;
using RiotSharp.StaticDataEndpoint;
using RiotSharp.StatsEndpoint;
using RiotSharp.StatsEndpoint.Enums;
using RiotSharp.SummonerEndpoint;
using RiotSharp.MatchEndpoint;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using RiotSharp.ChampionEndpoint;
using RiotSharp.GameEndpoint;
using RiotSharp.StaticDataEndpoint.Champion;


namespace CMPS383Phase2
{
    public class Info : Activity
    {
        int i;
        private RiotApi api = RiotApi.GetInstance("RGAPI-cc2a5a60-fbfc-4a0e-951a-e866b872b307");
        private StaticRiotApi staticApi = StaticRiotApi.GetInstance("RGAPI-cc2a5a60-fbfc-4a0e-951a-e866b872b307");
        private Region region = Region.na;
        public string input;

        //Summoner
        public long id;
        public string name;
        public int profileIconId;
        public DateTime revisionDate;
        public long summonerLevel;
        public Summoner getSummoner;

        //stats Summary
        public List<PlayerStatsSummary> stats;
        public AggregatedStat[] aggregateStats;
        public int losses;
        public DateTime modifyDate;
        public PlayerStatsSummaryType playerStatSummaryType;
        public int wins;

        //aggregate stats
        /* private static int averageAssists;
         private static int averageChampionsKilled;
         private static int averageCombatPlayerScore;
         private static int averageNodeCapture;
         private static int averageNodeCaptureAssist;
         private static int averageNodeNeutralize;
         private static int averageNodeNeutralizeAssist;
         private static int averageNumDeaths;
         private static int averageObjectivePlayerScore;
         private static int averageTeamObjective;
         private static int averageTotalPlayerScore;
         private static int botGamesPlayed;
         private static int killingSpree;
         private static int maxAssists;
         private static int maxChampionsKilled;
         private static int maxCombatPlayerScore;
         private static int maxLargestCriticalStrike;
         private static int maxLargestKillingSpree;
         private static int maxNodeCapture;
         private static int maxNodeCaptureAssist;
         private static int maxNodeNeutralize;
         private static int maxNodeNeutralizeAssist;
         private static int maxNumDeaths;
         private static int maxObjectivePlayerScore;
         private static int maxTeamObjective;
         private static int maxTimePlayed;
         private static int maxTimeSpentLiving;
         private static int maxTotalPlayerScore;
         private static int mostChampionKillsPerSession;
         private static int mostSpellsCast;
         private static int normalGamesPlayed;
         private static int rankedPremadeGamesPlayed;
         private static int rankedSoloGamesPlayed;
         private static int totalAssists;
         private static int totalChampionKills;
         private static int totalDamageDealt;
         private static int totalDamageTaken;
         private static int totalDeathsPerSession;
         private static int totalDoubleKills;
         private static int totalFirstBlood;
         private static int totalGoldEarned;
         private static int totalHeal;
         private static int totalMagicDamageDealt;
         private static int totalMinionKills;
         private static int totalNeutralMinionsKilled;
         private static int totalNodeCapture;
         private static int totalNodeNeutralize;
         private static int totalPentaKills;
         private static int totalPhysicalDamageDealt;
         private static int totalQuadraKills;
         private static int totalSessionsLost;
         private static int totalSessionsPlayed;
         private static int totalSessionsWon;
         private static int totalTripleKills;
         private static int totalTurretsKilled;
         private static int totalUnrealKills; */

        //match list
        public int endIndex;
        public int startIndex;
        public int totalGames;
        public MatchList matchList;
        public MatchReference matchDetails;

        //champion
        public List<Champion> championList;
        public string championName;
        public Champion championData;
        public string profileIcon;

        //game
        public Game game;
        public List<Game> games;
        public long gameId;
        public int mapId;


        //as of now, app has stats for: summoner id, name, revision date, level, basic stats

        public void GetSummoner(Region region, string input)
        {
            getSummoner = api.GetSummoner(region, input);
            id = getSummoner.Id;
            name = getSummoner.Name;
            profileIconId = getSummoner.ProfileIconId;
            revisionDate = getSummoner.RevisionDate;
            summonerLevel = getSummoner.Level;
            championName = staticApi.GetChampion(region, profileIconId).Name;
            profileIcon = staticApi.GetChampion(region, profileIconId).Image.Sprite;
        }

        public void GetGame()
        {

            games = api.GetRecentGames(region, id);
            for (int i = 0; i < 10; i++)
            {
                gameId = games[i].GameId;

                
            }





        }






    public void Main()
        {
            //summoner request
            getSummoner = api.GetSummoner(region, input);
            id = getSummoner.Id;
            name = getSummoner.Name;
            profileIconId = getSummoner.ProfileIconId;
            revisionDate = getSummoner.RevisionDate;
            summonerLevel = getSummoner.Level;

            //stat summary request
            stats = api.GetStatsSummaries(region, id);
            //need to add a loop here
            aggregateStats[0] = stats[0].AggregatedStats;
            losses = stats[0].Losses;
            wins = stats[0].Wins;
            modifyDate = stats[0].ModifyDate;
            playerStatSummaryType = stats[0].PlayerStatSummaryType;

            // initialize array for aggregate stats, possible loop later
            int[] aggregates = new int[56]
            {
                aggregateStats[0].AverageAssists,
                aggregateStats[0].AverageChampionsKilled,
                aggregateStats[0].AverageCombatPlayerScore,
                aggregateStats[0].AverageNodeCapture,
                aggregateStats[0].AverageNodeCaptureAssist,
                aggregateStats[0].AverageNodeNeutralize,
                aggregateStats[0].AverageNodeNeutralizeAssist,
                aggregateStats[0].AverageNumDeaths,
                aggregateStats[0].AverageObjectivePlayerScore,
                aggregateStats[0].AverageTeamObjective,
                aggregateStats[0].AverageTotalPlayerScore,
                aggregateStats[0].BotGamesPlayed,
                aggregateStats[0].KillingSpree,
                aggregateStats[0].MaxAssists,
                aggregateStats[0].MaxChampionsKilled,
                aggregateStats[0].MaxCombatPlayerScore,
                aggregateStats[0].MaxLargestCriticalStrike,
                aggregateStats[0].MaxLargestKillingSpree,
                aggregateStats[0].MaxNodeCapture,
                aggregateStats[0].MaxNodeCaptureAssist,
                aggregateStats[0].MaxNodeNeutralize,
                aggregateStats[0].MaxNodeNeutralizeAssist,
                aggregateStats[0].AverageNumDeaths,
                aggregateStats[0].MaxObjectivePlayerScore,
                aggregateStats[0].MaxTeamObjective,
                aggregateStats[0].MaxTimePlayed,
                aggregateStats[0].MaxTimeSpentLiving,
                aggregateStats[0].MaxTotalPlayerScore,
                aggregateStats[0].MostChampionKillsPerSession,
                aggregateStats[0].MostSpellsCast,
                aggregateStats[0].NormalGamesPlayed,
                aggregateStats[0].RankedPremadeGamesPlayed,
                aggregateStats[0].RankedSoloGamesPlayed,
                aggregateStats[0].TotalAssists,
                aggregateStats[0].TotalChampionKills,
                aggregateStats[0].TotalDamageDealt,
                aggregateStats[0].TotalDamageTaken,
                aggregateStats[0].MostChampionKillsPerSession,
                aggregateStats[0].TotalDoubleKills,
                aggregateStats[0].TotalFirstBlood,
                aggregateStats[0].TotalGoldEarned,
                aggregateStats[0].TotalHeal,
                aggregateStats[0].TotalMagicDamageDealt,
                aggregateStats[0].TotalMinionKills,
                aggregateStats[0].TotalNeutralMinionsKilled,
                aggregateStats[0].TotalNodeCapture,
                aggregateStats[0].TotalNodeNeutralize,
                aggregateStats[0].TotalPentaKills,
                aggregateStats[0].TotalPhysicalDamageDealt,
                aggregateStats[0].TotalQuadraKills,
                aggregateStats[0].TotalSessionsLost,
                aggregateStats[0].TotalSessionsPlayed,
                aggregateStats[0].TotalSessionsWon,
                aggregateStats[0].TotalTripleKills,
                aggregateStats[0].TotalTurretsKilled,
                aggregateStats[0].TotalUnrealKills
            };


            //match list
            matchList = api.GetMatchList(region, id);
            //need loop here
            matchDetails = matchList.Matches[0];
            long matchID = matchDetails.MatchID;










        }

    }
}