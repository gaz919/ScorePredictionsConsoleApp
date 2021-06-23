using System.Collections.Generic;

namespace ScoreConsoleApp
{
    // class created by Garry Marshall 23/06/2021 for portfolio
    public class TeamRating
    {
        // each private variable has a public one - Get => Set where more proctection against changes can be done
        string teamName;
        string leauge;
        List<LeagueResults> teamResults;
        int homePlayed;
        int awayPlayed;
        int homeWins;
        int homeLosses;
        int homeDraws;
        int awayWins;
        int awayLosses;
        int awayDraws;
        int homeGoalsScored;
        int awayGoalsScored;
        int homeGoalsAgainst;
        int awayGoalsAgainst;

        public string TeamName { get => teamName; set => teamName = value; }
        public string Leauge { get => leauge; set => leauge = value; }
        public List<LeagueResults> TeamResults { get => teamResults; set => teamResults = value; }
        public float GoalForRating { get => HomeGoalsScored + AwayGoalsScored; }
        public float GoalAgainstRating { get => HomeGoalsAgainst + AwayGoalsAgainst;}
        public float WinsRating { get => HomeWins + AwayWins; }
        public float LossRating { get => HomeLosses + AwayLosses; }
        public float HomeRating { get => (HomeWins-HomeLosses) + HomeDraws + (HomeGoalsScored-HomeGoalsAgainst);}
        public float AwayRating { get => (AwayWins-AwayLosses) + AwayDraws + (AwayGoalsScored-AwayGoalsAgainst);}
        public int HomePlayed { get => homePlayed; set => homePlayed = value; }
        public int AwayPlayed { get => awayPlayed; set => awayPlayed = value; }
        public int HomeWins { get => homeWins; set => homeWins = value; }
        public int HomeLosses { get => homeLosses; set => homeLosses = value; }
        public int HomeDraws { get => homeDraws; set => homeDraws = value; }
        public int AwayWins { get => awayWins; set => awayWins = value; }
        public int AwayLosses { get => awayLosses; set => awayLosses = value; }
        public int AwayDraws { get => awayDraws; set => awayDraws = value; }
        public int HomeGoalsScored { get => homeGoalsScored; set => homeGoalsScored = value; }
        public int AwayGoalsScored { get => awayGoalsScored; set => awayGoalsScored = value; }
        public int HomeGoalsAgainst { get => homeGoalsAgainst; set => homeGoalsAgainst = value; }
        public int AwayGoalsAgainst { get => awayGoalsAgainst; set => awayGoalsAgainst = value; }

        // updates goals scored for and against at home and away
        private void UpdateGoalsScored(LeagueResults result, bool home)
        {
            if (home)
            {
                HomeGoalsScored += result.HomeScore;
                HomeGoalsAgainst += result.AwayScore;
            }
            else
            {
                AwayGoalsScored += result.AwayScore;
                AwayGoalsAgainst += result.HomeScore;
            }
        }

        // increases home and away games stats, nect few methods do similar tasks
        private void UpdateGamesPlayed(LeagueResults result, bool home)
        {
            if (home)
            {
                HomePlayed += 1;
            }
            else
            {
                AwayPlayed += 1;
            }
        }

        private void AddWin(LeagueResults result,bool home)
        {
            if (home)
            {
                HomeWins += 1;
            }
            else
            {
                AwayWins += 1;
            }
        }
        private void AddLoss(LeagueResults result, bool home)
        {
            if (home)
            {
                HomeLosses -= 1;
            }
            else
            {
                AwayLosses -= 1;
            }
        }

        private void AddDraw(LeagueResults result, bool home)
        {
            if (home)
            {
                HomeDraws += 1;
            }
            else
            {
                AwayDraws += 1;
            }
        }



        // update home and away win/loss/draw stats
        public void UpdateTeamStatsFromResult(LeagueResults result)
        {

            // update home stats
            if (result.HomeTeam == teamName)
            {
                UpdateGamesPlayed(result, true);
                UpdateGoalsScored(result, true);

                if (result.HomeScore > result.AwayScore)
                {
                    AddWin(result,true);
                }
                else if (result.HomeScore < result.AwayScore)
                {
                    AddLoss(result, true);
                }
                else if (result.HomeScore == result.AwayScore)
                {
                    AddDraw(result, true);
                }
            }

            // update away stats
            if (result.AwayTeam == teamName)
            {
                UpdateGamesPlayed(result, false);
                UpdateGoalsScored(result, false);

                if (result.AwayScore > result.HomeScore)
                {
                    AddWin(result, false);
                }
                else if (result.AwayScore < result.HomeScore)
                {
                    AddLoss(result, false);
                }
                else if (result.AwayScore == result.HomeScore)
                {
                    AddDraw(result, false);
                }
            }

        }

    }
}
