using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var team = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "STOP")
            {
                var tokens = input.Split().ToList();
                var command = tokens[0];

                if (command == "Add")
                {
                    var player = tokens[1];
                    if (!team.Contains(player))
                    {
                        team.Add(player);
                        Console.WriteLine($"{player} has been added to the team.");
                    }
                    else
                    {
                        Console.WriteLine($"{player} is already part of the team.");
                    }
                }
                else if (command == "Remove")
                {
                    var player = tokens[1];
                    if (!team.Contains(player))
                    {

                        Console.WriteLine($"{player} is not part of the team.");

                    }
                    else
                    {
                        team.Remove(player);
                        Console.WriteLine($"{player} has been removed.");

                    }
                }
                else if (command == "Change")
                {
                    List<string> players = tokens[1].Split('|').ToList();
                    string firstPlayer = players[0];
                    string secondPlayer = players[1];

                    if (team.Contains(firstPlayer))
                    {
                        //team.Select(p => p.Replace(firstPlayer, secondPlayer));
                        team[team.FindIndex(i => i.Equals(firstPlayer))] = secondPlayer;
                        Console.WriteLine($"Successfully changed {firstPlayer} with {secondPlayer}.");
                    }
                    else
                    {
                        Console.WriteLine($"{firstPlayer} is not part of the team.");
                    }
                }

                if (team.Count == 0)
                {
                    Console.WriteLine("There are no players left in the team.");
                    break;
                }
            }
            if (team.Count != 0)
            {
                Console.WriteLine(string.Join(", ", team));
            }
        }
    }
}