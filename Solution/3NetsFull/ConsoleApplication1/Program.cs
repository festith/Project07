using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using ConsoleApplication1.SystemSetup;
using ProbabilisticNeuralNetwork;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var analiticSystem = new AnaliticSystem();
          //  analiticSystem.AddNewMatches("d:/NewMatches.txt");

            //var currentDate = new DateTime(2015, 04, 03);
            //var currentBank = 70;
            //analiticSystem.CalculateBets(ReadWilliamHill("d:/currentBookmakerEngland.txt"), GetSetupEn(), ReadWilliamHill("d:/currentBookmakerSpain.txt"), GetSetupSp(), ReadWilliamHill("d:/currentBookmakerItaly.txt"), GetSetupIt(),
            //    ReadWilliamHill("d:/currentBookmakerFrance2.txt"), GetSetupFr2(), ReadWilliamHill("d:/currentBookmakerFrance1.txt"), GetSetupFr1(), ReadWilliamHill("d:/currentBookmakerGermany.txt"), GetSetupGer(),
            //    ReadWilliamHill("d:/currentBookmakerIsrael.txt"), GetSetupIsr(), ReadWilliamHill("d:/currentBookmakerNetherlands.txt"), GetSetupNl(), ReadWilliamHill("d:/currentBookmakerPortugal.txt"), GetSetupPor(),
            //     ReadWilliamHill("d:/currentBookmakerSwitzeland.txt"), GetSetupSwitz(), ReadWilliamHill("d:/currentBookmakerTurkey.txt"), GetSetupTur(), ReadWilliamHill("d:/currentBookmakerDenmark.txt"), GetSetupDen(),
            //      ReadWilliamHill("d:/currentBookmakerBelgium.txt"), GetSetupBel(), ReadWilliamHill("d:/currentBookmakerAustria.txt"), GetSetupAus(), ReadWilliamHill("d:/currentBookmakerScotland.txt"), GetSetupScot(),
            //    ReadWilliamHill("d:/currentBookmakerCzech.txt"), GetSetupCzech(), currentDate, currentBank);



            //var startDate = new DateTime(2013, 10, 1);
            //var data = Read("d:/BookmakerEngland13-14.txt");
            //analiticSystem.InitializeOnDate(new DateTime(2004, 1, 1), startDate, GetSetupEnW1());

            //var res = analiticSystem.SimulateSeason(data, startDate, GetSetupEnW1(), true);


            var bookmakerStatistic = new[] { Read("d:/BookmakerEngland10-11.txt"), Read("d:/1.txt"), Read("d:/BookmakerEngland12-13.txt"), Read("d:/BookmakerEngland13-14.txt") };
            var setupScanner = new SetupsScanner(analiticSystem, 2000, 2010, bookmakerStatistic);
            setupScanner.StartScanning();


            Console.ReadKey();
        }

        private static Setup GetSetup()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForLevelPeriod = 36;
            setup.monthForH2H = 48;

            setup.minValue = 0.01f;
            setup.maxValue = 0.11f;
            setup.minKf = 1f;
            setup.maxKf = 4f;
            setup.lampda = 0.042f;
            setup.kf = 1f;
            return setup;
        }

        private static Setup GetSetupEn()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForH2H = 24;
            setup.monthForLevelPeriod = 24;
            setup.minValue = 0.04f;
            setup.maxValue = 0.06f;
            setup.minKf = 1f;
            setup.maxKf = 6f;
            setup.lampda = 0.11f;
            setup.kf = 1.5f;
            return setup;
        }

        private static Setup GetSetupEnW1()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 60;
            setup.monthForH2H = 48;
            setup.monthForLevelPeriod = 48;
            setup.minValue = 0.01f;
            setup.maxValue = 0.23f;
            setup.minKf = 1f;
            setup.maxKf = 5f;
            setup.lampda = 0.2f;
            setup.kf = 1f;
            return setup;
        }

        private static Setup GetSetupEnW2()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 90;
            setup.monthForH2H = 36;
            setup.monthForLevelPeriod = 36;
            setup.minValue = 0.03f;
            setup.maxValue = 0.11f;
            setup.minKf = 1f;
            setup.maxKf = 6f;
            setup.lampda = 0.03f;
            setup.kf = 1f;
            return setup;
        }

        private static Setup GetSetupEnX()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForH2H = 48;
            setup.monthForLevelPeriod = 36;
            setup.minValue = 0.01f;
            setup.maxValue = 0.11f;
            setup.minKf = 1f;
            setup.maxKf = 4f;
            setup.lampda = 0.042f;
            setup.kf = 1f;
            return setup;
        }

        private static Setup GetSetupSp()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 60;
            setup.monthForH2H = 36;
            setup.monthForLevelPeriod = 12;
            setup.minValue = 0.04f;
            setup.maxValue = 0.08f;
            setup.minKf = 3f;
            setup.maxKf = 6f;
            setup.lampda = 0.1f;
            setup.kf = 1.5f;
            return setup;
        }

        private static Setup GetSetupIt()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForH2H = 24;
            setup.monthForLevelPeriod = 24;
            setup.minValue = 0.04f;
            setup.maxValue = 0.1f;
            setup.minKf = 2f;
            setup.maxKf = 6f;
            setup.lampda = 0.08f;
            setup.kf = 1f;
            return setup;
        }

        private static Setup GetSetupFr2()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 60;
            setup.monthForH2H = 24;
            setup.monthForLevelPeriod = 24;
            setup.minValue = 0.02f;
            setup.maxValue = 0.04f;
            setup.minKf = 2f;
            setup.maxKf = 6f;
            setup.lampda = 0.14f;
            setup.kf = 2f;
            return setup;
        }

        private static Setup GetSetupFr1()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 45;
            setup.monthForH2H = 24;
            setup.monthForLevelPeriod = 24;
            setup.minValue = 0f;
            setup.maxValue = 0.04f;
            setup.minKf = 2f;
            setup.maxKf = 7f;
            setup.lampda = 0.12f;
            setup.kf = 2f;
            return setup;
        }

        private static Setup GetSetupGer()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 60;
            setup.monthForLevelPeriod = 24;
            setup.monthForH2H = 36;
            setup.minValue = 0.01f;
            setup.maxValue = 0.06f;
            setup.minKf = 1f;
            setup.maxKf = 6f;
            setup.lampda = 0.12f;
            setup.kf = 1.5f;
            return setup;
        }

        private static Setup GetSetupIsr()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 60;
            setup.monthForLevelPeriod = 24;
            setup.monthForH2H = 24;
            setup.minValue = 0f;
            setup.maxValue = 0.08f;
            setup.minKf = 3f;
            setup.maxKf = 5f;
            setup.lampda = 0.15f;
            setup.kf = 1f;
            return setup;
        }

        private static Setup GetSetupNl()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForLevelPeriod = 12;
            setup.monthForH2H = 24;
            setup.minValue = 0f;
            setup.maxValue = 0.12f;
            setup.minKf = 2f;
            setup.maxKf = 6f;
            setup.lampda = 0.0707f;
            setup.kf = 1;
            return setup;
        }

        private static Setup GetSetupPor()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 60;
            setup.monthForLevelPeriod = 24;
            setup.monthForH2H = 24;
            setup.minValue = 0f;
            setup.maxValue = 0.1f;
            setup.minKf = 1f;
            setup.maxKf = 4f;
            setup.lampda = 0.12f;
            setup.kf = 1f;
            return setup;
        }

        private static Setup GetSetupSwitz()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForLevelPeriod = 24;
            setup.monthForH2H = 36;
            setup.minValue = 0.02f;
            setup.maxValue = 0.1f;
            setup.minKf = 2f;
            setup.maxKf = 6f;
            setup.lampda = 0.11f;
            setup.kf = 1f;
            return setup;
        }

        private static Setup GetSetupTur()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForLevelPeriod = 24;
            setup.monthForH2H = 36;
            setup.minValue = 0.01f;
            setup.maxValue = 0.13f;
            setup.minKf = 1f;
            setup.maxKf = 4f;
            setup.lampda = 0.09f;
            setup.kf = 1f;
            return setup;
        }

        private static Setup GetSetupDen()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 60;
            setup.monthForLevelPeriod = 24;
            setup.monthForH2H = 24;
            setup.minValue = 0.02f;
            setup.maxValue = 0.1f;
            setup.minKf = 1f;
            setup.maxKf = 4f;
            setup.lampda = 0.14f;
            setup.kf = 1f;
            return setup;
        }

        private static Setup GetSetupBel()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 45;
            setup.monthForLevelPeriod = 12;
            setup.monthForH2H = 36;
            setup.minValue = 0.02f;
            setup.maxValue = 0.1f;
            setup.minKf = 1f;
            setup.maxKf = 4f;
            setup.lampda = 0.14f;
            setup.kf = 1f;
            return setup;
        }

        private static Setup GetSetupAus()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 45;
            setup.monthForLevelPeriod = 24;
            setup.monthForH2H = 24;
            setup.minValue = 0.02f;
            setup.maxValue = 0.1f;
            setup.minKf = 2f;
            setup.maxKf = 4f;
            setup.lampda = 0.11f;
            setup.kf = 1f;
            return setup;
        }

        private static Setup GetSetupScot()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForLevelPeriod = 12;
            setup.monthForH2H = 36;
            setup.minValue = 0f;
            setup.maxValue = 0.1f;
            setup.minKf = 3f;
            setup.maxKf = 6f;
            setup.lampda = 0.1f;
            setup.kf = 1f;
            return setup;
        }

        private static Setup GetSetupCzech()
        {
            var setup = new Setup();
            setup.daysForFormPeriod = 30;
            setup.monthForLevelPeriod = 24;
            setup.monthForH2H = 36;
            setup.minValue = 0.02f;
            setup.maxValue = 0.1f;
            setup.minKf = 1f;
            setup.maxKf = 6f;
            setup.lampda = 0.09f;
            setup.kf = 1f;
            return setup;
        }

        static BookmakerMatchStatistic[] ReadWilliamHill(string pathToFile)
        {
            var tr = new StreamReader(pathToFile);
            var statisitic = new List<BookmakerMatchStatistic>();
            string homeTeamName, visitTeamName, s;
            float kf1, kfx, kf2;
            float o;
            while (!tr.EndOfStream)
            {
                s = tr.ReadLine();
                if (s.Contains(" v "))
                {
                    var items = s.Split('\t');
                    var teamsStrings = GetItemWithTeams(items);
                    var teams = teamsStrings.Split(new[] { " v " }, StringSplitOptions.None);
                    homeTeamName = teams[0];
                    visitTeamName = teams[1];
                    var w1String = tr.ReadLine();
                    var xString = tr.ReadLine();
                    var w2String = tr.ReadLine();
                    kf1 = float.Parse(w1String, CultureInfo.InvariantCulture);
                    kfx = float.Parse(xString, CultureInfo.InvariantCulture);
                    kf2 = float.Parse(w2String, CultureInfo.InvariantCulture);
                    statisitic.Add(new BookmakerMatchStatistic()
                    {
                        HomeName = MapTeamNameFromSite(homeTeamName),
                        VisitName = MapTeamNameFromSite(visitTeamName),
                        homeKf = kf1,
                        drawKf = kfx,
                        visitKf = kf2
                    });
                }


            }
            return statisitic.ToArray();

        }

        private static string GetItemWithTeams(string[] items)
        {
            foreach (var item in items)
            {
                if (item.Contains(" v "))
                {
                    return item;
                }
            }
            return string.Empty;
        }

        static BookmakerMatchStatistic[] Read(string pathToFile)
        {
            var tr = new StreamReader(pathToFile);
            var statisitic = new List<BookmakerMatchStatistic>();
            string homeTeamName, visitTeamName, s;
            float kf1, kfx, kf2, kfTb, kfTm;
            float o;
            while (!tr.EndOfStream)
            {
                s = tr.ReadLine();
                var dateItems = s.Split('\t');
                if (dateItems.Length > 1)
                {
                    dateItems = dateItems[1].Split('/');
                }
                else
                {
                    dateItems = dateItems[0].Split('/');
                }

                int day = int.Parse(dateItems[0], CultureInfo.InvariantCulture);
                int month = int.Parse(dateItems[1], CultureInfo.InvariantCulture);
                var items = tr.ReadLine().Split('\t');
                homeTeamName = items[1];
                items = tr.ReadLine().Split('\t');
                visitTeamName = items[0];
                if (homeTeamName == "" || visitTeamName == "")
                {
                    throw new Exception();
                }
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                if (s == "" || s.Contains("\t") || s == " ")
                {
                    s = tr.ReadLine();
                    if (s == "" || s.Contains("\t") || s == " ")
                    {
                        s = tr.ReadLine();
                    }
                    //  s = tr.ReadLine();
                }

                var total = float.Parse(s, CultureInfo.InvariantCulture);
                bool playTotal = total == 2.5f ? true : false;

                s = tr.ReadLine();//1
                kfTb = float.Parse(s, CultureInfo.InvariantCulture);
                s = tr.ReadLine();
                if (!float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out o))
                {
                    s = tr.ReadLine();
                }
                //2
                kfTm = float.Parse(s, CultureInfo.InvariantCulture);
                if (!playTotal)
                {
                    kfTb = 0f;
                    kfTm = 0f;
                }
                s = tr.ReadLine();

                if (!float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out o))
                {
                    s = tr.ReadLine();
                }
                kf1 = float.Parse(s, CultureInfo.InvariantCulture);
                kfx = float.Parse(tr.ReadLine(), CultureInfo.InvariantCulture);
                kf2 = float.Parse(tr.ReadLine(), CultureInfo.InvariantCulture);
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                if (!s.Contains("\t"))
                {
                    if (s != " ")
                    {
                        s = tr.ReadLine();
                        s = tr.ReadLine();
                        s = tr.ReadLine();
                        s = tr.ReadLine();
                        s = tr.ReadLine();
                    }
                    s = tr.ReadLine();
                }
                statisitic.Add(new BookmakerMatchStatistic()
                {
                    HomeName = MapTeamNameFromSite(homeTeamName),
                    VisitName = MapTeamNameFromSite(visitTeamName),
                    homeKf = kf1,
                    drawKf = kfx,
                    visitKf = kf2,
                    tBKf = kfTb,
                    tMKf = kfTm,
                    day = day,
                    month = month
                });
            }
            return statisitic.ToArray();

        }

        static BookmakerMatchStatistic[] ReadNew(string pathToFile)
        {
            var tr = new StreamReader(pathToFile);
            var statisitic = new List<BookmakerMatchStatistic>();
            string homeTeamName, visitTeamName, s;
            float kf1, kfx, kf2, kfTb, kfTm;
            float o;
            while (!tr.EndOfStream)
            {
                s = tr.ReadLine();
                var items = tr.ReadLine().Split('\t');
                homeTeamName = items[1];
                items = tr.ReadLine().Split('\t');
                visitTeamName = items[0];
                if (homeTeamName == "" || visitTeamName == "")
                {
                    throw new Exception();
                }
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                if (s == "" || s.Contains("\t") || s == " ")
                {
                    s = tr.ReadLine();
                    if (s == "" || s.Contains("\t") || s == " ")
                    {
                        s = tr.ReadLine();
                    }
                    //  s = tr.ReadLine();
                }

                var total = float.Parse(s, CultureInfo.InvariantCulture);
                bool playTotal = total == 2.5f ? true : false;

                s = tr.ReadLine();//1
                kfTb = float.Parse(s, CultureInfo.InvariantCulture);
                s = tr.ReadLine();
                if (!float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out o))
                {
                    s = tr.ReadLine();
                }
                //2
                kfTm = float.Parse(s, CultureInfo.InvariantCulture);
                if (!playTotal)
                {
                    kfTb = 0f;
                    kfTm = 0f;
                }
                s = tr.ReadLine();

                if (!float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out o))
                {
                    s = tr.ReadLine();
                }
                kf1 = float.Parse(s, CultureInfo.InvariantCulture);
                kfx = float.Parse(tr.ReadLine(), CultureInfo.InvariantCulture);
                kf2 = float.Parse(tr.ReadLine(), CultureInfo.InvariantCulture);
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                if (!s.Contains("\t"))
                {
                    if (s != " ")
                    {
                        s = tr.ReadLine();
                        s = tr.ReadLine();
                        s = tr.ReadLine();
                        s = tr.ReadLine();
                        s = tr.ReadLine();
                    }
                    //s = tr.ReadLine();
                }
                statisitic.Add(new BookmakerMatchStatistic()
                {
                    HomeName = MapTeamNameFromSite(homeTeamName),
                    VisitName = MapTeamNameFromSite(visitTeamName),
                    homeKf = kf1,
                    drawKf = kfx,
                    visitKf = kf2,
                    tBKf = kfTb,
                    tMKf = kfTm
                });
            }
            return statisitic.ToArray();

        }

        static BookmakerMatchStatistic[] ReadTurkey1213(string pathToFile)
        {
            var tr = new StreamReader(pathToFile);
            var statisitic = new List<BookmakerMatchStatistic>();
            string homeTeamName, visitTeamName, s;
            float kf1, kfx, kf2, kfTb, kfTm;
            float o;
            while (!tr.EndOfStream)
            {
                s = tr.ReadLine();
                var items = tr.ReadLine().Split('\t');
                homeTeamName = items[1];
                items = tr.ReadLine().Split('\t');
                visitTeamName = items[0];
                if (homeTeamName == "" || visitTeamName == "")
                {
                    throw new Exception();
                }
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                // s = tr.ReadLine();
                s = tr.ReadLine();
                if (s == " ")
                {
                    s = tr.ReadLine();
                }
                s = tr.ReadLine();
                var total = float.Parse(s, CultureInfo.InvariantCulture);
                bool playTotal = total == 2.5f ? true : false;

                s = tr.ReadLine();//1
                kfTb = float.Parse(s, CultureInfo.InvariantCulture);
                s = tr.ReadLine();
                if (!float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out o))
                {
                    s = tr.ReadLine();
                }
                //2
                kfTm = float.Parse(s, CultureInfo.InvariantCulture);
                if (!playTotal)
                {
                    kfTb = 0f;
                    kfTm = 0f;
                }
                s = tr.ReadLine();
                if (!float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out o))
                {
                    s = tr.ReadLine();
                }
                kf1 = float.Parse(s, CultureInfo.InvariantCulture);
                kfx = float.Parse(tr.ReadLine(), CultureInfo.InvariantCulture);
                kf2 = float.Parse(tr.ReadLine(), CultureInfo.InvariantCulture);
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                if (!s.Contains("\t"))
                {
                    if (s != " ")
                    {
                        s = tr.ReadLine();
                        s = tr.ReadLine();
                        s = tr.ReadLine();
                        s = tr.ReadLine();
                        s = tr.ReadLine();
                    }
                    s = tr.ReadLine();
                }
                statisitic.Add(new BookmakerMatchStatistic()
                {
                    HomeName = MapTeamNameFromSite(homeTeamName),
                    VisitName = MapTeamNameFromSite(visitTeamName),
                    homeKf = kf1,
                    drawKf = kfx,
                    visitKf = kf2,
                    tBKf = kfTb,
                    tMKf = kfTm
                });
            }
            return statisitic.ToArray();

        }

        static BookmakerMatchStatistic[] ReadFrance1112(string pathToFile)
        {
            var tr = new StreamReader(pathToFile);
            var statisitic = new List<BookmakerMatchStatistic>();
            string homeTeamName, visitTeamName, s;
            float kf1, kfx, kf2, kfTb, kfTm;
            float o;
            while (!tr.EndOfStream)
            {
                s = tr.ReadLine();
                var items = tr.ReadLine().Split('\t');
                homeTeamName = items[1];
                items = tr.ReadLine().Split('\t');
                visitTeamName = items[0];
                if (homeTeamName == "" || visitTeamName == "")
                {
                    throw new Exception();
                }
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                if (s == " ")
                {
                    s = tr.ReadLine();
                }
                s = tr.ReadLine();
                var total = float.Parse(s, CultureInfo.InvariantCulture);
                bool playTotal = total == 2.5f ? true : false;

                s = tr.ReadLine();//1
                kfTb = float.Parse(s, CultureInfo.InvariantCulture);
                s = tr.ReadLine();
                if (!float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out o))
                {
                    s = tr.ReadLine();
                }
                //2
                kfTm = float.Parse(s, CultureInfo.InvariantCulture);
                if (!playTotal)
                {
                    kfTb = 0f;
                    kfTm = 0f;
                }
                s = tr.ReadLine();
                if (!float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out o))
                {
                    s = tr.ReadLine();
                }
                kf1 = float.Parse(s, CultureInfo.InvariantCulture);
                kfx = float.Parse(tr.ReadLine(), CultureInfo.InvariantCulture);
                kf2 = float.Parse(tr.ReadLine(), CultureInfo.InvariantCulture);
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                if (s == " ")
                {
                    s = tr.ReadLine();
                }
                //s = tr.ReadLine();
                //s = tr.ReadLine();
                //s = tr.ReadLine();
                //s = tr.ReadLine();
                //s = tr.ReadLine();
                //s = tr.ReadLine();
                //s = tr.ReadLine();
                statisitic.Add(new BookmakerMatchStatistic()
                {
                    HomeName = MapTeamNameFromSite(homeTeamName),
                    VisitName = MapTeamNameFromSite(visitTeamName),
                    homeKf = kf1,
                    drawKf = kfx,
                    visitKf = kf2,
                    tBKf = kfTb,
                    tMKf = kfTm
                });
            }
            return statisitic.ToArray();

        }

        static BookmakerMatchStatistic[] ReadPortugal12(string pathToFile)
        {
            var tr = new StreamReader(pathToFile);
            var statisitic = new List<BookmakerMatchStatistic>();
            string homeTeamName, visitTeamName, s;
            float kf1, kfx, kf2, kfTb, kfTm;
            float o;
            while (!tr.EndOfStream)
            {
                s = tr.ReadLine();
                var items = tr.ReadLine().Split('\t');
                homeTeamName = items[1];
                items = tr.ReadLine().Split('\t');
                visitTeamName = items[0];
                if (homeTeamName == "" || visitTeamName == "")
                {
                    throw new Exception();
                }
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                // s = tr.ReadLine();
                s = tr.ReadLine();
                if (s == " ")
                {
                    s = tr.ReadLine();
                }
                s = tr.ReadLine();
                var total = float.Parse(s, CultureInfo.InvariantCulture);
                bool playTotal = total == 2.5f ? true : false;

                s = tr.ReadLine();//1
                kfTb = float.Parse(s, CultureInfo.InvariantCulture);
                s = tr.ReadLine();
                if (!float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out o))
                {
                    s = tr.ReadLine();
                }
                //2
                kfTm = float.Parse(s, CultureInfo.InvariantCulture);
                if (!playTotal)
                {
                    kfTb = 0f;
                    kfTm = 0f;
                }
                s = tr.ReadLine();
                if (!float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out o))
                {
                    s = tr.ReadLine();
                }
                kf1 = float.Parse(s, CultureInfo.InvariantCulture);
                kfx = float.Parse(tr.ReadLine(), CultureInfo.InvariantCulture);
                kf2 = float.Parse(tr.ReadLine(), CultureInfo.InvariantCulture);
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                s = tr.ReadLine();
                statisitic.Add(new BookmakerMatchStatistic()
                {
                    HomeName = MapTeamNameFromSite(homeTeamName),
                    VisitName = MapTeamNameFromSite(visitTeamName),
                    homeKf = kf1,
                    drawKf = kfx,
                    visitKf = kf2,
                    tBKf = kfTb,
                    tMKf = kfTm
                });
            }
            return statisitic.ToArray();

        }

        private static string MapTeamNameFromSite(string nameFromSite)
        {
            var name = string.Empty;
            var inputName = nameFromSite;
            while (inputName[0] == ' ')
            {
                inputName = inputName.Remove(0, 1);
            }
            while (inputName[inputName.Length - 1] == ' ')
            {
                inputName = inputName.Remove(inputName.Length - 1, 1);
            }
            switch (inputName)
            {
                //England.
                case "Arsenal London":
                    name = "Arsenal";
                    break;
                case "FC Arsenal London":
                    name = "Arsenal";
                    break;
                case "Queens Park Rangers":
                    name = "QPR";
                    break;
                case "West Bromwich Albion":
                    name = "West Bromwich";
                    break;
                case "West Brom":
                    name = "West Bromwich";
                    break;
                case "West Ham United":
                    name = "West Ham";
                    break;
                case "Newcastle United":
                    name = "Newcastle";
                    break;
                case "Tottenham Hotspur":
                    name = "Tottenham";
                    break;
                case "Wigan Athletic":
                    name = "Wigan";
                    break;
                case "Wolverhampton Wanderers":
                    name = "Wolverhampton";
                    break;
                case "Cardiff City":
                    name = "Cardiff";
                    break;
                case "Swansea":
                    name = "Swansea City";
                    break;
                case "Man Utd":
                    name = "Manchester United";
                    break;
                case "Stoke":
                    name = "Stoke City";
                    break;
                case "Man City":
                    name = "Manchester City";
                    break;
                case "Hull":
                    name = "Hull City";
                    break;
                case "Leicester":
                    name = "Leicester City";
                    break;
                case "Blackpool":
                    name = "Blackpool FC";
                    break;
               
                
                
                //Spain

                case "Granada":
                    name = "Granada CF";
                    break;
                case "Real Valladolid":
                    name = "Valladolid";
                    break;
                case "Celta":
                    name = "Celta Vigo";
                    break;
                case "Real Betis":
                    name = "Betis";
                    break;
                case "Deportivo La Coruna":
                    name = "Deportivo";
                    break;
                case "Real Zaragoza":
                    name = "Zaragoza";
                    break;
                case "Hercules":
                    name = "Hercules CF";
                    break;

                //Germany
                case "Hertha":
                    name = "Hertha BSC";
                    break;
                case "Hertha Berlin":
                    name = "Hertha BSC";
                    break;
                case "Borussia Monchengladbach":
                    name = "Munchengladbach";
                    break;
                case "Borussia M'gladbach":
                    name = "Munchengladbach";
                    break;
                case "Stuttgart":
                    name = "VfB Stuttgart";
                    break;
                case "Eintracht Braunschweig":
                    name = "Braunschweig";
                    break;
                case "Hoffenheim":
                    name = "Hoffenheim 1899";
                    break;
                case "Bayer 04 Leverkusen":
                    name = "Bayer Leverkusen";
                    break;
                case "Bayern Munich":
                    name = "Bayern Munchen";
                    break;
                case "Nuremberg":
                    name = "Nurnberg FC";
                    break;
                case "Hamburg":
                    name = "Hamburger SV";
                    break;
                case "SpVgg Greuther Furth":
                    name = "Greuther Furth";
                    break;
                case "FC Augsburg":
                    name = "Augsburg";
                    break;
                case "Paderborn 07":
                    name = "SC Paderborn";
                    break;
                case "Paderborn":
                    name = "SC Paderborn";
                    break;
                case "FC Koln":
                    name = "Cologne";
                    break;


                //Italy

                case "Internazionale Milan":
                    name = "Inter";
                    break;
                case "Inter Milan":
                    name = "Inter";
                    break;
                case "AS Roma":
                    name = "Roma";
                    break;
                case "AC Milan":
                    name = "Milan";
                    break;
                case "Verona":
                    name = "Hellas Verona";
                    break;

                //Portugal
                case "Olhanense":
                    name = "Olhanense SC";
                    break;
                case "Vitoria de Setubal":
                    name = "Vitoria Setubal";
                    break;
                case "Pacos de Ferreira":
                    name = "Pacos Ferreira";
                    break;
                case "Sporting de Braga":
                    name = "Sporting Braga";
                    break;
                case "Braga":
                    name = "Sporting Braga";
                    break;
                case "Estoril-Praia":
                    name = "Estoril";
                    break;
                case "Vitoria de Guimaraes":
                    name = "V. Guimaraes";
                    break;
                case "Vitoria Guimaraes":
                    name = "V. Guimaraes";
                    break;
                case "Guimaraes":
                    name = "V. Guimaraes";
                    break;
                case "Beira-Mar":
                    name = "Beira Mar";
                    break;
                case "SC Beira-Mar":
                    name = "Beira Mar";
                    break;
                case "Maritimo":
                    name = "Maritimo Funchal";
                    break;
                case "Uniao de Leiria":
                    name = "Uniao Leiria";
                    break;
                case "Nacional Madeira":
                    name = "Nacional";
                    break;
                case "Academica Coimbra":
                    name = "Academica";
                    break;
                case "Nacional (Por)":
                    name = "Nacional";
                    break;


                //France
                case "Bastia":
                    name = "SC Bastia";
                    break;
                case "CA Bastia":
                    name = "SC Bastia";
                    break;
                case "Saint-Etienne":
                    name = "St. Etienne";
                    break;
                case "St Etienne":
                    name = "St. Etienne";
                    break;
                case "Lyon":
                    name = "Ol. Lyon";
                    break;
                case "Marseille":
                    name = "Ol. Marseille";
                    break;
                case "Paris Saint-Germain":
                    name = "Paris St.-Germain";
                    break;
                case "Caen":
                    name = "SM Caen";
                    break;
                case "Niort":
                    name = "Chamois";
                    break;
                case "Gazelec Ajaccio":
                    name = "GFCO Ajaccio";
                    break;
                case "Ajaccio GFCO":
                    name = "GFCO Ajaccio";
                    break;
                case "Troyes":
                    name = "Troyes Aube";
                    break;
                case "Arles":
                    name = "AC Arles";
                    break;
                case "AC Arles-Avignon":
                    name = "AC Arles";
                    break;
                case "Nancy":
                    name = "AS Nancy";
                    break;
                case "Nantes":
                    name = "FC Nantes";
                    break;
                case "Metz":
                    name = "FC Metz";
                    break;
                case "Le Havre":
                    name = "AC Havre";
                    break;
                case "Sedan":
                    name = "Sedan-Ardennes";
                    break;
                case "Stade Brestois 29":
                    name = "Brest";
                    break;
                case "AS Monaco":
                    name = "Monaco";
                    break;
                case "Evian TG":
                    name = "Evian";
                    break;
                case "PSG":
                    name = "Paris St.-Germain";
                    break;
                case "Angers SCO":
                    name = "Angers";
                    break;
                case "Dijon FCO":
                    name = "Dijon";
                    break;
                case "Valenciennes FC":
                    name = "Valenciennes";
                    break;
                case "Clermont Foot":
                    name = "Clermont";
                    break;
                case "Sochaux-Montbeliard":
                    name = "Sochaux";
                    break;
                

                //Russia
                case "Volga Nizhny Novgorod":
                    name = "Volga NN";
                    break;
                case "Krylia Sovetov":
                    name = "Kr Sovetov";
                    break;
                case "FK Krasnodar":
                    name = "FC Krasnodar";
                    break;
                case "Terek":
                    name = "Terek Grozny";
                    break;
                case "CSKA Мoscow":
                    name = "CSKA Moscow";
                    break;
                case "Dynamo Moscow":
                    name = "Dinamo Moscow";
                    break;
                case "Tom":
                    name = "Tom Tomsk";
                    break;
                case "Rubin":
                    name = "Rubin Kazan";
                    break;
                case "Anzhi":
                    name = "Anzhi Makhachkala";
                    break;
                case "Kuban":
                    name = "Kuban Krasnodar";
                    break;
                case "Alania":
                    name = "Alaniya Vladikavkaz";
                    break;


                //Netherlands
                case "Cambuur Leeuwarden":
                    name = "Cambuur";
                    break;
                case "Heerenveen":
                    name = "SC Heerenveen";
                    break;
                case "Go Ahead Eagles":
                    name = "GA Eagles";
                    break;
                case "Ajax":
                    name = "Ajax Amsterdam";
                    break;
                case "Feyenoord":
                    name = "Feyenoord Rotterdam";
                    break;
                case "ADO Den Haag":
                    name = "Den Haag";
                    break;
                case "Roda JC":
                    name = "Roda";
                    break;
                case "Heracles Almelo":
                    name = "Heracles";
                    break;
                case "NAC Breda":
                    name = "Breda";
                    break;
                case "AZ Alkmaar":
                    name = "Alkmaar";
                    break;
                case "VVV-Venlo":
                    name = "Venlo";
                    break;
                case "NEC Nijmegen":
                    name = "Nijmegen";
                    break;
                case "Waalwijk":
                    name = "RKC Waalwijk";
                    break;
                case "Groningen":
                    name = "FC Groningen";
                    break;
                case "Twente":
                    name = "FC Twente";
                    break;
                case "Utrecht":
                    name = "FC Utrecht";
                    break;
                case "PEC Zwolle":
                    name = "Zwolle";
                    break;
                case "SBV Vitesse":
                    name = "Vitesse";
                    break;
                case "FC Dordrecht":
                    name = "Dordrecht";
                    break;
                case "Excelsior Rotterdam":
                    name = "Excelsior";
                    break;
                case "BV De Graafschap":
                    name = "De Graafschap";
                    break;

                //Turkey
                case "Istanbul BB":
                    name = "Istanbul Buyuksehir";
                    break;
                case "Başakşehir":
                    name = "Istanbul Buyuksehir";
                    break;
                case "Vestel Manisaspor":
                    name = "Manisaspor";
                    break;
                case "Ankaragucu":
                    name = "Ankaragucu MKE";
                    break;
                case "MKE Ankaragucu":
                    name = "Ankaragucu MKE";
                    break;
                case "Kasimpasa":
                    name = "Kasimpasa Istanbul";
                    break;
                case "Akhisar Bld.":
                    name = "Akhisar";
                    break;
                case "Akhisar Bld Spor":
                    name = "Akhisar";
                    break;
                case "Karabukspor":
                    name = "Kardemir Karabukspor";
                    break;
                case "Elasigspor":
                    name = "Elazigspor";
                    break;
                case "Kardemir DC Karabukspor":
                    name = "Kardemir Karabukspor";
                    break;
                case "Istanbul Basaksehir":
                    name = "Istanbul Buyuksehir";
                    break;
                case "Buyuksehir":
                    name = "Istanbul Buyuksehir";
                    break;
                case "Galatasaray SK":
                    name = "Galatasaray";
                    break;
                case "Besiktas JK":
                    name = "Besiktas";
                    break;
                case "Kayseri Erciyesspor":
                    name = "Kayseri";
                    break;
                case "Rizespor":
                    name = "Caykur Rizespor";
                    break;
                case "Mersin":
                    name = "Mersin Idmanyurdu";
                    break;



                case "Vasco da Gama":
                    name = "Vasco Gama";
                    break;
                case "Internacional Porto Alegre":
                    name = "Internacional";
                    break;
                case "Corinthians":
                    name = "Corinthians SP";
                    break;
                case "Nautico":
                    name = "Nautico PE";
                    break;
                case "Santos":
                    name = "Santos SP";
                    break;
                case "Flamengo RJ":
                    name = "Flamengo";
                    break;
                case "Atletico Mineiro":
                    name = "Atletico MG";
                    break;
                case "Cruzeiro":
                    name = "Cruzeiro MG";
                    break;
                case "Atletico Paranaense":
                    name = "Atletico PR";
                    break;


                //Belgium
                case "Oud-Heverlee Leuven":
                    name = "OH Leuven";
                    break;
                case "Zulte-Waregem":
                    name = "Zulte Waregem";
                    break;
                case "Sint-Truidense":
                    name = "Sint-Truidense VV";
                    break;
                case "Standard":
                    name = "Standard Liege";
                    break;
                case "Lierse":
                    name = "Lierse SK";
                    break;
                case "Beerschot Antwerpen":
                    name = "Germinal";
                    break;
                case "Brugge":
                    name = "Club Brugge";
                    break;
                case "Club Brugge KV":
                    name = "Club Brugge";
                    break;
                case "Waasland-Beveren":
                    name = "Waasland";
                    break;
                case "K.V. Oostende":
                    name = "Oostende";
                    break;
                case "KV Oostende":
                    name = "Oostende";
                    break;
                case "Mouscron-Peruwelz":
                    name = "Mouscron";
                    break;
                case "Peruwelz":
                    name = "Mouscron";
                    break;
                case "KV Kortrijk":
                    name = "Kortrijk";
                    break;
                case "KVC Westerlo":
                    name = "Westerlo";
                    break;
                case "KAA Gent":
                    name = "Gent";
                    break;
                case "KRC Genk":
                    name = "Genk";
                    break;
                case "RSC Anderlecht":
                    name = "Anderlecht";
                    break;
                case "KV Mechelen":
                    name = "Mechelen";
                    break;

                //Austria
                case "Trenkwalder Admira":
                    name = "Admira";
                    break;
                case "FC Admira Wacker":
                    name = "Admira";
                    break;
                case "FC Red Bull Salzburg":
                    name = "Salzburg";
                    break;
                case "Kapfenberg":
                    name = "Kapfenberger";
                    break;
                case "Kapfenberger SV":
                    name = "Kapfenberger";
                    break;
                case "Wolfsberger AC":
                    name = "Wolfsberg";
                    break;
                case "Wolfsberger":
                    name = "Wolfsberg";
                    break;
                case "SV Grodig":
                    name = "Grodig";
                    break;
                case "SCR Altach":
                    name = "Altach";
                    break;
                case "SC Rheindorf Altach":
                    name = "Altach";
                    break;
                case "FC Trenkwalder Admira":
                    name = "Admira";
                    break;
                case "FK Austria Wien":
                    name = "Austria Wien";
                    break;
                case "Austria Vienna":
                    name = "Austria Wien";
                    break;
                case "Rapid Vienna":
                    name = "Rapid Wien";
                    break;
                case "Magna W Neustadt":
                    name = "Wiener Neustadt";
                    break;
                case "FC Wacker Innsbruck":
                    name = "Wacker Innsbruck";
                    break;


                //Switzeland
                case "FC Lausanne-Sport":
                    name = "Lausanne-Sports";
                    break;
                case "Basel":
                    name = "FC Basel";
                    break;
                case "FC Basel 1893":
                    name = "FC Basel";
                    break;
                case "Xamax":
                    name = "Neuchatel Xamax";
                    break;
                case "Grasshopper":
                    name = "Grasshoppers";
                    break;
                case "Grasshopper Zurich":
                    name = "Grasshoppers";
                    break;
                case "FC Vaduz":
                    name = "Vaduz";
                    break;
                case "FC Sion":
                    name = "Sion";
                    break;
                case "Young Boys":
                    name = "Young Boys Bern";
                    break;
                case "BSC Young Boys":
                    name = "Young Boys Bern";
                    break;
                case "FC Sankt Gallen":
                    name = "St. Gallen";
                    break;
                case "St Gallen":
                    name = "St. Gallen";
                    break;
                case "FC Thun":
                    name = "Thun";
                    break;
                case "FC Luzern":
                    name = "Luzern";
                    break;
                case "FC Zurich":
                    name = "Zurich";
                    break;
                case "FC Aarau":
                    name = "Aarau";
                    break;


                //Czhech
                case "Jablonec":
                    name = "Jablonec FK";
                    break;
                case "Ceske Budejovice":
                    name = "Cheske Budejovice";
                    break;
                case "Pribram":
                    name = "Pribram FK";
                    break;
                case "Sparta Praha":
                    name = "Sparta Prague";
                    break;
                case "Slavia Prague":
                    name = "Slavia Praha";
                    break;
                case "Dukla Prague":
                    name = "Dukla Prag";
                    break;
                case "FC Slovacko":
                    name = "Slovacko FC";
                    break;
                case "Slovacko":
                    name = "Slovacko FC";
                    break;
                case "Teplice":
                    name = "Teplice FK";
                    break;
                case "Zbrojovka Brno":
                    name = "Brno";
                    break;
                case "FC Brno":
                    name = "Brno";
                    break;
                case "Plzen":
                    name = "Viktoria Plzen";
                    break;


                case "Ruzomberok":
                    name = "MFK Ruzomberok";
                    break;
                case "Dunajska Streda":
                    name = "DAC 1904";
                    break;
                case "Dukla Banska Bystrica":
                    name = "Dukla Prag";
                    break;
                case "Nitra":
                    name = "FC Nitra";
                    break;
                case "Trencin":
                    name = "AS Trencin";
                    break;
                case "Zlate Moravce":
                    name = "FC ViOn Zlate Moravce";
                    break;
                case "Kosice":
                    name = "MFK Kosice";
                    break;
                case "Zilina":
                    name = "MSK Zilina";
                    break;
                case "Senica":
                    name = "FK Senica";
                    break;
                case "Spartak Myiava":
                    name = "Spartak Myjava";
                    break;
                case "Спорт Подбрезова":
                    name = "Podbrezova";
                    break;

                //Greece
                case "OFI":
                    name = "Kreta OFI";
                    break;
                case "Aris Thessaloniki":
                    name = "Aris";
                    break;
                case "Skoda Xanthi":
                    name = "SKODA Xanthi";
                    break;
                case "AEK":
                    name = "AEK Athens";
                    break;
                case "Kerkyra":
                    name = "Kerkira";
                    break;
                case "Doxa Dramas":
                    name = "Doxa Drama";
                    break;
                case "Olympiakos Piraeus":
                    name = "Olympiakos Pireus";
                    break;
               

                //Denmark
                case "Aalborg":
                    name = "Aalborg AaB";
                    break;
                case "Aalborg BK":
                    name = "Aalborg AaB";
                    break;
                case "AaB Aalborg":
                    name = "Aalborg AaB";
                    break;
                case "Horsens":
                    name = "Horsens AC";
                    break;
                case "AC Horsens":
                    name = "Horsens AC";
                    break;
                case "Silkeborg":
                    name = "Silkeborg IF";
                    break;
                case "Midtjylland":
                    name = "Midtjylland FC";
                    break;
                case "FC Midtjylland":
                    name = "Midtjylland FC";
                    break;
                case "Koge":
                    name = "Herfolge BK Koge";
                    break;
                case "Nordsjaelland":
                    name = "Nordsjalland FC";
                    break;
                case "FC Nordsjaelland":
                    name = "Nordsjalland FC";
                    break;
                case "FC Copenhagen":
                    name = "Copenhagen FC";
                    break;
                case "Lyngby":
                    name = "Lyngby BK";
                    break;
                case "Odense":
                    name = "Odense BK";
                    break;
                case "Brondby":
                    name = "Brondby IF";
                    break;
                case "AGF Aarhus":
                    name = "Aarhus AGF";
                    break;
                case "Sonderjyske":
                    name = "SonderjyskE";
                    break;
                case "Esbjerg":
                    name = "Esbjerg fB";
                    break;
                case "Esbjerg FB":
                    name = "Esbjerg fB";
                    break;
                case "Randers":
                    name = "Randers FC";
                    break;
                case "Vyborg":
                    name = "Viborg FF";
                    break;
                case "Vestsjelland":
                    name = "Vestsjaelland";
                    break;
                case "FC Vestsjelland":
                    name = "Vestsjaelland";
                    break;
                case "Hobro IK":
                    name = "Hobro";
                    break;

                //Israel
                case "Hapoel Rishon LeZion (youth)":
                    name = "Ironi Rishon";
                    break;
                case "Hapoel Ironi Kiryat Shmona":
                    name = "Ironi Kiryat Shmona";
                    break;
                case "Hapoel Ironi":
                    name = "Ironi Kiryat Shmona";
                    break;
                case "Maccabi Petah Tikva":
                    name = "Maccabi Petach Tikva";
                    break;
                case "Maccabi Petach-Tikva":
                    name = "Maccabi Petach Tikva";
                    break;
                case "Bnei Yehuda Tel Aviv":
                    name = "Bnei Yehuda";
                    break;
                case "Hapoel Sakhnin":
                    name = "Ittihad Bnei Sakhnin";
                    break;
                case "Hapoel Bnei Sakhnin":
                    name = "Ittihad Bnei Sakhnin";
                    break;
                case "H.Tel-Aviv":
                    name = "Hapoel Tel Aviv";
                    break;
                case "Ironi Ramat Hasharon":
                    name = "Ironi Nir Ramat Hasharon";
                    break;
                case "FC Ashdod":
                    name = "MS Ashdod";
                    break;
                case "Hapoel Raanana":
                    name = "H. Raanana";
                    break;
                case "Beitar Jerusalem FC":
                    name = "Beitar Jerusalem";
                    break;
                case "Hapoel Petach Tikva":
                    name = "Hapoel Petah Tikva";
                    break;


                case "Newtown":
                    name = "Newtown AFC";
                    break;
                case "Bala":
                    name = "Bala Town";
                    break;
                case "Aberystwyth Town":
                    name = "Aberystwyth";
                    break;
                case "Carmarthen":
                    name = "Carmarthen Town";
                    break;
                case "Connahs Quay":
                    name = "GAP Connahs Quay";
                    break;



                //Scotland
                case "Kilmarnock":
                    name = "Kilmarnock FC";
                    break;
                case "Inverness Caledonian Thistle":
                    name = "Inverness CT";
                    break;
                case "Saint Mirren":
                    name = "St Mirren";
                    break;
                case "Dunfermline Athletic":
                    name = "Dunfermline";
                    break;
                case "Motherwell":
                    name = "Motherwell FC";
                    break;
                case "Celtic":
                    name = "Celtic Glasgow";
                    break;
                case "Saint Johnstone":
                    name = "St Johnstone";
                    break;
                case "Aberdeen":
                    name = "Aberdeen FC";
                    break;
                case "Aberdeen F.C.":
                    name = "Aberdeen FC";
                    break;
                case "Partick":
                    name = "Partick Thistle";
                    break;
                case "Dundee Utd":
                    name = "Dundee United";
                    break;
                case "FC Dundee":
                    name = "Dundee";
                    break;










                default:
                    name = inputName;
                    break;
            }
            return name;
        }
    }
}
