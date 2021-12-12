using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace app
{
    internal class Program
    {
        private static int[,] _heightMap;

        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"..\..\input.txt");

            _heightMap = new int[input.Length, input[0].Length];
            var row = 0;
            var column = 0;

            foreach (var inputRow in input)
            {
                foreach (var character in inputRow)
                {
                    _heightMap[row, column] = (int)char.GetNumericValue(character);
                    column++;
                }

                row++;
                column = 0;
            }

            Console.WriteLine($"Part one: {SolvePartOne()}");
            Console.WriteLine($"Part two: {SolvePartTwo()}");
        }

        private static int SolvePartTwo()
        {
            var largestBasins = new List<int>();

            for (var row = 0; row < _heightMap.GetLength(0); row++)
            for (var column = 0; column < _heightMap.GetLength(1); column++)
            {
                var lowPoints = GetNeighbours(row, column);

                if (_heightMap[row, column] < lowPoints.Values.Min())
                {
                    var basinSize = GetBasinSize(row, column);
                    largestBasins.Add(basinSize);

                    if (largestBasins.Count() > 3) largestBasins.Remove(largestBasins.Min());
                }
            }

            var sum = 0;
            foreach (var basin in largestBasins)
                if (sum == 0)
                    sum = basin;
                else
                    sum *= basin;

            return sum;
        }

        private static int GetBasinSize(int row, int column)
        {
            var visitedIndexes = new List<string>();
            var toBeVisited = new List<string> { $"{row} {column}" };

            while (toBeVisited.Any())
            {
                // Get first index
                var index = toBeVisited.First().Split(' ');
                row = int.Parse(index[0]);
                column = int.Parse(index[1]);

                var neighbors = GetNeighbours(row, column);

                visitedIndexes.Add(toBeVisited.First());
                toBeVisited.RemoveAt(0);

                foreach (var i in neighbors.Where(x => x.Value < 9))
                    if (!visitedIndexes.Contains(i.Key) && !toBeVisited.Contains(i.Key))
                        toBeVisited.Add(i.Key);
            }

            return visitedIndexes.Count;
        }

        private static int SolvePartOne()
        {
            var totalLowPoints = 0;

            for (var row = 0; row < _heightMap.GetLength(0); row++)
            {
                for (var column = 0; column < _heightMap.GetLength(1); column++)
                {
                    var lowPoints = GetNeighbours(row, column);

                    if (_heightMap[row, column] < lowPoints.Values.Min())
                    {
                        totalLowPoints += _heightMap[row, column] + 1;
                    }
                }
            }

            return totalLowPoints;
        }

        private static Dictionary<string, int> GetNeighbours(int row, int column)
        {
            var values = new Dictionary<string, int>
            {
                // Top
                { $"{row - 1} {column}", GetIfValid(row - 1, column) },
                // Left
                { $"{row} {column - 1}", GetIfValid(row, column - 1) },
                // Bottom
                { $"{row + 1} {column}", GetIfValid(row + 1, column) },
                // Right
                { $"{row} {column + 1}", GetIfValid(row, column + 1) }
            };

            return values;
        }

        private static int GetIfValid(int row, int column)
        {
            try
            {
                return _heightMap[row, column];
            }
            catch (IndexOutOfRangeException)
            {
                return int.MaxValue;
            }
        }
    }
}