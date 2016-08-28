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

        public virtual float[] GetMatchStatistic(string homeTeamName, string visitTeamName, DateTime date, Setup setup)
        {
            var formStartFormData = date.AddDays(-setup.daysForFormPeriod);
            //  var monthData = date.AddDays(-30);
            var statisticStartData = date.AddMonths(-setup.monthForLevelPeriod);
            var statistic2StartData = date.AddMonths(-setup.monthForH2H);

            var minCount = 3;

            var matches = GetActualMatches(homeTeamName, date, statisticStartData);
            if (matches.Count() < minCount) return null;
            IEnumerable<float> statistic = GetTeamStatistic(homeTeamName, matches);

            matches = GetActualMatches(visitTeamName, date, statisticStartData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatistic(visitTeamName, matches));


            matches = GetActualMatches(visitTeamName, date, formStartFormData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatistic(visitTeamName, matches));

            matches = GetActualMatches(homeTeamName, date, formStartFormData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatistic(homeTeamName, matches));

            matches = GetActualVisitMatches(visitTeamName, date, statisticStartData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatistic(visitTeamName, matches));

            matches = GetActualHomeMatches(homeTeamName, date, statisticStartData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatistic(homeTeamName, matches));

            matches = GetActualMatches(homeTeamName, visitTeamName, date, statistic2StartData);
            if (matches.Count() < minCount) return null;
            statistic = statistic.Concat(GetTeamStatistic(homeTeamName, matches));

            var a = statistic.ToArray();

            return a;
        }

        public virtual float[] GetMatchStatisticForTotal(string homeTeamName, string visitTeamName, DateTime date)
        {
            var formStartFormData = date.AddDays(-FORM_PERIOD_DAYS);
            var statisticStartData = date.AddYears(-STATISTIC_PERIOD_YEARS);
            var statistic2StartData = date.AddYears(-3);
            IEnumerable<float> statistic = GetTeamStatisticForTotal(homeTeamName, GetActualMatches(homeTeamName, date, statisticStartData));
            statistic = statistic.Concat(GetTeamStatisticForTotal(visitTeamName, GetActualMatches(visitTeamName, date, statisticStartData)));
            statistic = statistic.Concat(GetTeamStatisticForTotal(visitTeamName, GetActualMatches(visitTeamName, date, formStartFormData)));
            statistic = statistic.Concat(GetTeamStatisticForTotal(homeTeamName, GetActualMatches(homeTeamName, date, formStartFormData)));
            statistic = statistic.Concat(GetTeamStatisticForTotal(visitTeamName, GetActualVisitMatches(visitTeamName, date, statisticStartData)));
            statistic = statistic.Concat(GetTeamStatisticForTotal(homeTeamName, GetActualHomeMatches(homeTeamName, date, statisticStartData)));
            statistic = statistic.Concat(GetTeamStatisticForTotal(homeTeamName, GetActualMatches(homeTeamName, visitTeamName, date, statistic2StartData)));
            //statistic = statistic.Concat(GetTeamFormStatistic(visitTeamName, GetActualMatches(visitTeamName, date, litleFormStartFormData)));
            //statistic = statistic.Concat(GetTeamFormStatistic(homeTeamName, GetActualMatches(homeTeamName, date, litleFormStartFormData)));
            var a = statistic.ToArray();

            return a;
        }

        protected float[] GetTeamStatistic(string teamName, IEnumerable<Match> actualMatches)
        {

            float wins = 0;
            float draws = 0;
            float losses = 0;
            float scored = 0;
            float defeated = 0;
            foreach (var match in actualMatches)
            {
                scored += match.GetGoalsScoredByTeam(teamName);
                defeated += match.GetGoalsDefeatedByTeam(teamName);
                switch (match.GetResultByTeamName(teamName))
                {
                    case MatchResult.Win:
                        wins++;
                        break;
                    case MatchResult.Draw:
                        draws++;
                        break;
                    case MatchResult.Lose:
                        losses++;
                        break;
                }

            }


            var macthCount = actualMatches.Count();
            if (macthCount < 3)
            {
                return new[] { 0.3333f, 0.3333f, 0.3333f };
            }
            return new[] { wins / macthCount, draws / macthCount, losses / macthCount };
        }

        protected float[] GetTeamStatisticForTotal(string teamName, IEnumerable<Match> actualMatches)
        {

            float tB = 0;
            float tM = 0;
            float scored = 0;
            float defeated = 0;
            var macthCount = actualMatches.Count();

            foreach (var match in actualMatches)
            {
                scored += match.GetGoalsScoredByTeam(teamName);
                defeated += match.GetGoalsDefeatedByTeam(teamName);
                if (match.HomeTeameScore + match.AwayTeamScore >= 3)
                {
                    tB++;
                }
                else
                {
                    tM++;
                }

            }



            if (macthCount == 0)
            {
                return new[] { 0f, 0f, 0f };
            }
            scored /= macthCount;
            defeated /= macthCount;
            return new[] { tB / macthCount, tM / macthCount, scored - defeated };//(scored + defeated)/2f scored - defeated
        }


        protected float[] MergeStatistic(float[] home, float[] visit)
        {
            var res = new float[3];
            res[0] = (home[0] + visit[2]) / 2f;
            res[1] = (home[1] + visit[1]) / 2f;
            res[2] = (home[2] + visit[1]) / 2f;
            return res;
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
