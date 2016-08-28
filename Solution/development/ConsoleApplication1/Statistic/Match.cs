using System;
using System.Globalization;

namespace ConsoleApplication1
{
    public enum MatchResult
    {
        Win = 0,
        Draw = 1,
        Lose = 2
    }
    /// <summary>
    /// Information about match.
    /// </summary>
    [Serializable]
    public class Match
    {
        public DateTime Data { get; set; }
        public string HomeTeameName { get; set; }
        public string AwayTeamName { get; set; }
        public int HomeTeameScore { get; set; }
        public int AwayTeamScore { get; set; }

        public Match(string data, string homeName, string result, string awayName)
        {
            Data = DateTime.Parse(data, CultureInfo.CreateSpecificCulture("fr-FR"));
            HomeTeameName = homeName;
            AwayTeamName = awayName;
            var score = result.Split(':');
            HomeTeameScore = int.Parse(score[0]);
            AwayTeamScore = int.Parse(score[1]);
        }

        public Match()
        {
        }

        public MatchResult GetResultByTeamName(string teamName)
        {
            if (teamName.Equals(HomeTeameName))
            {
                return ConverResultToEnum(HomeTeameScore, AwayTeamScore);
            }
            else
            {
                return ConverResultToEnum(AwayTeamScore, HomeTeameScore);
            }
        }

        public int GetTotalBiggerIndex()
        {
            return (HomeTeameScore + AwayTeamScore >= 3)? 0 : 1;
        }

        public int GetGoalsScoredByTeam(string teamName)
        {
            return teamName.Equals(HomeTeameName) ? HomeTeameScore : AwayTeamScore;
        }

        public int GetGoalsDefeatedByTeam(string teamName)
        {
            return teamName.Equals(HomeTeameName) ? AwayTeamScore : HomeTeameScore;
        }

        public MatchResult GetResult()
        {
            return ConverResultToEnum(HomeTeameScore, AwayTeamScore);
        }

        private MatchResult ConverResultToEnum(int actualTeamScore, int anotherTeameScore)
        {
            if (actualTeamScore > anotherTeameScore)
            {
                return MatchResult.Win;
            }
            if (actualTeamScore < anotherTeameScore)
            {
                return MatchResult.Lose;
            }
            return MatchResult.Draw;
        }
    }
}
