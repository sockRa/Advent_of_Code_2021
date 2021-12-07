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
            
            Console.WriteLine($"Part one: {SolvePartOne(crabPositions)}");
            Console.WriteLine($"Part two: {SolvePartTwo(crabPositions)}");

        }

        private static int SolvePartTwo(int[] crabPositions)
        {
            var currentFuelCost = 0;
            var cheapestFuelCost = int.MaxValue;
            
            var min = crabPositions.Min();
            var max = crabPositions.Max();
            
            for (var i = min; i < max; i++)
            {
                foreach (var position in crabPositions)
                {
                    var horizontalCount = Math.Abs(position - i);
                    
                    for (var cost = 1; cost <= horizontalCount; cost++)
                    {
                        currentFuelCost += cost;
                    }
                }
                
                if (currentFuelCost < cheapestFuelCost)
                {
                    cheapestFuelCost = currentFuelCost;
                }

                currentFuelCost = 0;
            }

            return cheapestFuelCost;
        }

        private static int SolvePartOne(int[] crabPositions)
        {
            var currentFuelCost = 0;
            var cheapestFuelCost = int.MaxValue;
            
            var min = crabPositions.Min();
            var max = crabPositions.Max();
            
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

            return cheapestFuelCost;
        }
    }
}