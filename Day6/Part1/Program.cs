using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Part1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"..\..\input.txt").First().Split(',');
            var fish = input.Select(timer => new Lanternfish(int.Parse(timer))).ToList();

            Simulate(fish, 80);
        }

        private static void Simulate(ICollection<Lanternfish> fishes, int days)
        {
            var dayCount = 0;
            
            while (dayCount != days)
            {
                var currentFishStock = new List<Lanternfish>(fishes);
                
                foreach (var fish in currentFishStock)
                {
                    if (fish.internalTimer != 0)
                    {
                        fish.internalTimer--;
                        continue;
                    }

                    fish.internalTimer = 6;
                    fishes.Add(new Lanternfish(8));
                }

                dayCount++;
            }
            
            Console.WriteLine(fishes.Count);
        }
    }
}