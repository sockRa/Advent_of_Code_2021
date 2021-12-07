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
            
            const int days = 256;
            const int maxAge = 8;
            var fishAge = new long[maxAge + 1];
            
            //Initial age
            foreach (var age in input)
            {
                var longAge = long.Parse(age);
                fishAge[longAge]++;
            }

            for (var day = 1; day <= days; day++)
            {
                var zeroAge = fishAge[0];
                
                for (var i = 1; i < fishAge.Length; i++)
                {
                    fishAge[i - 1] = fishAge[i];
                }
                
                fishAge[6] += zeroAge;
                fishAge[8] = zeroAge;
            }
            
            Console.WriteLine(fishAge.Sum());
        }
    }
}