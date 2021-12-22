using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    internal class Program
    {
        private static readonly Dictionary<char, int> ScoreBoard = new Dictionary<char, int>
        {
            { ')', 3 },
            { ']', 57 },
            { '}', 1197 },
            { '>', 25137 },
        };

        private static readonly List<char> OpeningChars = new List<char>
        {
            '(',
            '[',
            '{',
            '<'
        };

        private static readonly Dictionary<char, long> AutoCompleteScoreBoard = new Dictionary<char, long>
        {
            { '(', 1 },
            { '[', 2 },
            { '{', 3 },
            { '<', 4 },
        };

        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"..\..\input.txt");

            Console.WriteLine($"Part one: {SolvePartOne(input)}");
            Console.WriteLine($"Part two: {SolvePartTwo(input)}");
        }

        private static long SolvePartTwo(IEnumerable<string> input)
        {
            var stack = new Stack<char>();
            var scores = new List<long>();

            foreach (var line in input)
            {
                foreach (var c in line)
                {
                    if (OpeningChars.Contains(c))
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        if (Math.Abs(c - stack.Peek()) > 2)
                        {
                            // Line is corrupt
                            stack.Clear();
                            break;
                        }

                        stack.Pop();
                    }
                }

                // Skip counting points if stack is empty.
                if (!stack.Any())
                {
                    continue;
                }

                long score = 0;

                foreach (var c in stack)
                {
                    score = score * 5 + AutoCompleteScoreBoard.First(x => x.Key == c).Value;
                }

                stack.Clear();
                scores.Add(score);
            }

            scores.Sort();

            return scores[scores.Count / 2];
        }

        private static int SolvePartOne(IEnumerable<string> input)
        {
            var finalScore = 0;
            var stack = new Stack<char>();
            foreach (var line in input)
            {
                foreach (var c in line)
                {
                    if (OpeningChars.Contains(c))
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        var score = CheckSyntax(c, stack);
                        if (score == 0) continue;

                        // Something is not right
                        finalScore += score;
                        break;
                    }
                }
            }

            return finalScore;
        }

        private static int CheckSyntax(char c, Stack<char> openingSyntax)
        {
            // If the closing character matches the latest opening syntax, pop it
            switch (openingSyntax.Peek())
            {
                case '(':
                    if (c == ')')
                    {
                        openingSyntax.Pop();
                        return 0;
                    }

                    break;
                case '[':
                    if (c == ']')
                    {
                        openingSyntax.Pop();
                        return 0;
                    }

                    break;
                case '{':
                    if (c == '}')
                    {
                        openingSyntax.Pop();
                        return 0;
                    }

                    break;
                case '<':
                    if (c == '>')
                    {
                        openingSyntax.Pop();
                        return 0;
                    }

                    break;
            }

            foreach (var i in ScoreBoard.Where(i => i.Key == c))
            {
                return i.Value;
            }

            throw new InvalidOperationException();
        }
    }
}