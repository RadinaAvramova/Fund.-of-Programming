﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> Dictionaty = new Dictionary<string, List<string>>();
            while (input != "Fight")
            {
                string[] tokens = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string pokeName = tokens[0];

                if (tokens.Length > 1)
                {
                    if (!Dictionaty.ContainsKey(pokeName))
                    {
                        Dictionaty[pokeName] = new List<string>();
                    }
                    string pointsEvolutionType = tokens[1] + " <> " + long.Parse(tokens[2]);
                    Dictionaty[pokeName].Add(pointsEvolutionType);
                }
                else
                {
                    if (Dictionaty.ContainsKey(pokeName))
                    {
                        Console.WriteLine("^ " + pokeName);
                        foreach (string evolution in Dictionaty[pokeName])
                        {
                            Console.WriteLine(evolution);
                        }
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var item in Dictionaty)
            {
                Console.WriteLine("^ " + item.Key);
                foreach (string typeandNumber in item.Value.OrderByDescending(x => long.Parse(x.Split(new[] { " <> " }, StringSplitOptions.None).Skip(1).First())))
                {
                    Console.WriteLine(typeandNumber);
                }
            }
        }
    }
}