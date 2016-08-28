using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace ConsoleApplication1.BookmakerParsers
{
    public class WilliamHillNewLineParser : BookmakerParser
    {
        public override BookmakerMatchStatistic[] ReadBookmakerLine(string pathToFile)
        {
            var tr = new StreamReader(pathToFile);
            var statisitic = new List<BookmakerMatchStatistic>();
            string homeTeamName, visitTeamName, s;
            float kf1, kfx, kf2;
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
                        HomeName = NameMapper.MapTeamNameFromSite(homeTeamName),
                        VisitName = NameMapper.MapTeamNameFromSite(visitTeamName),
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

      
    }
}
