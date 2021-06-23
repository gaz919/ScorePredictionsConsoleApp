# ScorePredictionsConsoleApp
Create predictions based on past data

Date CSV file used with this app can be found on https://www.football-data.co.uk/englandm.php

Premier League 2020 - 2021

CSV can be download directly using link below

https://www.football-data.co.uk/mmz4281/2021/E0.csv

Then sort by date by newest date and remove first 3 result records so they can be predicted

Filepath to CSV can be changed in the LinqMethods class in the method below

        public List<LeagueResults> GetTableResults()
        {
            CSVMethods csvM = new CSVMethods();

            // filename is hardcoded - file downloaded from https://www.football-data.co.uk/englandm.php
            // Premier League - Season 2020/2021
            return csvM.ConvertCSVToLeagueResults("C:\\Users\\gaz91\\Desktop\\E0.csv");
        }
