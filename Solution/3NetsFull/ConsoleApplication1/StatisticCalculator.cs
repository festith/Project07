using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1.SystemSetup;


namespace ConsoleApplication1
{
    public class StatisticCalculator
    {
        protected readonly IEnumerable<Match> matches;
        protected const int FORM_PERIOD_DAYS = 30;
        protected const int STATISTIC_PERIOD_YEARS = 2;

        public StatisticCalculator(IEnumerable<Match> matches)
        {
            this.matches = matches;
        }

        public virtual float[] GetMatchStatisticW1(string homeTeamName, string visitTeamName, DateTime date, Setup setup)
        {
            var formStartFormData = date.AddDays(-setup.daysForFormPeriod);
            var statisticStartData = date.AddMonths(-setup.monthForLevelPeriod);
            var statistic2StartData = date.AddMonths(-setup.monthForH2H);

            var minCount = 3;

            var matches = GetActualMatches(homeTeamName, date, statisticStartData);
            if (matches.Count() < minCount) return null;
            IEnumerable<float> statistic = GetTeamStatisticWin(homeTeamName, matches);

            matches = GetActualMatches(visitTeamName, date, statisticStartData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticLose(visitTeamName, matches));

            matches = GetActualMatches(visitTeamName, date, formStartFormData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticLose(visitTeamName, matches));

            matches = GetActualMatches(homeTeamName, date, formStartFormData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticWin(homeTeamName, matches));

            matches = GetActualVisitMatches(visitTeamName, date, statisticStartData);
           if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticLose(visitTeamName, matches));

            matches = GetActualHomeMatches(homeTeamName, date, statisticStartData);
           if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticWin(homeTeamName, matches));

            matches = GetActualMatches(homeTeamName, visitTeamName, date, statistic2StartData);
           if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticWin(homeTeamName, matches));

            var a = statistic.ToArray();

            return a;
        }

        public virtual float[] GetMatchStatisticW2(string homeTeamName, string visitTeamName, DateTime date, Setup setup)
        {
            var formStartFormData = date.AddDays(-setup.daysForFormPeriod);
            var statisticStartData = date.AddMonths(-setup.monthForLevelPeriod);
            var statistic2StartData = date.AddMonths(-setup.monthForH2H);

            var minCount = 3;

            var matches = GetActualMatches(homeTeamName, date, statisticStartData);
            if (matches.Count() < minCount) return null;
            IEnumerable<float> statistic = GetTeamStatisticLose(homeTeamName, matches);

            matches = GetActualMatches(visitTeamName, date, statisticStartData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticWin(visitTeamName, matches));

            matches = GetActualMatches(visitTeamName, date, formStartFormData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticWin(visitTeamName, matches));

            matches = GetActualMatches(homeTeamName, date, formStartFormData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticLose(homeTeamName, matches));

            matches = GetActualVisitMatches(visitTeamName, date, statisticStartData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticWin(visitTeamName, matches));

            matches = GetActualHomeMatches(homeTeamName, date, statisticStartData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticLose(homeTeamName, matches));

            matches = GetActualMatches(homeTeamName, visitTeamName, date, statistic2StartData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticLose(homeTeamName,matches));
            
            var a = statistic.ToArray();

            return a;
        }

        public virtual float[] GetMatchStatisticX(string homeTeamName, string visitTeamName, DateTime date, Setup setup)
        {
            var formStartFormData = date.AddDays(-setup.daysForFormPeriod);
            var statisticStartData = date.AddMonths(-setup.monthForLevelPeriod);
            var statistic2StartData = date.AddMonths(-setup.monthForH2H);

            var minCount = 3;

            var matches = GetActualMatches(homeTeamName, date, statisticStartData);
            if (matches.Count() < minCount) return null;
            IEnumerable<float> statistic = GetTeamStatisticX(homeTeamName, matches);

            matches = GetActualMatches(visitTeamName, date, statisticStartData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticX(visitTeamName, matches));

            matches = GetActualMatches(visitTeamName, date, formStartFormData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticX(visitTeamName, matches));

            matches = GetActualMatches(homeTeamName, date, formStartFormData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticX(homeTeamName, matches));

            matches = GetActualVisitMatches(visitTeamName, date, statisticStartData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticX(visitTeamName, matches));

            matches = GetActualHomeMatches(homeTeamName, date, statisticStartData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticX(homeTeamName, matches));

            matches = GetActualMatches(homeTeamName, visitTeamName, date, statistic2StartData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatisticX(homeTeamName, matches));
            
            var a = statistic.ToArray();

            return a;
        }

        protected float[] GetTeamStatisticWin(string teamName, IEnumerable<Match> actualMatches)
        {

            float wins = 0;
            float noWins = 0;

            foreach (var match in actualMatches)
            {
                switch (match.GetResultByTeamName(teamName))
                {
                    case MatchResult.Win:
                        wins++;
                        break;
                    default:
                        noWins++;
                        break;
                }

            }


            var macthCount = actualMatches.Count();
            if (macthCount < 3)
            {
                return new[] { 0f };
            }

            return new[] { (wins - noWins) / macthCount };
        }

        protected float[] GetTeamStatisticLose(string teamName, IEnumerable<Match> actualMatches)
        {

            float loses = 0;
            float noLoses = 0;

            foreach (var match in actualMatches)
            {
                switch (match.GetResultByTeamName(teamName))
                {
                    case MatchResult.Lose:
                        loses++;
                        break;
                    default:
                        noLoses++;
                        break;
                }

            }


            var macthCount = actualMatches.Count();
            if (macthCount < 3)
            {
                return new[] { 0f };
            }
            return new[] { (loses -noLoses) / macthCount };
        }

        protected float[] GetTeamStatisticX(string teamName, IEnumerable<Match> actualMatches)
        {

            float draws = 0;
            float noDraws = 0;

            foreach (var match in actualMatches)
            {
                switch (match.GetResultByTeamName(teamName))
                {
                    case MatchResult.Draw:
                        draws++;
                        break;
                    default:
                        noDraws++;
                        break;
                }

            }


            var macthCount = actualMatches.Count();
            if (macthCount < 3)
            {
                return new[] { 0.5f};
            }
            return new[] { (draws - noDraws) / macthCount };
        }

        protected IEnumerable<Match> GetActualMatches(string teamName, DateTime date, DateTime startData)
        {
            return matches.Where(match =>
                        (match.HomeTeameName.Equals(teamName) || match.AwayTeamName.Equals(teamName)) &&
                        match.Data < date && match.Data > startData);
        }

        protected IEnumerable<Match> GetActualHomeMatches(string teamName, DateTime date, DateTime startData)
        {
            return matches.Where(match =>
                        match.HomeTeameName.Equals(teamName) &&
                        match.Data < date && match.Data > startData);
        }

        protected IEnumerable<Match> GetActualVisitMatches(string teamName, DateTime date, DateTime startData)
        {
            return matches.Where(match =>
                        match.AwayTeamName.Equals(teamName) &&
                        match.Data < date && match.Data > startData);
        }


        protected IEnumerable<Match> GetActualMatches(string homeTeamName, string visitTeamName, DateTime date, DateTime startData)
        {
            return
                GetActualMatches(homeTeamName, date, startData)
                    .Where(
                        match => match.HomeTeameName.Equals(visitTeamName) || match.AwayTeamName.Equals(visitTeamName));
        }
    }
}
