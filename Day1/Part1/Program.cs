using System;
using System.IO;
using System.Linq;

namespace Part1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"../../input.txt");

            var previousNumber = input[0];
            var currentNumber = 0;
            var depthIncrease = 0;
            
            foreach (var s in input.Skip(1))
            {
                if (int.Parse(s) > int.Parse(previousNumber))
                {
                    depthIncrease++;
                }

                previousNumber = s;
            }
            
            Console.WriteLine(depthIncrease);
        }
    }
}