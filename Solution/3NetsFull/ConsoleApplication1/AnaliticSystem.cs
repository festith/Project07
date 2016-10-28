using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApplication1.SystemSetup;
using ProbabilisticNeuralNetwork;

namespace ConsoleApplication1
{
    public class AnaliticSystem
    {
        protected NeuralNetwork neuralNetworkW1;
        protected NeuralNetwork neuralNetworkX;
        protected NeuralNetwork neuralNetworkW2;
     
        protected Statistic statistic;
        protected StatisticCalculator statisticCalculator;
        protected bool systemInitialized;
        protected float fullP;
        protected float maxDelta;

        protected const float MAX_KF = 11.1f;
        protected const float MIN_KF = 1.7f;
        protected const float RADIUS = 0.05f;
        private const float MAX_PERCENT = 0.8f;

        public AnaliticSystem()
        {
            neuralNetworkW1 = new NeuralNetwork(2);
           // neuralNetworkW2 = new NeuralNetwork(2);
           // neuralNetworkX = new NeuralNetwork(2);
            statistic = new Statistic();
            statisticCalculator = new StatisticCalculator(statistic.Matches);
        }

        public void AddNewMatches(string pathTofile)
        {
            statistic.AddNewStatisticFromSite(pathTofile);
            // statistic.AddNewStatistic(pathTofile);
            statistic.SaveStatistic();
        }

        public float[] GetMatchResultprobability(string homeTeamName, string visitTeamName, DateTime matchDate, Setup setup)
        {
            var values = statisticCalculator.GetMatchStatisticW1(homeTeamName, visitTeamName, matchDate, setup);
           // var values = statisticCalculator.GetMatchStatisticW2(homeTeamName, visitTeamName, matchDate, setup);
           // var values = statisticCalculator.GetMatchStatisticX(homeTeamName, visitTeamName, matchDate, setup);
            if (values == null)
            {
                return new[] { 0f };
            }

            var signal = new Signal(values);
           // var result = neuralNetworkX.ProcessSignal(signal, setup.lampda);
            var result = neuralNetworkW1.ProcessSignal(signal, setup.lampda);
          //  var result = neuralNetworkW2.ProcessSignal(signal, setup.lampda);

            //var signalW2 = new Signal(statisticCalculator.GetMatchStatisticW2(homeTeamName, visitTeamName, matchDate, setupW2));
            //var resultW2 = neuralNetworkW2.ProcessSignal(signalW2, setupW2.lampda);

            //var signalX = new Signal(statisticCalculator.GetMatchStatisticX(homeTeamName, visitTeamName, matchDate, setupX));
            //var resultX = neuralNetworkX.ProcessSignal(signalX, setupX.lampda);

            //var sum = resultW1[0] + resultW2[0] + resultX[0];
            //if (sum > 1.35f)
            //{
            //    sum = float.PositiveInfinity;
            //}
            //else
            //{
            //    sum = 1f;
            //}

            //  return new[] { resultW1[0] / sum, resultX[0] / sum, resultW2[0] / sum };

            return new[] { result[0] };
        }

