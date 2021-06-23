using System.Collections.Generic;

namespace ScoreConsoleApp
{
    // class created by Garry Marshall 23/06/2021 for portfolio
    public class LinqMethods
    {
        
        // calls CSV method which converts a csv to list which is then returned
        public List<LeagueResults> GetTableResults()
        {
            CSVMethods csvM = new CSVMethods();

            // filename is hardcoded - file downloaded from https://www.football-data.co.uk/englandm.php
            // Premier League - Season 2020/2021
            return csvM.ConvertCSVToLeagueResults("C:\\Users\\gaz91\\Desktop\\E0.csv");
        }

        // find all matches for a team, checks home and away
        public List<LeagueResults> GetTeamSeasonMatchInfo(string teamName)
        {
            return GetTableResults().FindAll(t => t.HomeTeam == teamName || t.AwayTeam == teamName);
        }

        // complies data returned for each match for a team and returns it as a rating
        public TeamRating GetTeamStats(string theTeamName)
        {
            TeamRating teamRating = new TeamRating();
            teamRating.TeamName = theTeamName;

            LinqMethods linqMethods = new LinqMethods();
            teamRating.TeamResults = linqMethods.GetTeamSeasonMatchInfo(teamRating.TeamName);

            // goes through each match and stats are updated each time - method could be done in teamratings class and return full stats
            foreach (LeagueResults item in teamRating.TeamResults)
            {
                teamRating.UpdateTeamStatsFromResult(item);
            }

            return teamRating;
        }

    }
}
