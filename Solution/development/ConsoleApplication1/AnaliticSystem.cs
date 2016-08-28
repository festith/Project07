using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ConsoleApplication1.SystemSetup;
using ProbabilisticNeuralNetwork;

namespace ConsoleApplication1
{
    public class AnaliticSystem
    {
        protected NeuralNetwork neuralNetwork;
        protected NeuralNetwork totaNeuralNetwork;

        protected NeuralNetwork EnNeuralNetwork;
        protected NeuralNetwork SpNeuralNetwork;
        protected NeuralNetwork ItNeuralNetwork;

        protected Statistic statistic;
        protected StatisticCalculator statisticCalculator;
        protected bool systemInitialized;
        protected float fullP;
        protected float maxDelta;
        private NeuralNetwork Fr2NeuralNetwork;
        private NeuralNetwork Fr1NeuralNetwork;
        private NeuralNetwork GerNeuralNetwork;
        private NeuralNetwork IsrNeuralNetwork;
        private NeuralNetwork NlNeuralNetwork;
        private NeuralNetwork PorNeuralNetwork;
        private NeuralNetwork SwitzNeuralNetwork;
        private NeuralNetwork TurNeuralNetwork;
        private NeuralNetwork DenNeuralNetwork;
        private NeuralNetwork BelNeuralNetwork;
        private NeuralNetwork AusNeuralNetwork;
        private NeuralNetwork ScotlandNeuralNetwork;
        private NeuralNetwork CzechNeuralNetwork;

        protected const float MAX_KF = 11.1f;
        protected const float MIN_KF = 1.7f;
        protected const float RADIUS = 0.05f;
        private const float MAX_PERCENT = 0.7f;

        public AnaliticSystem()
        {
            neuralNetwork = new NeuralNetwork(3);
            totaNeuralNetwork = new NeuralNetwork(2);
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
            var values = statisticCalculator.GetMatchStatistic(homeTeamName, visitTeamName, matchDate, setup);

            if (values == null)
            {
                return new[] {0f, 0f, 0f};
            }

            var signal = new Signal(values);
            var result0 = neuralNetwork.ProcessSignal(signal, setup.lampda);

            return result0;
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
                    float betX = GetBetValue(bMatch.drawKf, propability[1], setup) * bank;
                    float bet2 = GetBetValue(bMatch.visitKf, propability[2], setup) * bank;

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
                  //  Console.WriteLine({0, -5} + {1, -5},bets,bank)};
                    Console.WriteLine("{0, -10} | {1, -10}", bets, bank);
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
            //using (var fStream = new FileStream("d:/networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            //{
            //    neuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            //}

            //systemInitialized = true;
            //return;


            neuralNetwork.ResetNetwork();

            var lastData = new DateTime(finishDate.Year, 07, 01);

            foreach (var match in statistic.Matches)
            {
                if (match.Data < lastData && match.Data > startDate && (match.Data.Month > 8 || match.Data.Month < 6))
                {
                    var values = statisticCalculator.GetMatchStatistic(match.HomeTeameName, match.AwayTeamName, match.Data, setup);

                    if (values != null)
                    {
                        var signal2 = new Signal(values);
                        neuralNetwork.AddSample(signal2, (int)match.GetResultByTeamName(match.HomeTeameName));
                    }
                }
            }

            systemInitialized = true;

            XmlSerializer xmlWrite = new XmlSerializer(typeof(NeuralNetwork));
            using (var fStream = new FileStream("d:/networkNew.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlWrite.Serialize(fStream, neuralNetwork);
            }
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
                    var values = statisticCalculator.GetMatchStatistic(match.HomeTeameName, match.AwayTeamName, match.Data, setup);

                    if (values != null)
                    {
                        var signal2 = new Signal(values);
                        neuralNetwork.AddSample(signal2, (int)match.GetResultByTeamName(match.HomeTeameName));
                    }
                }
            }
        }

