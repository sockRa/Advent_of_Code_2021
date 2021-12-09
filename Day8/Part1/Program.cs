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
            var input = File.ReadAllLines(@"..\..\input.txt");

            Console.WriteLine($"Part one: {SolvePartOne(input)}");
            Console.WriteLine($"Part two: {SolvePartTwo(input)}");
        }

        private static int SolvePartTwo(string[] inputRow)
        {
            var answer = 0;

            foreach (var s in inputRow)
            {
                var mapping = new Dictionary<int, string>();
                var temp = s.Trim().Split('|');

                MapInputSignal(temp[0].Trim().Split(' '), mapping);
                answer += DecodeOutput(temp[1].Trim().Split(' '), mapping);
            }

            return answer;
        }

        private static int DecodeOutput(IEnumerable<string> inputSignals, IReadOnlyDictionary<int, string> mapping)
        {
            var output = "";

            foreach (var inputSignal in inputSignals)
                switch (inputSignal.Length)
                {
                    case 2:
                        output += "1";
                        break;
                    case 4:
                        output += "4";
                        break;
                    case 3:
                        output += "7";
                        break;
                    case 7:
                        output += "8";
                        break;
                    // Can be 2,3,5
                    case 5:
                        if (PatternIncludedInSignal(mapping[2], inputSignal))
                            output += "2";
                        else if (PatternIncludedInSignal(mapping[3], inputSignal))
                            output += "3";
                        else if (PatternIncludedInSignal(mapping[5], inputSignal)) output += "5";

                        break;

                    // Can be 0,6,9
                    case 6:
                        if (PatternIncludedInSignal(mapping[0], inputSignal))
                            output += "0";
                        else if (PatternIncludedInSignal(mapping[6], inputSignal))
                            output += "6";
                        else if (PatternIncludedInSignal(mapping[9], inputSignal)) output += "9";

                        break;
                    default:
                        throw new Exception();
                }

            return int.Parse(output);
        }

        private static void MapInputSignal(IEnumerable<string> inputSignals, IDictionary<int, string> mapping)
        {
            var sortedInputSignals = inputSignals.ToList().OrderBy(x => x.Length);

            foreach (var inputSignal in sortedInputSignals)
                switch (inputSignal.Length)
                {
                    // Represents number one
                    case 2:
                        if (!mapping.ContainsKey(1)) mapping.Add(1, inputSignal);

                        break;
                    // Represents number four
                    case 4:
                        if (!mapping.ContainsKey(4)) mapping.Add(4, inputSignal);

                        break;
                    // Represents number seven
                    case 3:
                        if (!mapping.ContainsKey(7)) mapping.Add(7, inputSignal);

                        break;
                    // Represents number eight
                    case 7:
                        if (!mapping.ContainsKey(8)) mapping.Add(8, inputSignal);

                        break;
                    // Can be 2,3,5
                    case 5:
                        if (PatternIncludedInSignal(mapping[1], inputSignal) && !mapping.ContainsKey(3))
                            // Number 3
                            mapping.Add(3, inputSignal);
                        // Number 5
                        else if (PatternIncludedInSignal(string.Concat(mapping[4].Except(mapping[7])), inputSignal)
                                 && !mapping.ContainsKey(5))
                            mapping.Add(5, inputSignal);
                        else if (!mapping.ContainsKey(2)) mapping.Add(2, inputSignal);

                        break;
                    // Can be 0,6,9
                    case 6:
                        // Number 0
                        if (PatternIncludedInSignal(mapping[7], inputSignal) &&
                            !PatternIncludedInSignal(mapping[4], inputSignal) && !mapping.ContainsKey(0))
                            mapping.Add(0, inputSignal);
                        // Number 9
                        else if (PatternIncludedInSignal(mapping[7], inputSignal) &&
                                 PatternIncludedInSignal(mapping[4], inputSignal) && !mapping.ContainsKey(9))
                            mapping.Add(9, inputSignal);
                        // Number 6
                        else if (!mapping.ContainsKey(6)) mapping.Add(6, inputSignal);

                        break;
                    default:
                        throw new Exception();
                }
        }

        private static bool PatternIncludedInSignal(string pattern, string inputSignal)
        {
            // If pattern is not found in input signal, return false. Else true.
            return pattern.All(x => inputSignal.IndexOf(x) != -1);
        }

        private static int SolvePartOne(IEnumerable<string> input)
        {
            var count = 0;

            foreach (var row in input)
            {
                var outputValueRow = row.Split('|');

                foreach (var outputValue in outputValueRow[1].Split(' '))
                    switch (outputValue.Length)
                    {
                        case 2:
                        case 3:
                        case 4:
                        case 7:
                            count++;
                            break;
                    }
            }

            return count;
        }
    }
}