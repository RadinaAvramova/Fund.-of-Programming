using System;
using System.Collections.Generic;

namespace CoderShowoff
{
    public class CoderShowoff
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var coders = new List<Coder>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var coder = Coder.Parse(input);
                if (coder.IsValid)
                    coders.Add(coder);
            }

            var mostEndurable = coders[0].Stamina;
            var mostEndurableIndex = 0;

            var weakest = coders[0].Strength;
            var weakestIndex = 0;

            var wisest = coders[0].Intellect;
            var wisestIndex = 0;

            long totalEndurance = coders[0].Stamina;
            long totalStrength = coders[0].Strength;
            long totalIntellect = coders[0].Intellect;

            for (int i = 1; i < coders.Count; i++)
            {
                if (coders[i].Stamina > mostEndurable)
                {
                    mostEndurable = coders[i].Stamina;
                    mostEndurableIndex = i;
                }

                if (coders[i].Strength <= weakest)
                {
                    weakest = coders[i].Strength;
                    weakestIndex = i;
                }

                if (coders[i].Intellect > wisest)
                {
                    wisest = coders[i].Intellect;
                    wisestIndex = i;
                }

                totalEndurance += coders[i].Stamina;
                totalStrength += coders[i].Strength;
                totalIntellect += coders[i].Intellect;
            }

            Console.WriteLine($"Most endurable player is: {coders[mostEndurableIndex].Name} with rank {coders[mostEndurableIndex].Rank} from guild {coders[mostEndurableIndex].Guild}");
            Console.WriteLine($"Weakest player is: {coders[weakestIndex].Name} with rank {coders[weakestIndex].Rank} from guild {coders[weakestIndex].Guild}");
            Console.WriteLine($"Wisest player is: {coders[wisestIndex].Name} with rank {coders[wisestIndex].Rank} from guild {coders[wisestIndex].Guild}");

            Console.WriteLine($"Total Endurance {totalEndurance}");
            Console.WriteLine($"Total Strength {totalStrength}");
            Console.WriteLine($"Total Intellect {totalIntellect}");
        }
    }

    public class Coder
    {
        public string Name { get; set; }

        public int Stamina { get; set; }

        public int Strength { get; set; }

        public int Intellect { get; set; }

        public char Rank { get; set; }

        public string Guild { get; set; }

        public bool IsValid => this.Stamina > 0 && this.Strength > 0 && this.Intellect > 0;

        public static Coder Parse(string input)
        {
            var data = input.Split('|');
            var result = new Coder
            {
                Name = data[0],
                Stamina = int.Parse(data[1]),
                Strength = int.Parse(data[2]),
                Intellect = int.Parse(data[3]),
                Rank = char.Parse(data[4]),
                Guild = data[5]
            };

            return result;
        }
    }
}