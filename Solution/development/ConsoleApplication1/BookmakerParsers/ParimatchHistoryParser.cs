using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace ConsoleApplication1.BookmakerParsers
{
    public class ParimatchHistoryParser : BookmakerParser
    {
        public override BookmakerMatchStatistic[] ReadBookmakerLine(string pathToFile)
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
                    HomeName = NameMapper.MapTeamNameFromSite(homeTeamName),
                    VisitName = NameMapper.MapTeamNameFromSite(visitTeamName),
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
    }
}
