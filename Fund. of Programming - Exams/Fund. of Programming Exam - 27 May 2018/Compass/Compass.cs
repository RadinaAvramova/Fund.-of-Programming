using System;

namespace Compass
{
    public class Compass
    {
        public static void Main()
        {
            char initalDirection = char.Parse(Console.ReadLine());
            string[] directions = { "North", "East", "South", "West" };
            int dirCount = directions.Length;

            var startIndex = GetStartIndex(initalDirection, directions);

            var input = Console.ReadLine();
            while (input != "END")
            {
                var degrees = int.Parse(input);
                var steps = Math.Abs(degrees / 45);

                if (degrees > 0)
                {
                    startIndex = (startIndex + steps) % dirCount;
                }
                else
                {
                    startIndex = (startIndex - steps) % dirCount;

                    if (startIndex < 0)
                        startIndex = dirCount - Math.Abs(startIndex);
                }

                input = Console.ReadLine();
            }

            var startingPosition = directions[GetStartIndex(initalDirection, directions)];

            Console.WriteLine($"Starting Position: {startingPosition}");
            Console.WriteLine($"Position After Rotating: {directions[startIndex]}");
        }

        private static int GetStartIndex(char initalDirection, string[] directions)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i].StartsWith(initalDirection.ToString()))
                    return i;
            }
            return 0;
        }
    }
}