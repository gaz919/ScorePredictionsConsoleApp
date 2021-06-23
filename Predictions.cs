using System;
namespace ScoreConsoleApp
{
    // class created by Garry Marshall 23/06/2021 for portfolio

    // class contains prediction logic and returns the prediction via console output
    public class Predictions
    {
        // private variables
        TeamRating homeTeam;
        TeamRating awayTeam;

        // public variables
        public TeamRating HomeTeam { get => homeTeam; set => homeTeam = value; }
        public TeamRating AwayTeam { get => awayTeam; set => awayTeam = value; }

        // private method used to return a teams ratings
        private TeamRating GetTeamRatings(string theTeamName)
        {
            LinqMethods linqMethods = new LinqMethods();
            TeamRating teamOneRating = new TeamRating();
            teamOneRating.TeamName = theTeamName;
            teamOneRating = linqMethods.GetTeamStats(teamOneRating.TeamName);
            return teamOneRating;
        }

        // two teams passed in and logic determines result - outputs to console
        private void ExpectedScore(TeamRating team1, TeamRating team2)
        {
            float homeScore = (team1.HomePlayed / team1.HomeGoalsScored) - (team2.AwayPlayed / team2.AwayGoalsAgainst);
            float awayScore = (team2.AwayPlayed / team2.AwayGoalsScored) - (team1.HomePlayed / team1.HomeGoalsAgainst);
            string outcome = "";
            
            if (homeScore < 0)
            {
                homeScore = 0;
            }
            if (awayScore < 0)
            {
                awayScore = 0;
            }

            if (homeScore == awayScore)
            {
                homeScore += team1.HomeDraws / 10;
                awayScore += team2.AwayDraws / 10;
            }

            if (team1.HomeRating > team2.AwayRating)
            {
                homeScore += 1f;
                awayScore -= 1f;
            }
            else if (team1.HomeRating < team2.AwayRating)
            {
                awayScore += 1f;
                homeScore -= 1f;
            }
            else if (team1.HomeDraws > team2.AwayDraws)
            {

            }

            if (homeScore < 0)
            {
                homeScore = 0;
            }
            if (awayScore < 0)
            {
                awayScore = 0;
            }

            if (homeScore > awayScore)
            {
                outcome = team1.TeamName;
            }
            if (homeScore < awayScore)
            {
                outcome = team2.TeamName;
            }
            if (homeScore == awayScore)
            {
                outcome = "Draw";
            }

            Console.WriteLine(team1.TeamName + " V " + team2.TeamName);
            Console.WriteLine(homeScore + " - " + awayScore);
            Console.WriteLine("Result = " + outcome);
            Console.WriteLine();
        }

        // public method, input teams as strings
        public void GetOutcome(string theHomeTeam, string theAwayTeam)
        {
            // updates private variables already declared
            HomeTeam = GetTeamRatings(theHomeTeam);
            AwayTeam = GetTeamRatings(theAwayTeam);

            // call expectedscore method passing in the ratings/stats for each team
            ExpectedScore(HomeTeam, AwayTeam);

        }

    }
}
