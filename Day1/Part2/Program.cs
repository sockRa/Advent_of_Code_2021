using System;
using System.IO;

namespace Part2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var previousDepthWindow = int.MaxValue;
            var depthIncrease = 0;
            var globalCount = 0;

            var input = File.ReadAllLines(@"../../input.txt");

            for (var i = 0; i < (input.Length - 2); i++)
            {
                var currentDepthWindow = 0;

                for (var x = globalCount; x < (3 + globalCount); x++)
                {
                    currentDepthWindow += int.Parse(input[x]);
                }

                globalCount++;

                // only occurs once
                if (previousDepthWindow == int.MaxValue)
                {
                    previousDepthWindow = currentDepthWindow;
                    continue;
                }

                if (currentDepthWindow > previousDepthWindow)
                {
                    depthIncrease++;
                }

                previousDepthWindow = currentDepthWindow;
            }


            Console.WriteLine(depthIncrease);
        }
    }
}