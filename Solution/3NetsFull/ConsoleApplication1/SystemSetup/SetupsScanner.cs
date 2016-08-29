﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;

namespace ConsoleApplication1.SystemSetup
{
    public class SetupsScanner
    {
        private const float MIN_SEASON_RESULT = 0.7f;
        private const int MIN_BETS_COUNT = 10;

        private int startStatisticYear;
        private int startSeasonYear;
        private AnaliticSystem analiticSystem;
        
        private BookmakerMatchStatistic[][] bookmakerMatches;

        public SetupsScanner(AnaliticSystem analiticSystem, int startStatisticYear, int startSeasonYear, BookmakerMatchStatistic[][] bookmakerMatches)
        {
            this.analiticSystem = analiticSystem;
            this.bookmakerMatches = bookmakerMatches;
            this.startStatisticYear = startStatisticYear;
            this.startSeasonYear = startSeasonYear;
        }
        
        public void StartScanning()
        {
            var initialSetups = GetInitialSetups();
            var fullList = new List<Setup>();
            for (int i = 0; i < initialSetups.Count; i++)
            {
                Console.WriteLine("Start process " + i + " / " + initialSetups.Count);
                var currentSetup = initialSetups[i];
                List<Setup> setups = GetSetupsForNet(currentSetup);
                ProcessFirstSeason(bookmakerMatches[0], setups);
                setups = RemoveBadSetups(setups);
                for (int j = 1; j < bookmakerMatches.Length; j++)
                {
                    if (setups.Count > 0)
                    {
                        ProcessNextSeason(bookmakerMatches[j], setups, new DateTime(startSeasonYear + j, 9, 1));
                        setups = RemoveBadSetups(setups);
                    }
                }
                fullList.AddRange(setups);
            }

            fullList.Sort((s1, s2) => s2.GetResult().CompareTo(s1.GetResult()));
            SaveResults(fullList);
        }

        private List<Setup> GetInitialSetups()
        {
            var list = new List<Setup>();

            //list.Add(GetDefaultSetup());
            //return list;

            for (int daysPeriod = 30; daysPeriod <= 30; daysPeriod += 30)
            {
                for (int monthForLevel = 36; monthForLevel <= 48; monthForLevel += 12)
                {
                    for (int monthForH2H = 36; monthForH2H <= 48; monthForH2H += 12)
                    {
                        var setup = new Setup();
                        setup.daysForFormPeriod = daysPeriod;
                        setup.monthForLevelPeriod = monthForLevel;
                        setup.monthForH2H = monthForH2H;
                        list.Add(setup);
                    }
                }
            }

            return list;
        }

        private List<Setup> RemoveBadSetups(List<Setup> setups)
        {
            return setups.Where(item => item.GetMinResult() > MIN_SEASON_RESULT  && item.GetResult() > MIN_SEASON_RESULT && item.GetMinBetsCount() > MIN_BETS_COUNT).ToList();
        }

        private void SaveResults(List<Setup> setups)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Setup>));
            using (var fStream = new FileStream("d:/Setups.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xml.Serialize(fStream, setups);
            }
        }

        private void ProcessNextSeason(BookmakerMatchStatistic[] bookmakerMatch, List<Setup> setups, DateTime startSeasonDate)
        {
            analiticSystem.AddSeasonToNet(startSeasonDate, setups.First());
            ProcessSeason(bookmakerMatch, setups, startSeasonDate);
        }

        private void ProcessFirstSeason(BookmakerMatchStatistic[] bookmakerMatch, List<Setup> setups )
        {
            var simulationStartDate = new DateTime(startSeasonYear, 09, 1);
            analiticSystem.InitializeOnDate(GetStartDate(setups[0]), simulationStartDate, setups[0]);
            ProcessSeason(bookmakerMatch, setups, simulationStartDate);
        }

        private void ProcessSeason(BookmakerMatchStatistic[] bookmakerMatch, List<Setup> setups, DateTime startDate)
        {
            List<Thread> threads = new List<Thread>();
            foreach (var setup in setups)
            {
                var setup1 = setup;
                // analiticSystem.SimulateSeason(bookmakerMatch, simulationStartDate, setup1);

                var thread = new Thread(
                    delegate() { analiticSystem.SimulateSeason(bookmakerMatch, startDate, setup1); });
                threads.Add(thread);
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
        }

        private List<Setup> GetSetupsForNet(Setup baseSetup)
        {
            var setups = new List<Setup>();
            var valueDelta = 0.02f;
            var kfDelta = 1f;
            var lamdaDelta = 0.01f;
            for (float minValue = 0.01f; minValue <= 0.03f; minValue += valueDelta)
            {
                for (float maxValue = 0.05f; maxValue <= 0.18f; maxValue += valueDelta)
                {
                    for (float minKf = 1f; minKf <= 1f; minKf += kfDelta)
                    {
                        for (float maxKf = 4f; maxKf <= 5f; maxKf += kfDelta)
                        {
                            for (float lamda = 0.08f; lamda <= 0.12f; lamda += lamdaDelta)
                            {
                                var newSetup = baseSetup.Clone();
                                newSetup.minValue = minValue;
                                newSetup.maxValue = maxValue;
                                newSetup.minKf = minKf;
                                newSetup.maxKf = maxKf;
                                newSetup.lampda = lamda;
                                setups.Add(newSetup);
                            }
                        }
                    }
                }
            }
            return setups;
        }

        private DateTime GetStartDate(Setup setup)
        {
            int start = startStatisticYear + Math.Max(setup.monthForH2H, setup.monthForLevelPeriod) / 12;
            return new DateTime(start, 1, 1);
        }

        private static Setup GetDefaultSetup()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForLevelPeriod = 48;
            setup.monthForH2H = 36;

            setup.minValue = 0.01f;
            setup.maxValue = 0.13f;
            setup.minKf = 1f;
            setup.maxKf = 5f;
            setup.lampda = 0.09f;
            setup.kf = 1f;
            return setup;
        }
    }
}