        public void CalculateBets(BookmakerMatchStatistic[] bookmakerMatchesEngland, Setup setupEn, BookmakerMatchStatistic[] bookmakerMatchesSpain, Setup setupSp, BookmakerMatchStatistic[] bookmakerMatchesItaly, Setup setupIt,
            BookmakerMatchStatistic[] bookmakerMatchesFrance2, Setup setupFr2, BookmakerMatchStatistic[] bookmakerMatchesFrance1, Setup setupFr1, BookmakerMatchStatistic[] bookmakerMatchesGermany, Setup setupGer,
            BookmakerMatchStatistic[] bookmakerMatchesIsrael, Setup setupIsr,  BookmakerMatchStatistic[] bookmakerMatchesNetherlands, Setup setupNl,
            BookmakerMatchStatistic[] bookmakerMatchesPortugal, Setup setupPor, BookmakerMatchStatistic[] bookmakerMatchesSwitzeland, Setup setupSwitz,
            BookmakerMatchStatistic[] bookmakerMatchesTurkey, Setup setupTur, BookmakerMatchStatistic[] bookmakerMatchesDenmark, Setup setupDen,
            BookmakerMatchStatistic[] bookmakerMatchesBelgium, Setup setupBel, BookmakerMatchStatistic[] bookmakerMatchesAustria, Setup setupAus, BookmakerMatchStatistic[] bookmakerMatchesScotland, Setup setupScotland,
            BookmakerMatchStatistic[] bookmakerMatchesCzech, Setup setupCzech, DateTime mathcesDate, float bank)
        {
            var betsFile = new StreamWriter("d:/bets2.txt");
            InitializeNetworks();
            float betsValue = 0f;
            var bets = new List<Bet>();
            betsValue += ProcessLeague(bookmakerMatchesEngland, EnNeuralNetwork, bets, mathcesDate, bank, "England", setupEn);
            betsValue += ProcessLeague(bookmakerMatchesSpain, SpNeuralNetwork, bets, mathcesDate, bank, "Spain", setupSp);
            betsValue += ProcessLeague(bookmakerMatchesItaly, ItNeuralNetwork, bets, mathcesDate, bank, "Italy", setupIt);
            betsValue += ProcessLeague(bookmakerMatchesFrance2, Fr2NeuralNetwork, bets, mathcesDate, bank, "France2", setupFr2);
            betsValue += ProcessLeague(bookmakerMatchesFrance1, Fr1NeuralNetwork, bets, mathcesDate, bank, "France1", setupFr1);
            betsValue += ProcessLeague(bookmakerMatchesGermany, GerNeuralNetwork, bets, mathcesDate, bank, "Germany", setupGer);
            betsValue += ProcessLeague(bookmakerMatchesIsrael, IsrNeuralNetwork, bets, mathcesDate, bank, "Israel", setupIsr);
            betsValue += ProcessLeague(bookmakerMatchesNetherlands, NlNeuralNetwork, bets, mathcesDate, bank, "Netherlands", setupNl);
            betsValue += ProcessLeague(bookmakerMatchesPortugal, PorNeuralNetwork, bets, mathcesDate, bank, "Portugal", setupPor);
            betsValue += ProcessLeague(bookmakerMatchesSwitzeland, SwitzNeuralNetwork, bets, mathcesDate, bank, "Switzeland", setupSwitz);
            betsValue += ProcessLeague(bookmakerMatchesTurkey, TurNeuralNetwork, bets, mathcesDate, bank, "Turkey", setupTur);
            betsValue += ProcessLeague(bookmakerMatchesDenmark, DenNeuralNetwork, bets, mathcesDate, bank, "Denmark", setupDen);
            betsValue += ProcessLeague(bookmakerMatchesBelgium, BelNeuralNetwork, bets, mathcesDate, bank, "Belgium", setupBel);
            betsValue += ProcessLeague(bookmakerMatchesAustria, AusNeuralNetwork, bets, mathcesDate, bank, "Austria", setupAus);
            betsValue += ProcessLeague(bookmakerMatchesScotland, ScotlandNeuralNetwork, bets, mathcesDate, bank, "Scotland", setupScotland);
            betsValue += ProcessLeague(bookmakerMatchesCzech, CzechNeuralNetwork, bets, mathcesDate, bank, "Czech", setupCzech);
            Console.WriteLine("bets: " + betsValue + "  % = " + betsValue / bank);
            var kf = 1f;
            if (betsValue > (bank * MAX_PERCENT))
            {
                kf = (bank*MAX_PERCENT)/betsValue;
            }

            WriteBets(bets, betsFile, kf);
            betsFile.Close();
        }

