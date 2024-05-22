using System;
using System.Collections.Generic;

namespace DungeonLoot
{
    public class Program
    {
        static void Main(string[] args)
        {
            var startingGold = long.Parse(Console.ReadLine());
            var startingHealth = double.Parse(Console.ReadLine());

            var input = Console.ReadLine();

            Dictionary<string, Item> items = new Dictionary<string, Item>();

            var totalGold = startingGold;
            while (input != "NO MORE LOOT")
            {
                if (input.StartsWith("Gold"))
                {
                    var amount = input.Split(':')[1].Trim();
                    totalGold += int.Parse(amount);
                    input = Console.ReadLine();
                    continue;
                }

                var item = Item.Parse(input);
                var shouldKeep = item.IsUsefull && !items.ContainsKey(item.Name);

                if (shouldKeep)
                    items.Add(item.Name, item);
                else if (!item.IsLegendary)
                    totalGold += item.Price;

                input = Console.ReadLine();
            }

            var totalHealth = startingHealth;
            foreach (var item in items)
            {
                totalHealth += item.Value.HPBonus;
            }

            Console.WriteLine($"Marto has a total of {totalGold} gold.");
            Console.WriteLine($"Marto's total health is {totalHealth}.");
            Console.WriteLine($"Marto has collected the following items:");
            Console.WriteLine(string.Join(Environment.NewLine, items.Values));
        }
    }


    public class Item
    {
        public string Name { get; set; }

        public string Quality { get; set; }

        public int Price { get; set; }

        public double HPBonus { get; set; }

        public bool IsLegendary => this.Quality == "Legendary";

        public bool IsUsefull => this.Quality == "Legendary" || this.Quality == "Rare";

        public static Item Parse(string serializedItem)
        {
            var data = serializedItem.Split(':');
            var stats = data[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var resultingItem = new Item();

            resultingItem.Name = data[0];
            resultingItem.Quality = stats[0];
            resultingItem.Price = int.Parse(stats[1]);
            resultingItem.HPBonus = double.Parse(stats[2]);

            return resultingItem;
        }

        public override string ToString()
        {
            return $"> {this.Name} [Quality: {Quality}] [HP Bonus: {HPBonus}]";
        }
    }
}
