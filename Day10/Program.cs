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

        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"..\..\input.txt");

            Console.WriteLine($"Part one: {SolvePartOne(input)}");
        }

        private static int SolvePartOne(IEnumerable<string> input)
        {
            var finalScore = 0;
            var openingSyntax = new Stack<char>();
            foreach (var line in input)
            {
                foreach (var c in line)
                {
                    if (c == '(' || c == '[' || c == '{' || c == '<')
                    {
                        openingSyntax.Push(c);
                    }
                    else
                    {
                        var score = CheckSyntax(c, openingSyntax);
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