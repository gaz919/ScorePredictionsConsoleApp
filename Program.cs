
namespace ScoreConsoleApp
{
    // program created by Garry Marshall 23/06/2021 for portfolio
    class Program
    {

        static void Main(string[] args)
        {
            // creates new instance of Predictions class
            Predictions predict = new Predictions();

            // CSV used has these matches omitted from them and the predicted results are printed to console
            predict.GetOutcome("Arsenal", "Brighton"); // actual result was 
            predict.GetOutcome("Aston Villa", "Chelsea");
            predict.GetOutcome("Fulham", "Newcastle");

            // expected output to console

            //Arsenal V Brighton
            //1 - 0
            //Result = Arsenal

            //Aston Villa V Chelsea
            //0 - 1
            //Result = Chelsea

            //Fulham V Newcastle
            //1 - 2
            //Result = Newcastle

        }
    }

}
