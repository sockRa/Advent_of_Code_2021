using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    internal class BingoBoard
    {
        public readonly string[,] Board = new string[5,5];
        public readonly string[,] MarkedNumbers = new string[5, 5];
        public string WinningNumber;
    }
    
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"../../input.txt");
            
            var bingoNumbers = input[0].Split(',').ToList();
            var bingoBoards = GetBoards(input.Skip(2)).ToList();
            var winningBoard = CheckBoards(bingoBoards, bingoNumbers);
            
            Console.WriteLine(CalculateSum(winningBoard));
            
            
        }

        private static int CalculateSum(BingoBoard winningBoard)
        {
            var sum = 0;

            for (var row = 0; row < winningBoard.Board.GetLength(0); row++)
            {
                for (var column = 0; column < winningBoard.Board.GetLength(1); column++)
                {
                    if (winningBoard.Board[row, column] != winningBoard.MarkedNumbers[row, column])
                    {
                        sum += int.Parse(winningBoard.Board[row, column]);
                    }
                }
            }
            
            return sum * int.Parse(winningBoard.WinningNumber);
        }

        private static BingoBoard CheckBoards(List<BingoBoard> bingoBoards, List<string> bingoNumbers)
        {
            foreach (var bingoNumber in bingoNumbers)
            {
                foreach (var bingoBoard in bingoBoards)
                {
                    for (var row = 0; row < bingoBoard.Board.GetLength(0); row++)
                    {
                        for (var column = 0; column < bingoBoard.Board.GetLength(1); column++)
                        {
                            if (bingoBoard.Board[row, column] != bingoNumber)
                            {
                                continue;
                            }

                            bingoBoard.MarkedNumbers[row, column] = bingoNumber;
                            
                            if (!IsBingo(bingoBoard.MarkedNumbers))
                            {
                                continue;
                            }

                            bingoBoard.WinningNumber = bingoNumber;
                            return bingoBoard;
                        }
                    }
                }
            }

            throw new InvalidOperationException();
        }

        private static bool IsBingo(string[,] bingoBoardMarkedNumbers)
        {
            var victory = false;

            for (var row = 0; row < bingoBoardMarkedNumbers.GetLength(0); row++)
            {
                victory = true;

                for (var column = 0; column < bingoBoardMarkedNumbers.GetLength(1); column++)
                {
                    if (bingoBoardMarkedNumbers[row, column] == null)
                    {
                        victory = false;
                        break;
                    }
                }

                if (victory)
                {
                    return victory;
                }
            }

            if (!victory)
            {
                for (var row = 0; row < bingoBoardMarkedNumbers.GetLength(0); row++)
                {
                    victory = true;

                    for (var column = 0; column < bingoBoardMarkedNumbers.GetLength(1); column++)
                    {
                        if (bingoBoardMarkedNumbers[column, row] == null)
                        {
                            victory = false;
                            break;
                        }
                    }

                    if (victory)
                    {
                        return victory;
                    }
                }
            }

            return victory;
        }

        private static IEnumerable<BingoBoard> GetBoards(IEnumerable<string> inputRows)
        {
            var bingoBoards = new List<BingoBoard>();

            var rowIndex = 0;
            var columnIndex = 0;
            
            // Create board
            var board = new BingoBoard();

            foreach (var row in inputRows)
            {
                // Board done
                if (row == "")
                {
                    bingoBoards.Add(board);
                    board = new BingoBoard();
                    columnIndex = 0;
                    rowIndex = 0;
                }

                foreach (var number in row.Split(' '))
                {
                    if (number == "")
                    {
                        continue;
                    }
                    
                    board.Board[rowIndex, columnIndex] = number;
                    columnIndex++;
                }
                
                // Happens when number == ""
                if (columnIndex == 0)
                {
                    continue;
                }
                
                rowIndex++;
                columnIndex = 0;
            }
            
            // Add last board
            bingoBoards.Add(board);

            return bingoBoards;
        }
    }
}