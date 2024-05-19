using System;
using System.Collections.Generic;
using System.Linq;

namespace Card
{
    class Program
    {
        static void Main(string[] args) 
        {
            var cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToList();
                string model = input[0];
                int fuelAmount = int.Parse(input[1]);
                double fuelConsumationPer1Km = double.Parse(input[2]);

                if (cars.Any(x => x.Model == model))
                {
                    continue;
                }

                Car car = new Car(model, fuelAmount, fuelConsumationPer1Km);

                cars.Add(car);
            }
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                var token = command.Split().ToList();
                var carModel = token[1];
                var amountOfKm = int.Parse(token[2]);

                var equalCar = cars.FirstOrDefault(x => x.Model == carModel);

                if (equalCar != null)
                {
                    if (amountOfKm * equalCar.FuelConsumptionFor1km <= equalCar.FuelAmount)
                    {
                        equalCar.FuelAmount -= (amountOfKm * equalCar.FuelConsumptionFor1km);
                        equalCar.Distance += amountOfKm;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }
                }

            }

            foreach (var c in cars)
            {
                Console.WriteLine(c);
            }
        }
    }

    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumationFor1Km)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionFor1km = fuelConsumationFor1Km;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionFor1km { get; set; }
        public int Distance { get; set; }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.Distance}";
        }
    }
}
