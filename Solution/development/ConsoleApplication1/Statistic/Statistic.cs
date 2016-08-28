using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    /// <summary>
    /// Get access to statistic data.
    /// </summary>
    public class Statistic
    {
        private const string PATH_TO_STATISTIC = "d:/serialize.xml";
        private readonly NameMapper nameMapper = new NameMapper();

        public List<Match> Matches
        {
            get
            {
                return matches;
            }

        }

        private List<Match> matches;

        public Statistic()
        {
            matches = ReadStatistic();
        }

        public void SaveStatistic()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Match>));
            using (var fStream = new FileStream(PATH_TO_STATISTIC, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xml.Serialize(fStream, Matches);
            }
        }

        public void AddNewStatistic(string pathToFile)
        {
            var tr = new StreamReader(pathToFile);
            while (!tr.EndOfStream)
            {
                var items = tr.ReadLine().Split('\t');
                matches.Add(new Match(items[0], nameMapper.MapTeamNameFromSite(items[1]), items[3] + ":" + items[4], nameMapper.MapTeamNameFromSite(items[2])));
            }
        }

        public void AddNewStatisticFromSite(string pathToFile)
        {
            var tr = new StreamReader(pathToFile);
            while (!tr.EndOfStream)
            {
                var st = tr.ReadLine();
                var items = st.Split('\t');
                if (items.Length > 2 && items[1].Contains(" - "))
                {
                    var teams = items[1].Split(new string[1] { " - " }, StringSplitOptions.None);
                    var goals = items[2].Split(' ');
                    var dateItems = items[0].Split('.');
                    string date = 20 + dateItems[2] + "." + dateItems[1] + "." + dateItems[0];
                    var homeTeamName = nameMapper.MapTeamNameFromSite(teams[0]);
                    var visitTeamName = nameMapper.MapTeamNameFromSite(teams[1]);
                    if (!TeamExist(homeTeamName))
                    {
                        Console.WriteLine("TeamDoesNotExist: " + homeTeamName);
                    }
                    if (!TeamExist(visitTeamName))
                    {
                        Console.WriteLine("TeamDoesNotExist: " + visitTeamName);
                    }
                    matches.Add(new Match(date, homeTeamName, goals[0], visitTeamName));
                }
            }
        }

        public bool TeamExist(string teamName)
        {
            return
                Matches.Exists(
                    match =>
                        match.HomeTeameName.Equals(teamName) ||
                        match.AwayTeamName.Equals(teamName));
        }

       
        private List<Match> ReadStatistic()
        {
            var readedList = new List<Match>();
            XmlSerializer xml = new XmlSerializer(typeof(List<Match>));
            using (var fStream = new FileStream(PATH_TO_STATISTIC, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                readedList = xml.Deserialize(fStream) as List<Match>;
            }
            return readedList;
        }


    }
}