        public float SimulateSeason(BookmakerMatchStatistic[] bookmakerMatches, DateTime startDate, Setup setup, bool showLog = false)
        {
            var finishDate = new DateTime(startDate.Year + 1, 06, 01);
            float bank = 1f;
            int betsCount = 0;
            var actualMathes = statistic.Matches.Where(match => match.Data >= startDate && match.Data < finishDate);
            var matches = actualMathes.OrderBy(match => match.Data).ToArray();
            int processedMatchesCount = 0;
            while (processedMatchesCount < matches.Length)
            {
                int i = processedMatchesCount;
                float newBank = bank;
                var bets = 0f;
                while (i < matches.Length && matches[i].Data == matches[processedMatchesCount].Data)
                {
                    var result = matches[i].GetResult();

                    var bMatch = bookmakerMatches.FirstOrDefault(match => match.HomeName.Equals(matches[i].HomeTeameName) && match.VisitName.Equals(matches[i].AwayTeamName) && match.month == matches[i].Data.Month && match.day == matches[i].Data.Day);
                    //  var bMatch = bookmakerMatches.FirstOrDefault(match => match.HomeName.Equals(matches[i].HomeTeameName) && match.VisitName.Equals(matches[i].AwayTeamName));

                    if (bMatch == null)
                    {
                        if (showLog)
                        {
                            Console.WriteLine(matches[i].HomeTeameName + " vs. " + matches[i].AwayTeamName + " date: " + matches[i].Data);
                        }
                        i++;
                        continue;
                    }

                    var propability = GetMatchResultprobability(matches[i].HomeTeameName, matches[i].AwayTeamName, matches[i].Data, setup);

                    float bet1 = GetBetValue(bMatch.homeKf, propability[0], setup) * bank;
                    float betX = 0f; // GetBetValue(bMatch.drawKf, propability[0], setup) * bank;
                    float bet2 = 0f; // GetBetValue(bMatch.visitKf, propability[0], setup) * bank;


                    if (bet1 > 0 || bet2 > 0 || betX > 0)
                    {
                        betsCount++;
                    }

                    bets += bet1 + bet2 + betX;

                    switch (result)
                    {
                        case MatchResult.Win:
                            newBank += bMatch.homeKf * bet1;
                            break;
                        case MatchResult.Draw:
                            newBank += bMatch.drawKf * betX;
                            break;
                        case MatchResult.Lose:
                            newBank += bMatch.visitKf * bet2;
                            break;
                    }

                    i++;
                }
                newBank -= bets;
                bank = newBank;
                processedMatchesCount = i;
                if (showLog)
                {
                    Console.WriteLine(bank);
                }
            }

            if (showLog)
            {
                Console.WriteLine("FinishRes: " + bank + " *** betsCount: " + betsCount);
            }

            setup.AddResult(bank, betsCount);
            return bank;
        }


        protected float GetBetValue(float kf, float propability, Setup setup)
        {
            var value = (kf * propability - 1) / (kf - 1);
            if (value < setup.minValue || value > setup.maxValue)
            {
                value = 0;
            }
            else
            {
                value = 0.1f;
            }

            //   value *= setup.kf;

            if (kf < setup.minKf || kf > setup.maxKf)
            {
                value = 0f;
            }

            return (value > 0) ? value : 0f;
        }



        public void InitializeOnDate(DateTime startDate, DateTime finishDate, Setup setup)
        {
            //XmlSerializer xml = new XmlSerializer(typeof(NeuralNetwork));
            //using (var fStream = new FileStream("d:/networkNewW1.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            //{
            //    neuralNetworkW1 = xml.Deserialize(fStream) as NeuralNetwork;
            //}

            //using (var fStream = new FileStream("d:/networkNewW2.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            //{
            //    neuralNetworkW2 = xml.Deserialize(fStream) as NeuralNetwork;
            //}

            //using (var fStream = new FileStream("d:/networkNewX.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            //{
            //    neuralNetworkX = xml.Deserialize(fStream) as NeuralNetwork;
            //}

            //systemInitialized = true;
            //return;


            neuralNetworkW1.ResetNetwork();
            //neuralNetworkW2.ResetNetwork();
            //neuralNetworkX.ResetNetwork();

            var lastData = new DateTime(finishDate.Year, 07, 01);

            foreach (var match in statistic.Matches)
            {
                if (match.Data < lastData && match.Data > startDate && (match.Data.Month > 8 || match.Data.Month < 6))
                {
                    var values = statisticCalculator.GetMatchStatisticW1(match.HomeTeameName, match.AwayTeamName, match.Data, setup);

                    if (values != null)
                    {
                        var signal = new Signal(values);
                        neuralNetworkW1.AddSample(signal, (int)match.GetResultByTeamName(match.HomeTeameName) == 0 ? 0 : 1);
                    }

                    //var values = statisticCalculator.GetMatchStatisticW2(match.HomeTeameName, match.AwayTeamName, match.Data, setup);

                    //if (values != null)
                    //{
                    //    var signal = new Signal(values);
                    //    neuralNetworkW2.AddSample(signal, (int)match.GetResultByTeamName(match.HomeTeameName) == 2 ? 0 : 1);
                    //}

                    //var values = statisticCalculator.GetMatchStatisticX(match.HomeTeameName, match.AwayTeamName,match.Data, setup);

                    //if (values != null)
                    //{
                    //    var signal = new Signal(values);
                    //    neuralNetworkX.AddSample(signal, (int)match.GetResultByTeamName(match.HomeTeameName) == 1 ? 0 : 1);
                    //}
                }
            }

            systemInitialized = true;

            //XmlSerializer xmlWrite = new XmlSerializer(typeof(NeuralNetwork));
            //using (var fStream = new FileStream("d:/networkNewW2.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            //{
            //    xmlWrite.Serialize(fStream, neuralNetworkW2);
            //}
        }

