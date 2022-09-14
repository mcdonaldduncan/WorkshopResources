using System;
using System.Collections.Generic;
using System.Linq;
using static FundamentalsWeek2.Printing;

namespace FundamentalsWeek2
{
    internal class DataSorting
    {
        internal static void SortData()
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
                kvp.Value.MapNames.SkipLast(1).ToList().ForEach(x => mapNames += x + ", ");
                mapNames += kvp.Value.MapNames.Last();
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
}
