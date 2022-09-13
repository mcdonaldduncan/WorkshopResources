using System;
using System.Collections.Generic;
using System.Linq;
using static FundamentalsWeek2.Printing;

namespace FundamentalsWeek2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameInfo info = new GameInfo();
            List<Info> metaData = info.MetaData;
            List<string> mapNameBank = new List<string>();
            string mostCommonGenre;
            int mostCommonGenreCount;

            // Number of games
            Print($"Total Entries: {metaData.Count}");
            Print();
            
            // Most frequent genre
            mostCommonGenre = metaData.Select(x => x.Genre).OrderBy(y => y.Count()).First();
            mostCommonGenreCount = metaData.Count(x => x.Genre == mostCommonGenre);
            Print($"The most frequent genre is {mostCommonGenre} with a total of {mostCommonGenreCount} entries!");
            Print();

            // Map names with most characters excluding spaces with which game they belong to
            metaData.Select(x => x.MapNames).ToList().ForEach(y => mapNameBank.AddRange(y));
            mapNameBank.OrderByDescending(x => x.Trim().Length).ToList().ForEach(y => Print($"Map name: {y}, length without spaces: {y.Trim().Length}, Game: {FindGameName(y)}"));
            Print();
            
            string FindGameName(string name)
            {
                return metaData.SelectMany(x => x.MapNames.Where(y => name == y).Select(z => x)).First().Name;
            }
            
            // Dictionary with KVP ID : INFO, display via loop
            var newDict = metaData.ToDictionary(x => x.Id);
            Print("Dictionary with kvp of id : info, displayed with loop:");
            foreach (var kvp in newDict)
            {
                Print($"Key: {kvp.Key}");
                Print($"Name: {kvp.Value.Name}");
                Print($"Genre: {kvp.Value.Genre}");
                Print($"Total Maps: {kvp.Value.MapNames.Length}");
                string mapNames = "";
                for (int i = 0; i < kvp.Value.MapNames.Length; i++)
                {
                    if (i == kvp.Value.MapNames.Length - 1)
                    {
                        mapNames += kvp.Value.MapNames[i];
                    }
                    else
                    {
                        mapNames += kvp.Value.MapNames[i] + ", ";
                    }
                }
                Print($"Map Names: {mapNames}");
                Print();
            }
            Print();

            // Map names that have the letter z in them
            Print("Map names that contain z: ");
            metaData.ForEach(x => x.MapNames.Where(y => y.Contains("z")).ToList().ForEach(z => Print(z)));


            Console.ReadLine();
        }
    }

    public class Info
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string[] MapNames { get; set; }
    }

    public class GameInfo
    {
        public GameInfo()
        {
            MetaData = new List<Info>();

            Info info1 = new Info();
            info1.Id = 0;
            info1.Name = "Monkey Island";
            info1.Genre = "Point & Click";
            info1.MapNames = new string[] { "Guybrush Mansion", "LeChuck Hideout", "Melee Island", "SCUMM Bar" };
            MetaData.Add(info1);

            Info info2 = new Info();
            info2.Id = 1;
            info2.Name = "Mario Odyssey";
            info2.Genre = "Adventure";
            info2.MapNames = new string[] { "Mushroom Kingdom", "Cap Kingdom", "Cloud Kingdom", "Snow Kingdom" };
            MetaData.Add(info2);

            Info info3 = new Info();
            info3.Id = 2;
            info3.Name = "Final Fantasy 10";
            info3.Genre = "Adventure";
            info3.MapNames = new string[] { "Besaid Island", "Bevelle", "Calm Lands", "Baaj Temple" };
            MetaData.Add(info3);

            Info info4 = new Info();
            info4.Id = 3;
            info4.Name = "Valkyra 4";
            info4.Genre = "Tactical RPG";
            info4.MapNames = new string[] { "Battle of Siegval", "Other Kai", "Azure Flame", "Midnight Run" };
            MetaData.Add(info4);
        }

        public List<Info> MetaData { get; set; }
    }

    public static class Printing
    {
        public static void Print(string content)
        {
            Console.WriteLine(content);
        }
        
        public static void Print()
        {
            Console.WriteLine("");
        }

    }
}
