using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using ConsoleApplication1.SystemSetup;
using ProbabilisticNeuralNetwork;

namespace ConsoleApplication1
{
    public class LeagueProcesser
    {
        private const string PATH_TO_NETWORKS_FOLDIER = "d:/Networks/MultipleNetworks/";
        private readonly Statistic statistic;
        private readonly StatisticCalculator statisticCalculator;
        private readonly List<Bet> betsList = new List<Bet>();
        private readonly BookmakerMatchStatistic[] bookmakerMatches;

        private NeuralNetwork neuralNetworkW1;
        private NeuralNetwork neuralNetworkX;
        private NeuralNetwork neuralNetworkW2;
        private Setup setupW1;
        private Setup setupX;
        private Setup setupW2;
        private string leaguePrefix;

        public IEnumerable<Bet> Bets
        {
            get
            {
                return new ReadOnlyCollection<Bet>(betsList);
            }
        }

        public LeagueProcesser(string leaguePrefix, Setup setupW1, Setup setupX, Setup setupW2, BookmakerMatchStatistic[] bookmakerMatches)
        {
            LoadNetworks(leaguePrefix);
            this.setupW1 = setupW1;
            this.setupX = setupX;
            this.setupW2 = setupW2;
            this.leaguePrefix = leaguePrefix;
            this.bookmakerMatches = bookmakerMatches;

            statistic = new Statistic();
            statisticCalculator = new StatisticCalculator(statistic.Matches);
        }

        public float CalculateBets(DateTime mathcesDate, float bank)
        {
            float bets = 0f;
            foreach (var bookmakerMatch in bookmakerMatches)
            {
                if (!statistic.TeamExist(bookmakerMatch.HomeName))
                {
                    Console.WriteLine(leaguePrefix + " || " + bookmakerMatch.HomeName);
                    continue;
                }
                if (!statistic.TeamExist(bookmakerMatch.VisitName))
                {
                    Console.WriteLine(leaguePrefix + " || " + bookmakerMatch.VisitName);
                    continue;
                }

                var propability = GetMatchResultprobabilityCombine(bookmakerMatch.HomeName, bookmakerMatch.VisitName, mathcesDate);
                float bet1 = GetBetValue(bookmakerMatch.homeKf, propability[0], setupW1) * bank;
                float betX = GetBetValue(bookmakerMatch.drawKf, propability[1], setupX) * bank;
                float bet2 = GetBetValue(bookmakerMatch.visitKf, propability[2], setupW2) * bank;
                bets += bet1 + bet2 + betX;
                if (bet1 > 0f)
                {
                    var description = leaguePrefix + " || " + bookmakerMatch.HomeName + " vs. " + bookmakerMatch.VisitName + "  W1";
                    betsList.Add(new Bet() { Description = description, Value = bet1 });
                }
                if (betX > 0f)
                {
                    var description = leaguePrefix + " || " + bookmakerMatch.HomeName + " vs. " + bookmakerMatch.VisitName + "  X";
                    betsList.Add(new Bet() { Description = description, Value = betX });
                }
                if (bet2 > 0f)
                {
                    var description = leaguePrefix + " || " + bookmakerMatch.HomeName + " vs. " + bookmakerMatch.VisitName + "  W2";
                    betsList.Add(new Bet() { Description = description, Value = bet2 });
                }
            }

            return bets;
        }

        private float[] GetMatchResultprobabilityCombine(string homeTeamName, string visitTeamName, DateTime matchDate)
        {
            var valuesW1 = statisticCalculator.GetMatchStatisticW1(homeTeamName, visitTeamName, matchDate, setupW1);
            var valuesW2 = statisticCalculator.GetMatchStatisticW2(homeTeamName, visitTeamName, matchDate, setupW2);
            var valuesX = statisticCalculator.GetMatchStatisticX(homeTeamName, visitTeamName, matchDate, setupX);

            float probW1 = GetResultprobability(neuralNetworkW1, valuesW1, setupW1.lampda);
            float probX = GetResultprobability(neuralNetworkX, valuesX, setupX.lampda);
            float probW2 = GetResultprobability(neuralNetworkW2, valuesW2, setupW2.lampda);

            return new[] { probW1, probX, probW2 };
        }

        private float GetResultprobability(NeuralNetwork neuralNetwork, float[] values, float lampda)
        {
            if (values == null)
            {
                return 0f;
            }

            var signal = new Signal(values);
            var result = neuralNetwork.ProcessSignal(signal, lampda);
            return result[0];
        }

        private float GetBetValue(float kf, float propability, Setup setup)
        {
            var value = (kf * propability - 1) / (kf - 1);
            if (value < setup.minValue || value > setup.maxValue || kf < setup.minKf || kf > setup.maxKf)
            {
                value = 0;
            }
            else
            {
                value = 0.1f;
            }

            return value;
        }

        private void LoadNetworks(string leaguePrefix)
        {
            XmlSerializer xml = new XmlSerializer(typeof(NeuralNetwork));

            using (var fStream = new FileStream(GetNetworkFilePath(leaguePrefix, "W1"), FileMode.Open, FileAccess.Read, FileShare.None))
            {
                neuralNetworkW1 = xml.Deserialize(fStream) as NeuralNetwork;
            }
            using (var fStream = new FileStream(GetNetworkFilePath(leaguePrefix, "X"), FileMode.Open, FileAccess.Read, FileShare.None))
            {
                neuralNetworkX = xml.Deserialize(fStream) as NeuralNetwork;
            }
            using (var fStream = new FileStream(GetNetworkFilePath(leaguePrefix, "W2"), FileMode.Open, FileAccess.Read, FileShare.None))
            {
                neuralNetworkW2 = xml.Deserialize(fStream) as NeuralNetwork;
            }
        }

        private string GetNetworkFilePath(string leaguePrefix, string networkAim)
        {
            return PATH_TO_NETWORKS_FOLDIER + leaguePrefix + "_network_" + networkAim + ".xml";
        }



    }
}
