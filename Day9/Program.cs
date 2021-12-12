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
        }

        private static int SolvePartOne()
        {
            var totalLowPoints = 0;
            
            // Go through each row
            for (var row = 0; row < _heightMap.GetLength(0); row++)
            {
                for (var column = 0; column < _heightMap.GetLength(1); column++)
                {
                    var lowPoints = GetTheLowestPoint(row, column);
                    //Console.WriteLine($"Current pos: {row},{column}. Digit: {_heightMap[row,column]}");

                    if (_heightMap[row, column] < lowPoints.Values.Min())
                    {
                        totalLowPoints += _heightMap[row, column] + 1;
                        //Console.WriteLine($"Add: {_heightMap[row, column] + 1}. Total: {totalLowPoints}");
                    }
                }
            }

            return totalLowPoints;
        }

        private static Dictionary<string,int> GetTheLowestPoint(int row, int column)
        {
            var values = new Dictionary<string, int>
            {
                // Top
                { $"{row - 1} {column}", GetIfValid(row - 1, column) },
                // Left
                { $"{row} {column - 1}",GetIfValid(row, column - 1)  },
                // Bottom
                { $"{row + 1} {column}", GetIfValid(row + 1, column) },
                // Right
                {  $"{row} {column + 1}", GetIfValid(row, column + 1)}
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