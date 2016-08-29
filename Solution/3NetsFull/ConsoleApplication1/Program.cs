using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using ConsoleApplication1.SystemSetup;
using ProbabilisticNeuralNetwork;
using ConsoleApplication1.BookmakerParsers;

namespace ConsoleApplication1
{
    class Program
    {
        private static readonly NameMapper nameMapper = new NameMapper();

        static void Main(string[] args)
        {
            var analiticSystem = new AnaliticSystem();
            var bookmakerLineParser = new ParimatchHistoryParser();
            var countryName = "Italy";

           // analiticSystem.AddNewMatches("d:/NewMatches.txt");

            //var currentDate = new DateTime(2016, 02, 1);
            //var currentBank = 3.7f;
            //analiticSystem.CalculateBets(ReadWilliamHill("d:/currentBookmakerEngland.txt"), GetSetupEn(), ReadWilliamHill("d:/currentBookmakerSpain.txt"), GetSetupSp(), ReadWilliamHill("d:/currentBookmakerItaly.txt"), GetSetupIt(),
            //    ReadWilliamHill("d:/currentBookmakerFrance2.txt"), GetSetupFr2(), ReadWilliamHill("d:/currentBookmakerFrance1.txt"), GetSetupFr1(), ReadWilliamHill("d:/currentBookmakerGermany.txt"), GetSetupGer(),
            //    ReadWilliamHill("d:/currentBookmakerIsrael.txt"), GetSetupIsr(), ReadWilliamHill("d:/currentBookmakerNetherlands.txt"), GetSetupNl(), ReadWilliamHill("d:/currentBookmakerPortugal.txt"), GetSetupPor(),
            //     ReadWilliamHill("d:/currentBookmakerSwitzeland.txt"), GetSetupSwitz(), ReadWilliamHill("d:/currentBookmakerTurkey.txt"), GetSetupTur(), ReadWilliamHill("d:/currentBookmakerDenmark.txt"), GetSetupDen(),
            //      ReadWilliamHill("d:/currentBookmakerBelgium.txt"), GetSetupBel(), ReadWilliamHill("d:/currentBookmakerAustria.txt"), GetSetupAus(), ReadWilliamHill("d:/currentBookmakerScotland.txt"), GetSetupScot(),
            //    ReadWilliamHill("d:/currentBookmakerCzech.txt"), GetSetupCzech(), currentDate, currentBank);


            var startDate = new DateTime(2011, 09, 1);
            var data = bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}11-12.txt", countryName));
            analiticSystem.InitializeOnDate(new DateTime(2006, 1, 1), startDate, SetupsProvider.GetSetupTest());

            var res = analiticSystem.SimulateSeason(data, startDate, SetupsProvider.GetSetupTest(), true);

            //var bookmakerStatistic = new[] { bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}11-12.txt", countryName)),
            //    bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}12-13.txt", countryName)),
            //    bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}13-14.txt", countryName)), 
            //    bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}14-15.txt", countryName)),
            //    bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}15-16.txt", countryName)) };

            //var setupScanner = new SetupsScanner(analiticSystem, 2004, 2011, bookmakerStatistic);
            //setupScanner.StartScanning();

            Console.ReadKey();
        }
    }
}
