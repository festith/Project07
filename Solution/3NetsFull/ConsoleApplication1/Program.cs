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

            //  analiticSystem.AddNewMatches("d:/NewMatches.txt");

            var currentDate = new DateTime(2017, 01, 22);
            var currentBank = 3.92f;

            analiticSystem.CalculateBets(GetLeagueProcessers(), currentDate, currentBank);
            
            //var bookmakerLineParser = new ParimatchHistoryParser();
            //var countryName = "Italy";


            //var startDate = new DateTime(2011, 09, 1);
            //var data = bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}11-12.txt", countryName));
            //analiticSystem.InitializeOnDate(new DateTime(2006, 1, 1), startDate, SetupsProvider.GetSetupTest());

            //var res = analiticSystem.SimulateSeason(data, startDate, SetupsProvider.GetSetupTest(), true);

            //var bookmakerStatistic = new[] { 
            //    bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}11-12.txt", countryName)),
            //    bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}12-13.txt", countryName)),
            //    bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}13-14.txt", countryName)), 
            //    bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}14-15.txt", countryName)),
            //    bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}15-16.txt", countryName)) };

            //var setupScanner = new SetupsScanner(analiticSystem, 2004, 2011, bookmakerStatistic);
            //setupScanner.StartScanning();

            Console.ReadKey();
        }

        private static LeagueProcesser[] GetLeagueProcessers()
        {
            var williamhillParser = new WilliamHillNewLineParser();

            var enProcesser = new LeagueProcesser("En", SetupsProvider.SetupsW1.GetSetupEnW1(), SetupsProvider.SetupsX.GetSetupEnX(), SetupsProvider.SetupsW2.GetSetupEnW2(),
                williamhillParser.ReadBookmakerLine("d:/currentBookmakerEngland.txt"));
            var spProcesser = new LeagueProcesser("Sp", SetupsProvider.SetupsW1.GetSetupSpW1(), SetupsProvider.SetupsX.GetSetupSpX(), SetupsProvider.SetupsW2.GetSetupSpW2(),
                williamhillParser.ReadBookmakerLine("d:/currentBookmakerSpain.txt"));
            var itProcesser = new LeagueProcesser("It", SetupsProvider.SetupsW1.GetSetupItW1(), SetupsProvider.SetupsX.GetSetupItX(), SetupsProvider.SetupsW2.GetSetupItW2(),
                williamhillParser.ReadBookmakerLine("d:/currentBookmakerItaly.txt"));
            var frProcesser = new LeagueProcesser("Fr", SetupsProvider.SetupsW1.GetSetupFrW1(), SetupsProvider.SetupsX.GetSetupFrX(), SetupsProvider.SetupsW2.GetSetupFrW2(),
                williamhillParser.ReadBookmakerLine("d:/currentBookmakerFrance1.txt"));
            var gerProcesser = new LeagueProcesser("Ger", SetupsProvider.SetupsW1.GetSetupGerW1(), SetupsProvider.SetupsX.GetSetupGerX(), SetupsProvider.SetupsW2.GetSetupGerW2(),
                williamhillParser.ReadBookmakerLine("d:/currentBookmakerGermany.txt"));
            var nlProcesser = new LeagueProcesser("Nl", SetupsProvider.SetupsW1.GetSetupNlW1(), SetupsProvider.SetupsX.GetSetupNlX(), SetupsProvider.SetupsW2.GetSetupNlW2(),
               williamhillParser.ReadBookmakerLine("d:/currentBookmakerNetherlands.txt"));
            var porProcesser = new LeagueProcesser("Por", SetupsProvider.SetupsW1.GetSetupPorW1(), SetupsProvider.SetupsX.GetSetupPorX(), SetupsProvider.SetupsW2.GetSetupPorW2(),
             williamhillParser.ReadBookmakerLine("d:/currentBookmakerPortugal.txt"));

            return new[] { enProcesser, spProcesser, itProcesser, frProcesser, gerProcesser, nlProcesser, porProcesser };
        }
    }
}