        private void WriteBets(List<Bet> bets, StreamWriter betsFile, float kf)
        {
            var newBets = 0f;
            foreach (var bet in bets)
            {
                var value = bet.Value*kf;
                newBets += value;
                betsFile.WriteLine(bet.Description + " " + value);
            }
            Console.WriteLine("New Bets: " + newBets + "  kf = " + kf);
        }

        private float ProcessLeague(BookmakerMatchStatistic[] bookmakerMatches, NeuralNetwork neuralNetwork, List<Bet> betsList, DateTime mathcesDate, float bank, string leagueName, Setup setup)
        {
            float bets = 0f;
            foreach (var bookmakerMatch in bookmakerMatches)
            {
                if (!statistic.TeamExist(bookmakerMatch.HomeName))
                {
                    Console.WriteLine(leagueName + " || " + bookmakerMatch.HomeName);
                    continue;
                }
                if (!statistic.TeamExist(bookmakerMatch.VisitName))
                {
                    Console.WriteLine(leagueName + " || " + bookmakerMatch.VisitName);
                    continue;
                }

                var propability = GetMatchResultprobabilityCombine(bookmakerMatch.HomeName, bookmakerMatch.VisitName, mathcesDate, neuralNetwork, setup);
                float bet1 = GetBetValue(bookmakerMatch.homeKf, propability[0], setup) * bank;
                float betX = GetBetValue(bookmakerMatch.drawKf, propability[1], setup) * bank;
                float bet2 = GetBetValue(bookmakerMatch.visitKf, propability[2], setup) * bank;
                bets += bet1 + bet2 + betX;
                if (bet1 > 0f)
                {
                    var description = leagueName + " || " + bookmakerMatch.HomeName + " vs. " + bookmakerMatch.VisitName + "  W1";
                    betsList.Add(new Bet() { Description = description, Value = bet1});
                }
                if (betX > 0f)
                {
                    var description = leagueName + " || " + bookmakerMatch.HomeName + " vs. " + bookmakerMatch.VisitName + "  X";
                    betsList.Add(new Bet() { Description = description, Value = betX });
                }
                if (bet2 > 0f)
                {
                    var description = leagueName + " || " + bookmakerMatch.HomeName + " vs. " + bookmakerMatch.VisitName + "  W2";
                    betsList.Add(new Bet() { Description = description, Value = bet2 });
                }
            }
            return bets;
        }
        
        protected void InitializeNetworks()
        {
            XmlSerializer xml = new XmlSerializer(typeof(NeuralNetwork));

            using (var fStream = new FileStream("d:/En_networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                EnNeuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            }
            using (var fStream = new FileStream("d:/Sp_networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                SpNeuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            }
            using (var fStream = new FileStream("d:/It_networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                ItNeuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            }
            using (var fStream = new FileStream("d:/Fr2_networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                Fr2NeuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            }
            using (var fStream = new FileStream("d:/Fr1_networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                Fr1NeuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            }
            using (var fStream = new FileStream("d:/Ger_networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                GerNeuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            }
            using (var fStream = new FileStream("d:/Isr_networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                IsrNeuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            }
            using (var fStream = new FileStream("d:/Nl_networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                NlNeuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            }
            using (var fStream = new FileStream("d:/Por_networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                PorNeuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            }
            using (var fStream = new FileStream("d:/Switz_networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                SwitzNeuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            }
            using (var fStream = new FileStream("d:/Tur_networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                TurNeuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            }
            using (var fStream = new FileStream("d:/Den_networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                DenNeuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            }
            using (var fStream = new FileStream("d:/Bel_networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                BelNeuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            }
            using (var fStream = new FileStream("d:/Aus_networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                AusNeuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            }
            using (var fStream = new FileStream("d:/Scot_networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                ScotlandNeuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            } 
            using (var fStream = new FileStream("d:/Cz_networkNew.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                CzechNeuralNetwork = xml.Deserialize(fStream) as NeuralNetwork;
            }
        }

        public float[] GetMatchResultprobabilityCombine(string homeTeamName, string visitTeamName, DateTime matchDate, NeuralNetwork currentNeuralNetwork, Setup setup)
        {
            var values = statisticCalculator.GetMatchStatistic(homeTeamName, visitTeamName, matchDate, setup);

            if (values == null)
            {
                return new[] { 0f, 0f, 0f };
            }

            var signal = new Signal(values);
            return currentNeuralNetwork.ProcessSignal(signal, setup.lampda);
        }

    }
}
