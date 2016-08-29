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
                matches.Add(new Match(items[0], MapTeamNameFromSite(items[1]), items[3] + ":" + items[4], MapTeamNameFromSite(items[2])));
            }
        }

        public void AddNewStatisticFromSite(string pathToFile)
        {
            var tr = new StreamReader(pathToFile);
            while (!tr.EndOfStream)
            {
                var st = tr.ReadLine();
                var items = st.Split('\t');
                if (items.Length > 2)
                {
                    var teams = items[1].Split(new string[1] { " - " }, StringSplitOptions.None);
                    var goals = items[2].Split(' ');
                    var dateItems = items[0].Split('.');
                    string date = 20 + dateItems[2] + "." + dateItems[1] + "." + dateItems[0];
                    var homeTeamName = MapTeamNameFromSite(teams[0]);
                    var visitTeamName = MapTeamNameFromSite(teams[1]);
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

        private string MapTeamNameFromSite(string nameFromSite)
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
                //England
                case "Stoke":
                    name = "Stoke City";
                    break;
                case "Man City":
                    name = "Manchester City";
                    break;
                case "Norwich":
                    name = "Norwich City";
                    break;
                case "Swansea":
                    name = "Swansea City";
                    break;
                case "W.B.A.":
                    name = "West Bromwich";
                    break;
                case "Man Utd":
                    name = "Manchester United";
                    break;
                case "Hull":
                    name = "Hull City";
                    break;
                case "Leicester":
                    name = "Leicester City";
                    break;
                //Spain
                case "FC Sevilla":
                    name = "Sevilla";
                    break;
                case "Vallecano":
                    name = "Rayo Vallecano";
                    break;
                case "At. Bilbao":
                    name = "Athletic Bilbao";
                    break;
                case "Granada":
                    name = "Granada CF";
                    break;
                case "At. Madrid":
                    name = "Atletico Madrid";
                    break;


                //Germany
                case "Hertha":
                    name = "Hertha BSC";
                    break;
                case "Dortmund":
                    name = "Borussia Dortmund";
                    break;
                case "E. Frankfurt":
                    name = "Eintracht Frankfurt";
                    break;
                case "Nuremberg":
                    name = "Nurnberg FC";
                    break;
                case "Hoffenheim":
                    name = "Hoffenheim 1899";
                    break;
                case "Leverkusen":
                    name = "Bayer Leverkusen";
                    break;
                case "Bremen":
                    name = "Werder Bremen";
                    break;
                case "B. Munich":
                    name = "Bayern Munchen";
                    break;
                case "Stuttgart":
                    name = "VfB Stuttgart";
                    break;
                case "Hannover":
                    name = "Hannover 96";
                    break;
                case "Hamburg":
                    name = "Hamburger SV";
                    break;
                case "M'gladbach":
                    name = "Munchengladbach";
                    break;
                case "Furth":
                    name = "Greuther Furth";
                    break;
                case "Dusseldorf":
                    name = "Fortuna Dusseldorf";
                    break;

                //France
                case "PSG":
                    name = "Paris St.-Germain";
                    break;
                case "Paris St Germain":
                    name = "Paris St.-Germain";
                    break;

                case "Troyes":
                    name = "Troyes Aube";
                    break;
                case "Rennais":
                    name = "Rennes";
                    break;
                case "Bastia":
                    name = "SC Bastia";
                    break;
                case "CA Bastia":
                    name = "SC Bastia";
                    break;
                case "Lyon":
                    name = "Ol. Lyon";
                    break;
                case "Olympique Lyon":
                    name = "Ol. Lyon";
                    break;
                case "Marseille":
                    name = "Ol. Marseille";
                    break;
                case "Metz":
                    name = "FC Metz";
                    break;
                case "Nantes":
                    name = "FC Nantes";
                    break;
                case "Saint-Etienne":
                    name = "St. Etienne";
                    break;
                case "Saint Etienne":
                    name = "St. Etienne";
                    break;
                case "Sedan":
                    name = "Sedan-Ardennes";
                    break;
                case "Le Havre":
                    name = "AC Havre";
                    break;
                case "Havre":
                    name = "AC Havre";
                    break;
                case "Creteil-Lusitanos":
                    name = "Creteil";
                    break;
                case "Caen":
                    name = "SM Caen";
                    break;
                case "Nancy":
                    name = "AS Nancy";
                    break;
                case "Arles":
                    name = "AC Arles";
                    break;
                case "SCO Angers":
                    name = "Angers";
                    break;
                case "Stade Brestois":
                    name = "Brest";
                    break;
                case "Chamois Niortais":
                    name = "Chamois";
                    break;
                case "Stade Lavallois":
                    name = "Laval";
                    break;
                case "Stade Laval":
                    name = "Laval";
                    break;
                case "Stade de Reims":
                    name = "Reims";
                    break;
                case "Clermont Foot":
                    name = "Clermont";
                    break;
                case "Istres FC":
                    name = "Istres";
                    break;
                case "EA Guingamp":
                    name = "Guingamp";
                    break;
                case "AC Ajaccio":
                    name = "Ajaccio";
                    break;
                case "Amiens SC":
                    name = "Amiens";
                    break;

//Portugal
                case "V. Setubal":
                    name = "Vitoria Setubal";
                    break;
                case "Vitoria Guimaraes":
                    name = "V. Guimaraes";
                    break;
                case "Braga":
                    name = "Sporting Braga";
                    break;
                case "Ferreira":
                    name = "Pacos Ferreira";
                    break;
                case "Sporting":
                    name = "Sporting Lisbon";
                    break;
                case "Olhanense":
                    name = "Olhanense SC";
                    break;
                case "Maritimo":
                    name = "Maritimo Funchal";
                    break;
                case "FC Porto":
                    name = "Porto";
                    break;


                


                //Netherlands
                case "ADO Den Haag":
                    name = "Den Haag";
                    break;
                case "Waalwijk":
                    name = "RKC Waalwijk";
                    break;
                case "Feyenoord":
                    name = "Feyenoord Rotterdam";
                    break;
                case "PSV":
                    name = "PSV Eindhoven";
                    break;
                case "Utrecht":
                    name = "FC Utrecht";
                    break;
                case "Heerenveen":
                    name = "SC Heerenveen";
                    break;
                case "Groningen":
                    name = "FC Groningen";
                    break;
                case "Vitesse Arnhem":
                    name = "Vitesse";
                    break;
                case "Twente":
                    name = "FC Twente";
                    break;
                case "Ajax":
                    name = "Ajax Amsterdam";
                    break;
                case "Excelsior Rotterdam":
                    name = "Excelsior";
                    break;
                case "SBV":
                    name = "Excelsior";
                    break;
                case "PEC Zwolle":
                    name = "Zwolle";
                    break;
                case "NEC Nijmegen":
                    name = "Nijmegen";
                    break;
                case "AZ Alkmaar":
                    name = "Alkmaar";
                    break;
                case "Heracles Almelo":
                    name = "Heracles";
                    break;
                case "NAC Breda":
                    name = "Breda";
                    break;
                case "Roda JC":
                    name = "Roda";
                    break;
                case "VV Venlo":
                    name = "Venlo";
                    break;
                case "FC Volendam":
                    name = "Volendam";
                    break;


                //Turkey

                case "Kasimpasa":
                    name = "Kasimpasa Istanbul";
                    break;

                case "Karabukspor":
                    name = "Kardemir Karabukspor";
                    break;
                case "Mersin Idman Yurdu":
                    name = "Mersin Idmanyurdu";
                    break;
                case "Buyuksehyr":
                    name = "Istanbul Buyuksehir";
                    break;
                case "Başakşehir":
                    name = "Istanbul Buyuksehir";
                    break;
                case "Rizespor":
                    name = "Caykur Rizespor";
                    break;
                case "Kayseri Erciyesspor":
                    name = "Kayseri";
                    break;

                case "Lierse":
                    name = "Lierse SK";
                    break;
                case "Standard":
                    name = "Standard Liege";
                    break;
                case "KAA Gent":
                    name = "Gent";
                    break;
                case "Beerschot":
                    name = "Germinal";
                    break;
                case "R. Charleroi":
                    name = "Charleroi";
                    break;
                case "KV Mechelen":
                    name = "Mechelen";
                    break;
                case "Zulte":
                    name = "Zulte Waregem";
                    break;
                case "Royal Mouscron":
                    name = "Mouscron";
                    break;

                //Russia
                case "Kryliya Sovetov":
                    name = "Kr Sovetov";
                    break;
                case "Amkar Perm":
                    name = "Amkar";
                    break;
                case "Volga":
                    name = "Volga NN";
                    break;
                case "Krasnodar":
                    name = "FC Krasnodar";
                    break;
                case "Lokomotiv M":
                    name = "Lokomotiv Moscow";
                    break;
                case "Dinamo M":
                    name = "Dinamo Moscow";
                    break;
                case "Spartak M":
                    name = "Spartak Moscow";
                    break;
                case "CSKA":
                    name = "CSKA Moscow";
                    break;
                case "Terek":
                    name = "Terek Grozny";
                    break;
                case "Anzhi":
                    name = "Anzhi Makhachkala";
                    break;
                case "Kuban":
                    name = "Kuban Krasnodar";
                    break;

                //Austria
                case "Austria Vienna":
                    name = "Austria Wien";
                    break;
                case "Rapid Vienna":
                    name = "Rapid Wien";
                    break;

                //Switzeland
                case "Young Boys":
                    name = "Young Boys Bern";
                    break;
                case "Zurich FC":
                    name = "Zurich";
                    break;
                case "Thun FC":
                    name = "Thun";
                    break;
                case "Aarau FC":
                    name = "Aarau";
                    break;
                case "Basel FC":
                    name = "FC Basel";
                    break;
                case "FC Lausanne-Sport":
                    name = "Lausanne-Sports";
                    break;
                case "Grasshopper Club":
                    name = "Grasshoppers";
                    break;
                case "GC Zurich":
                    name = "Grasshoppers";
                    break;
                case "Luzern FC":
                    name = "Luzern";
                    break;
                case "FC Sion":
                    name = "Sion";
                    break;
                case "Sion FC":
                    name = "Sion";
                    break;
                case "FC Vaduz":
                    name = "Vaduz";
                    break;



                case "Siofok":
                    name = "BFC Siofok";
                    break;
                case "Ujpest":
                    name = "Ujpest FC";
                    break;
                case "Diosgyori":
                    name = "Diosgyor VTK";
                    break;
                case "Lombard Papa":
                    name = "Lombard-Papa TFC";
                    break;
                case "Videoton":
                    name = "Videoton FC";
                    break;
                case "Pecs":
                    name = "Pecs MFC";
                    break;
                case "Debreceni VSC":
                    name = "Debrecen VSC";
                    break;
                case "Haladas":
                    name = "Szombathelyi Haladas";
                    break;
                case "Honved":
                    name = "Budapest Honved";
                    break;
                case "Egri Kft":
                    name = "Egri";
                    break;
                case "Ferencvaros":
                    name = "Ferencvaros TC";
                    break;
                case "Kaposvari":
                    name = "Kaposvari Rakoczi";
                    break;
                case "Paksi":
                    name = "Paksi SE";
                    break;
                case "Kecskemeti":
                    name = "Kecskemeti TE";
                    break;

//Czech
                case "Teplice":
                    name = "Teplice FK";
                    break;
                case "Slavia Prague":
                    name = "Slavia Praha";
                    break;
                case "Dukla":
                    name = "Dukla Prag";
                    break;
                case "Pribram":
                    name = "Pribram FK";
                    break;
                case "Slovacko":
                    name = "Slovacko FC";
                    break;
                case "Jablonec":
                    name = "Jablonec FK";
                    break;
                case "C. Budejovice":
                    name = "Cheske Budejovice";
                    break;
                case "Bohemians":
                    name = "Bohemians 1905";
                    break;
                case "Brno FC":
                    name = "Brno";
                    break;


                case "Kosice":
                    name = "MFK Kosice";
                    break;
                case "Zilina":
                    name = "MSK Zilina";
                    break;
                case "Banska Bystrica":
                    name = "Dukla Prag";
                    break;
                case "Nitra":
                    name = "FC Nitra";
                    break;
                case "Senica":
                    name = "FK Senica";
                    break;
                case "Zlate Moravce":
                    name = "FC ViOn Zlate Moravce";
                    break;
                case "Trencin":
                    name = "AS Trencin";
                    break;
                case "Ruzomberok":
                    name = "MFK Ruzomberok";
                    break;
                case "Dunajska Streda":
                    name = "DAC 1904";
                    break;

                //Greece
                case "OFI":
                    name = "Kreta OFI";
                    break;
                case "Olympiacos":
                    name = "Olympiakos Pireus";
                    break;
                case "OFI Crete":
                    name = "Kreta OFI";
                    break;
                case "Atromitos Athens":
                    name = "Atromitos";
                    break;
                case "Xanthi Skoda":
                    name = "SKODA Xanthi";
                    break;
                case "Aris Thessaloniki":
                    name = "Aris";
                    break;
                case "Veria":
                    name = "Veroia";
                    break;
                case "Kerkyra Corfu":
                    name = "Kerkira";
                    break;
                case "Panetolikos Agrinio":
                    name = "Panetolikos";
                    break;

                //Denmark
                case "Copenhagen":
                    name = "Copenhagen FC";
                    break;
                case "Aalborg":
                    name = "Aalborg AaB";
                    break;
                case "Randers":
                    name = "Randers FC";
                    break;
                case "Midtjylland":
                    name = "Midtjylland FC";
                    break;
                case "Aarhus":
                    name = "Aarhus AGF";
                    break;
                case "Horsens":
                    name = "Horsens AC";
                    break;
                case "Brondby":
                    name = "Brondby IF";
                    break;
                case "Nordsjalland":
                    name = "Nordsjalland FC";
                    break;
                case "Esbjerg":
                    name = "Esbjerg fB";
                    break;
                case "Odense":
                    name = "Odense BK";
                    break;
                case "Silkeborg":
                    name = "Silkeborg IF";
                    break;
                case "Viborg":
                    name = "Viborg FF";
                    break;


                //Israel
                case "Ashdod":
                    name = "MS Ashdod";
                    break;
                case "Tel Aviv":
                    name = "Maccabi Tel Aviv";
                    break;
                case "Jerusalem":
                    name = "Beitar Jerusalem";
                    break;
                case "M. Netanya":
                    name = "Maccabi Netanya";
                    break;
                case "Haifa":
                    name = "Maccabi Haifa";
                    break;
                case "Bnei Sakhnin":
                    name = "Ittihad Bnei Sakhnin";
                    break;
                case "H. Beer Sheva":
                    name = "Hapoel Beer Sheva";
                    break;
                case "IR Hasharon":
                    name = "Ironi Nir Ramat Hasharon";
                    break;
                case "H Haifa":
                    name = "Hapoel Haifa";
                    break;
                case "H. Ramat Gan":
                    name = "Hapoel Ramat Gan";
                    break;
                case "H. Akko":
                    name = "Hapoel Akko";
                    break;
                case "M Petach Tikva":
                    name = "Maccabi Petach Tikva";
                    break;
                case "Petach Tikva":
                    name = "Hapoel Petah Tikva";
                    break;
                case "Hapoel Raanana":
                    name = "H. Raanana";
                    break;
                case "Kiryat Shmone":
                    name = "Ironi Kiryat Shmona";
                    break;


                case "Airbus UK":
                    name = "Airbus UK Broughton";
                    break;
                case "Newtown":
                    name = "Newtown AFC";
                    break;
                case "Neath Athletic AFC":
                    name = "Neath Athletic";
                    break;
                case "TNS":
                    name = "The New Saints";
                    break;
                case "Connahs Quay":
                    name = "GAP Connahs Quay";
                    break;
                case "Prestatyn":
                    name = "Prestatyn Town";
                    break;
                case "Llanelli":
                    name = "Llanelli AFC";
                    break;
                case "Rhyl":
                    name = "Rhyl FC";
                    break;
                case "Bangor":
                    name = "Bangor City";
                    break;
                case "New Saints":
                    name = "The New Saints";
                    break;

                //Scotland
                case "Celtic":
                    name = "Celtic Glasgow";
                    break;
                case "Johnstone":
                    name = "St Johnstone";
                    break;
                case "Motherwell":
                    name = "Motherwell FC";
                    break;
                case "Kilmarnock":
                    name = "Kilmarnock FC";
                    break;
                case "Aberdeen":
                    name = "Aberdeen FC";
                    break;



                //Italy
                case "Turin":
                    name = "Torino";
                    break;
                case "Verona":
                    name = "Hellas Verona";
                    break;
                case "Inter Milan":
                    name = "Inter";
                    break;





                default:
                    name = inputName;
                    break;
            }
            return name;
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
