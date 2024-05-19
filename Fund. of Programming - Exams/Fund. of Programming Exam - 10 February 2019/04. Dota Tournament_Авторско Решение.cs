using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskForExamClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = new List<Team>();

            var team = new Team();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Tournament end")
            {
                var data = input.Split(new[]{ " -> "}, StringSplitOptions.None).ToList();
                var command = data[0];

                if (command == "Disqualification")
                {
                    var teamName = data[1];
                    var teamForRemoving = teams.FirstOrDefault(x => x.TeamName == teamName);
                    teams.Remove(teamForRemoving);
                }
                else if (command == "New team")
                {
                    string teamName = data[1];
                    var players = data[2].ToString().Split(new[]{ ", "}, StringSplitOptions.None).ToList();
                    if (players.Count != 5 || teams.FirstOrDefault(x=>x.TeamName == teamName) != null)
                    {
                        continue;
                    }
                    var newTeam = new Team
                    {
                        TeamName = teamName,
                        PlayerNames = players
                    };

                    teams.Add(newTeam);
                }
                else if (command == "Win")
                {
                    string teamName = data[1];
                    var teamWithWin = teams.FirstOrDefault(x => x.TeamName == teamName);
                    if (teamWithWin == null)
                    {
                        continue;
                    }
                    teamWithWin.CountOfWins++;
                }
            }
            
            Console.WriteLine("Teams:");
            foreach (var t in teams.OrderByDescending(x=>x.CountOfWins))
            {
                Console.WriteLine($"{t.TeamName} - {string.Join(", ", t.PlayerNames)} -> {t.CountOfWins} wins");
            }
        }
    }

    public class Team
    {
        public string TeamName { get; set; }
        public List<string> PlayerNames { get; set; }
        public int CountOfWins { get; set; }
    }
}
