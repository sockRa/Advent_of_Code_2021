using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Program
    {
        static void Main()
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
            Console.ReadKey();
        }
    }
}
