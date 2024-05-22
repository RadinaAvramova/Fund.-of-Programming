using System;

namespace WorldOfCodeCraft
{
    public class WorldOfCodecraft
    {
        public static void Main()
        {
            const int NumberOfInputs = 10;

            var minimumTemperature = double.MaxValue;
            var daysWithNegativeTemperature = 0;
            bool requirementsMet = true;

            for (int i = 0; i < NumberOfInputs; i++)
            {
                var temperature = double.Parse(Console.ReadLine());
                if (temperature < -10.0d || temperature > 45.0d)
                {
                    requirementsMet = false;
                }

                if (temperature < 0)
                {
                    daysWithNegativeTemperature++;
                }

                if (temperature < minimumTemperature)
                    minimumTemperature = temperature;
            }

            if (requirementsMet && daysWithNegativeTemperature < 5)
            {
                Console.WriteLine($"The lowest temperature is {minimumTemperature:f1} degrees. The coders are off to battle!");
            }
            else
            {
                Console.WriteLine($"The lowest temperature is {minimumTemperature:f1} degrees. The coders rest.");
            }
        }
    }
}
