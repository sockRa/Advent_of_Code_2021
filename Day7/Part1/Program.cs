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
            var crabPositions = Array.ConvertAll(input, int.Parse);
            
            var min = crabPositions.Min();
            var max = crabPositions.Max();

            var currentFuelCost = 0;
            var cheapestFuelCost = int.MaxValue;

            for (var i = min; i < max; i++)
            {
                foreach (var position in crabPositions)
                {
                    currentFuelCost += Math.Abs(position - i);
                }
                
                if (currentFuelCost < cheapestFuelCost)
                {
                    cheapestFuelCost = currentFuelCost;
                }

                currentFuelCost = 0;
            }
            
            Console.WriteLine(cheapestFuelCost);
        }
    }
}