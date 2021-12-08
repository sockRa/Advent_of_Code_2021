using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Part1
{
    internal class Program
    {
        private static int segment0{get;set;} = 6;
        private static int segment1{get;set;} = 2;
        private static int segment2{get;set;} = 5;
        private static int segment3{get;set;} = 5;
        private static int segment4{get;set;} = 4;
        private static int segment5{get;set;} = 5;
        private static int segment6{get;set;} = 6;
        private static int segment7{get;set;} = 3;
        private static int segment8{get;set;} = 7;
        private static int segment9{get;set;} = 6;
        
        public static void Main(string[] args)
        {
            var inputRow = File.ReadAllLines(@"..\..\testInput.txt");
            
            var signalPatterns = new List<string>();
            var outputValue = new List<string>();

            foreach (var row in inputRow)
            {
                var temp = row.Split('|');
                signalPatterns.AddRange(temp[0].Trim().Split(' '));
                outputValue.AddRange(temp[1].Trim().Split(' '));
            }

            Console.WriteLine($"Part one: {SolvePartOne(outputValue)}");
        }

        private static int SolvePartOne(IEnumerable<string> outputValue)
        {
            return outputValue.Select(s => s.Length)
                .Count(length => length == segment1 || 
                                 length == segment4 || 
                                 length == segment7 || 
                                 length == segment8);
        }
    }
}