using System;
using System.Linq;

namespace HeroOfEldevir
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.None).ToList();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Battle")
            {
                var tokens = input.Split().ToList();
                var command = tokens[0];
                var item = tokens[1];

                if (command == "Loot")
                {
                    if (!items.Contains(item))
                    {
                        items.Add(item);
                        Console.WriteLine($"{item} has been added to the inventory.");
                    }
                }
                else if(command == "Disenchant")
                {
                  items.Remove(item);
                    if (items.Count == 0)
                    {
                        Console.WriteLine("The inventory is empty.");
                        break;
                    }
                        Console.WriteLine($"{item} has been disenchanted.");
                }
                else if (command == "Upgrade")
                {
                    var upgrade = item.Split(new[] { "/" },StringSplitOptions.None);
                    var firstItem = upgrade[0];
                    var secondItem = upgrade[1];
                    if (items.Contains(firstItem))
                    {
                        string upgradesItem = firstItem + " ~ ".ToString() + secondItem;
                        items[items.FindIndex(ind => ind.Equals(firstItem))] = upgradesItem;
                        Console.WriteLine($"{firstItem} has been upgraded to {firstItem} ~ {secondItem}.");
                    }
                }

                if (items.Count == 0)
                {
                    Console.WriteLine("The inventory is empty.");
                    break;
                }
            }
			if(items.Count != 0){
           		Console.WriteLine("Red Paladin's inventory :");
            	foreach (var item in items)
            	{
               			 Console.WriteLine($"--> {item}");
            	}
            }
        }
    }
}