        public void AddSeasonToNet(DateTime startSeasonDate, Setup setup)
        {
            var lastData = new DateTime(startSeasonDate.Year, 07, 01);
            var startDate = startSeasonDate.AddMonths(-14);
            var actualMatches = statistic.Matches.Where(match => match.Data < lastData && match.Data > startDate);
            foreach (var match in actualMatches)
            {
                if (match.Data.Month > 8 || match.Data.Month < 6)
                {
                    var values = statisticCalculator.GetMatchStatisticW1(match.HomeTeameName, match.AwayTeamName, match.Data, setup);

                    if (values != null)
                    {
                        var signal = new Signal(values);
                        neuralNetworkW1.AddSample(signal, (int)match.GetResultByTeamName(match.HomeTeameName) == 0 ? 0 : 1);
                    }

                    //var values = statisticCalculator.GetMatchStatisticW2(match.HomeTeameName, match.AwayTeamName, match.Data, setup);

                    //if (values != null)
                    //{
                    //    var signal = new Signal(values);
                    //    neuralNetworkW2.AddSample(signal, (int)match.GetResultByTeamName(match.HomeTeameName) == 2 ? 0 : 1);
                    //}

                    //var values = statisticCalculator.GetMatchStatisticX(match.HomeTeameName, match.AwayTeamName, match.Data, setup);

                    //if (values != null)
                    //{
                    //    var signal = new Signal(values);
                    //    neuralNetworkX.AddSample(signal, (int)match.GetResultByTeamName(match.HomeTeameName) == 1 ? 0 : 1);
                    //}

                }
            }
        }

        public void CalculateBets(LeagueProcesser[] leagueProcessers, DateTime mathcesDate, float bank)
        {
            var betsFile = new StreamWriter("d:/bets2.txt");
           
            float betsValue = 0f;
            var bets = new List<Bet>();

            foreach (var leagueProcesser in leagueProcessers)
            {
                betsValue += leagueProcesser.CalculateBets(mathcesDate, bank);
                bets.AddRange(leagueProcesser.Bets);
            }

            Console.WriteLine("bets: " + betsValue + "  % = " + betsValue / bank);
            
            var kf = 1f;
            if (betsValue > (bank * MAX_PERCENT))
            {
                kf = (bank * MAX_PERCENT) / betsValue;
            }

            WriteBets(bets, betsFile, kf);
            betsFile.Close();
        }

        private void WriteBets(List<Bet> bets, StreamWriter betsFile, float kf)
        {
            var newBets = 0f;
            foreach (var bet in bets)
            {
                var value = bet.Value * kf;
                newBets += value;
                betsFile.WriteLine(bet.Description + " " + value);
            }
            Console.WriteLine("New Bets: " + newBets + "  kf = " + kf);
        }
    }
}
