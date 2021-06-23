using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreConsoleApp
{
    // class created by Garry Marshall 23/06/2021 for portfolio

    // class contains private and public varibles used to store data for lists
    public class LeagueResults
    {
        private string matchID;
        private string leagueRef;
        private DateTime matchDate;
        private string homeTeam;
        private string awayTeam;
        private int homeScore;
        private int awayScore;
        private int homeScoreHalfTime;
        private int awayScoreHalfTime;


        public string MatchID { get => matchID; set => matchID = value; }
        public DateTime MatchDate { get => matchDate; set => matchDate = value; }
        public string HomeTeam { get => homeTeam; set => homeTeam = value; }
        public string AwayTeam { get => awayTeam; set => awayTeam = value; }
        public int HomeScore { get => homeScore; set => homeScore = value; }
        public int AwayScore { get => awayScore; set => awayScore = value; }
        public int HomeScoreHalfTime { get => homeScoreHalfTime; set => homeScoreHalfTime = value; }
        public int AwayScoreHalfTime { get => awayScoreHalfTime; set => awayScoreHalfTime = value; }
        public string LeagueRef { get => leagueRef; set => leagueRef = value; }

    }
}
