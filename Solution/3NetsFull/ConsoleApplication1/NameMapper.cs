using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class NameMapper
    {
        public string MapTeamNameFromSite(string nameFromSite)
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
                case "Queens Park":
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
                case "Norwich":
                    name = "Norwich City";
                    break;
                case "AFC Bournemouth":
                    name = "Bournemouth";
                    break;
                case "W.B.A.":
                    name = "West Bromwich";
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
                case "FC Sevilla":
                    name = "Sevilla";
                    break;
                case "Vallecano":
                    name = "Rayo Vallecano";
                    break;
                case "At. Bilbao":
                    name = "Athletic Bilbao";
                    break;
                case "At. Madrid":
                    name = "Atletico Madrid";
                    break;
                case "Atlético Madrid":
                    name = "Atletico Madrid";
                    break;                    
                case "Gijon":
                    name = "Sporting Gijon";
                    break;
                case "Cordoba CF":
                    name = "Cordoba";
                    break;
                case "Sabadell":
                    name = "CE Sabadell";
                    break;
                case "Elche CF":
                    name = "Elche";
                    break;
                case "Guadalajara CD":
                    name = "CD Guadalajara";
                    break;
                case "Girona FC":
                    name = "Girona";
                    break;
                case "Real Madrid Castilla":
                    name = "RM Castilla";
                    break;
                case "Barcelona Atletic":
                    name = "Barcelona B";
                    break;
                case "Racing Club":
                    name = "Racing Santander";
                    break;
                case "Racing":
                    name = "Racing Santander";
                    break;
                case "R. Santander":
                    name = "Racing Santander";
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
                case "Koeln":
                    name = "Cologne";
                    break;
                case "Ingolstadt 04":
                    name = "Ingolstadt";
                    break;
                case "SV Darmstadt 1998":
                    name = "Darmstadt";
                    break;
                case "Dortmund":
                    name = "Borussia Dortmund";
                    break;
                case "E. Frankfurt":
                    name = "Eintracht Frankfurt";
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
                case "Hannover":
                    name = "Hannover 96";
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
                case "Leipzig":
                    name = "RB Leipzig";
                    break;
                case "Mainz":
                    name = "Mainz 05";
                    break;
                case "Schalke":
                    name = "Schalke 04";
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
                case "Turin":
                    name = "Torino";
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
                case "Maritimo Madeira":
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
                case "V. Setubal":
                    name = "Vitoria Setubal";
                    break;
                case "Ferreira":
                    name = "Pacos Ferreira";
                    break;
                case "Sporting":
                    name = "Sporting Lisbon";
                    break;
                case "FC Porto":
                    name = "Porto";
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
                case "AC Ajaccio":
                    name = "Ajaccio";
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
                case "Grenoble Foot 38":
                    name = "Grenoble";
                    break;
                case "US Boulogne-sur-Mer":
                    name = "Boulogne";
                    break;
                case "Paris F.C.":
                    name = "Paris";
                    break;
                case "Bourg-Peronnas":
                    name = "Bourg Peronnas";
                    break;
                case "Red Star":
                    name = "Red Star 93";
                    break;
                case "Paris St Germain":
                    name = "Paris St.-Germain";
                    break;
                case "Rennais":
                    name = "Rennes";
                    break;
                case "Olympique Lyon":
                    name = "Ol. Lyon";
                    break;
                case "Saint Etienne":
                    name = "St. Etienne";
                    break;
                case "Havre":
                    name = "AC Havre";
                    break;
                case "Creteil-Lusitanos":
                    name = "Creteil";
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
                case "Istres FC":
                    name = "Istres";
                    break;
                case "EA Guingamp":
                    name = "Guingamp";
                    break;
                case "Amiens SC":
                    name = "Amiens";
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
                case "VVV Venlo":
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
                case "PSV":
                    name = "PSV Eindhoven";
                    break;
                case "Vitesse Arnhem":
                    name = "Vitesse";
                    break;
                case "SBV":
                    name = "Excelsior";
                    break;
                case "VV Venlo":
                    name = "Venlo";
                    break;
                case "FC Volendam":
                    name = "Volendam";
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
                case "Erciyesspor":
                    name = "Kayseri";
                    break;
                case "Rizespor":
                    name = "Caykur Rizespor";
                    break;
                case "Mersin":
                    name = "Mersin Idmanyurdu";
                    break;
                case "Osmanlispor":
                    name = "Ankaraspor";
                    break;
                case "Mersin Idman Yurdu":
                    name = "Mersin Idmanyurdu";
                    break;
                case "Buyuksehyr":
                    name = "Istanbul Buyuksehir";
                    break;
                case "Basaksehir":
                    name = "Istanbul Buyuksehir";
                    break;


                //Brasil
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
                case "Leuven":
                    name = "OH Leuven";
                    break;
                case "Oud-Heverlee Leuven":
                    name = "OH Leuven";
                    break;
                case "Zulte-Waregem":
                    name = "Zulte Waregem";
                    break;
                case "Sint-Truidense":
                    name = "Sint-Truidense VV";
                    break;
                case "Sint Truiden":
                    name = "Sint-Truidense VV";
                    break;
                case "St. Truiden":
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
                case "Beerschot":
                    name = "Germinal";
                    break;
                case "R. Charleroi":
                    name = "Charleroi";
                    break;
                case "Zulte":
                    name = "Zulte Waregem";
                    break;
                case "Royal Mouscron":
                    name = "Mouscron";
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
                case "RB Salzburg":
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
                case "FK Austria":
                    name = "Austria Wien";
                    break;
                case "Austria Vienna":
                    name = "Austria Wien";
                    break;
                case "Rapid Vienna":
                    name = "Rapid Wien";
                    break;
                case "SK Rapid":
                    name = "Rapid Wien";
                    break;
                case "Magna W Neustadt":
                    name = "Wiener Neustadt";
                    break;
                case "FC Wacker Innsbruck":
                    name = "Wacker Innsbruck";
                    break;
                case "SV Ried":
                    name = "Ried";
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
                case "Grasshopper Club":
                    name = "Grasshoppers";
                    break;
                case "GC Zurich":
                    name = "Grasshoppers";
                    break;
                case "Luzern FC":
                    name = "Luzern";
                    break;
                case "Sion FC":
                    name = "Sion";
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
                case "Dukla":
                    name = "Dukla Prag";
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


                //Slovakia
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
                case "Banska Bystrica":
                    name = "Dukla Prag";
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
                case "Copenhagen":
                    name = "Copenhagen FC";
                    break;
                case "Aarhus":
                    name = "Aarhus AGF";
                    break;
                case "Nordsjalland":
                    name = "Nordsjalland FC";
                    break;
                case "Viborg":
                    name = "Viborg FF";
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
                case "Hapoel Kfar-Sba":
                    name = "Hapoel Kfar Saba";
                    break;
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
                case "H. Kfar Saba":
                    name = "Hapoel Kfar Saba";
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
                case "Kiryat Shmone":
                    name = "Ironi Kiryat Shmona";
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
                case "Rangers FC":
                    name = "Rangers";
                    break;
                case "Johnstone":
                    name = "St Johnstone";
                    break;

                default:
                    name = inputName;
                    break;
            }

            return name;
        }
    }
}
