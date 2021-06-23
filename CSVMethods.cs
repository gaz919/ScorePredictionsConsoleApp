using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace ScoreConsoleApp
{
    // class created by Garry Marshall 23/06/2021 for portfolio
    public class CSVMethods
    {

        // modified version of built in CSV reader as noted here http://codeskaters.blogspot.com/2015/11/c-easiest-csv-parser-built-in-net.html

        // original code supplied below, I had to create a method, remove unnecessary items and add list using a custom class as the type

        //        using Microsoft.VisualBasic.FileIO;

        //var path = @"C:\Person.csv"; // Habeeb, "Dubai Media City, Dubai"
        //using (TextFieldParser csvParser = new TextFieldParser(path))
        //{
        // csvParser.CommentTokens = new string[] { "#" };
        //csvParser.SetDelimiters(new string[] { "," });
        //csvParser.HasFieldsEnclosedInQuotes = true;

        //// Skip the row with the column names
        //csvParser.ReadLine();

        //while (!csvParser.EndOfData)
        //{
        //    // Read current line fields, pointer moves to the next line.
        //    string[] fields = csvParser.ReadFields();
        //    string Name = fields[0];
        //    string Address = fields[1];
        //}
        //}


        // method takes CSV contents and puts required items into a list which gets sorted and returned
        public List<LeagueResults> ConvertCSVToLeagueResults(string filename)
        {
            LeagueResults leagueResults;
            List<LeagueResults> leagueResultsList = new List<LeagueResults>();
            
            var path = filename; 
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                csvParser.ReadLine();
                

                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();

                    leagueResults = new LeagueResults();
                    leagueResults.LeagueRef = fields[0];

                    //need cleaner way to add time to date
                    DateTime dt = DateTime.Parse(fields[1]);
                    TimeSpan ts = TimeSpan.Parse(fields[2]);
                    DateTime newDate = dt.Add(ts);
                    leagueResults.MatchDate = DateTime.Parse(newDate.ToString());

                    leagueResults.HomeTeam = fields[3];
                    leagueResults.AwayTeam = fields[4];
                    leagueResults.HomeScore = int.Parse(fields[5]);
                    leagueResults.AwayScore = int.Parse(fields[6]);
                    leagueResults.HomeScoreHalfTime = int.Parse(fields[8]);
                    leagueResults.AwayScoreHalfTime = int.Parse(fields[9]);

                    // this can be used to see if record has already been added when tables and databases are used, can be changed if needed
                    leagueResults.MatchID = leagueResults.MatchDate + " " + leagueResults.HomeTeam + " " + leagueResults.AwayTeam + " " + leagueResults.HomeScore + " " + leagueResults.AwayScore;

                    //add results to a list
                    leagueResultsList.Add(leagueResults);
                }
            }
            leagueResultsList.Sort((date1, date2) => date2.MatchDate.CompareTo(date1.MatchDate));// reverse order - last match is first record based on date, could be wrong by time
            return leagueResultsList;
        }
    }
}
