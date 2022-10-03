using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static FundamentalsWeek2.Printing;

namespace FundamentalsWeek2
{
    internal class DataSorting
    {
        internal static void SortData()
        {
            GameInfo info = new GameInfo();
            List<string> mapNameBank = new List<string>();
            string mostCommonGenre;
            int mostCommonGenreCount;



            // Number of games
            Print($"Total Entries: {info.MetaData.Count}");
            Print();



            // Most frequent genre
            mostCommonGenre = info.MetaData.Select(x => x.Genre).OrderBy(y => y.Count()).First();
            mostCommonGenreCount = info.MetaData.Count(x => x.Genre == mostCommonGenre);
            Print($"The most frequent genre is {mostCommonGenre} with a total of {mostCommonGenreCount} entries!");
            Print();



            // Map names with most characters excluding spaces with which game they belong to
            // Regular Expression example from https://stackoverflow.com/questions/6219454/efficient-way-to-remove-all-whitespace-from-string
            info.MetaData.Select(x => x.MapNames).ToList().ForEach(y => mapNameBank.AddRange(y));
            mapNameBank.OrderByDescending(x => RemoveWhiteSpace(x).Length).ToList().ForEach(y => Print($"Map name: {y}, length without spaces: {RemoveWhiteSpace(y).Length}, Game: {FindGameName(y)}"));
            Print();
            
            string RemoveWhiteSpace(string x)
            {
                return Regex.Replace(x, @"\s+", "");
            }

            string FindGameName(string name)
            {
                return info.MetaData.SelectMany(x => x.MapNames.Where(y => name == y).Select(z => x)).First().Name;
            }
            


            // Dictionary with KVP ID : INFO, display via loop
            var newDict = info.MetaData.ToDictionary(x => x.Id);
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
            info.MetaData.ForEach(x => x.MapNames.Where(y => y.Contains("z")).ToList().ForEach(z => Print(z)));


            Console.ReadLine();
        }
    }
}
