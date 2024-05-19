using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace someShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            var result = new StringBuilder();
            var cinemaDict = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "Done")
            {
                var tokens = input.Split(new[] { "<=>", " : " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string cinemaName = tokens[0];
                string movieName = tokens[1];
                decimal price = decimal.Parse(tokens[2]);

                if (cinemaName.Contains("-") || cinemaName.Contains(">") || cinemaName.Length > 20)
                {
                    result.AppendLine("Invalid cinema name");
                    continue;
                }
                else if (movieName.Contains("-") || movieName.Contains(">") || movieName.Length > 20)
                {
                    result.AppendLine("Invalid movie name");
                    continue;
                }

                if (!cinemaDict.ContainsKey(cinemaName))
                {
                    cinemaDict[cinemaName] = new List<string>();
                }
                string movieNameAndPrice = movieName + " : " + price;
                cinemaDict[cinemaName].Add(movieNameAndPrice);
            }

            foreach (var c in cinemaDict.OrderBy(x=>x.Key))
            {
                result.AppendLine($"- {c.Key}");
                foreach (var m in c.Value.OrderByDescending(x => decimal.Parse(x.Split(new[] { " : " }, StringSplitOptions.RemoveEmptyEntries).Skip(1).First())))
                {
                    result.AppendLine(m.Trim());
                }
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
