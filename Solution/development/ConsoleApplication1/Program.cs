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
                     
            //analiticSystem.AddNewMatches("d:/NewMatches.txt");

            var williamhillParser = new WilliamHillNewLineParser();
            var currentDate = new DateTime(2017, 03, 12);
            var currentBank = 0.95f;
            analiticSystem.CalculateBets(
                williamhillParser.ReadBookmakerLine("d:/currentBookmakerEngland.txt"), SetupsProvider.GetSetupEn(),
                williamhillParser.ReadBookmakerLine("d:/currentBookmakerSpain.txt"), SetupsProvider.GetSetupSp(),
                williamhillParser.ReadBookmakerLine("d:/currentBookmakerItaly.txt"), SetupsProvider.GetSetupIt(),
                williamhillParser.ReadBookmakerLine("d:/currentBookmakerFrance1.txt"), SetupsProvider.GetSetupFr1(),
                williamhillParser.ReadBookmakerLine("d:/currentBookmakerGermany.txt"), SetupsProvider.GetSetupGer(),
                williamhillParser.ReadBookmakerLine("d:/currentBookmakerNetherlands.txt"), SetupsProvider.GetSetupNl(),
                williamhillParser.ReadBookmakerLine("d:/currentBookmakerPortugal.txt"), SetupsProvider.GetSetupPor(),
                williamhillParser.ReadBookmakerLine("d:/currentBookmakerTurkey.txt"), SetupsProvider.GetSetupTur(),
                currentDate, currentBank);


            
            //var countryName = "England";
            //var bookmakerLineParser = new ParimatchHistoryParser();
            //var startDate = new DateTime(2016, 09, 1);
            //var setup = SetupsProvider.GetSetupEn();
            //var data = bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}15-16.txt", countryName));
            //analiticSystem.InitializeOnDate(new DateTime(2002, 1, 1), startDate, setup);

            //var res = analiticSystem.SimulateSeason(data, startDate, setup, true);

            //var bookmakerStatistic = new[] { 
            //    bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}10-11.txt", countryName)),
            //    bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}11-12.txt", countryName)),
            //    bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}12-13.txt", countryName)),
            //    bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}13-14.txt", countryName)), 
            //    bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}14-15.txt", countryName)),
            //    bookmakerLineParser.ReadBookmakerLine(string.Format("d:/Bookmaker{0}15-16.txt", countryName)) };

            //var setupScanner = new SetupsScanner(analiticSystem, 2000, 2010, bookmakerStatistic);
            //setupScanner.StartScanning();

            Console.ReadKey();
        }
    }
}
