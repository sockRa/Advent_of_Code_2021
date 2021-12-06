using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Part1
{
    internal class Program
    {
        private static int X1 {get;set;}
        private static int X2 {get;set;}
        private static int Y1 {get;set;}
        private static int Y2 {get;set;}

        private class Diagram
        {
            public int[,] Map;
        }
        
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"..\..\input.txt");
            
            // Create diagram with map of max width and height
            var diagram = CreateDiagram(input);
            
            // Go through each tuple of coordinates and map them to the diagram
            MapToDiagram(diagram, input);

            var count = diagram.Map.Cast<int>().Count(i => i >= 2);
            Console.WriteLine(count);
        }

        private static void MapToDiagram(Diagram diagram, IEnumerable<string> input)
        {
            foreach (var coordinateRow in input)
            {
                var coordinateTuple = GetCoordinatesFromRow(coordinateRow);
                
                X1 = int.Parse(coordinateTuple[0]);
                Y1 = int.Parse(coordinateTuple[1]);
                X2 = int.Parse(coordinateTuple[2]);
                Y2 = int.Parse(coordinateTuple[3]);

                int index;
                
                if (X1 == X2)
                {

                    index = Y1 > Y2 ? Y2 : Y1;
                    var deltaY = (Math.Abs(Y1 - Y2)) + index;
                    
                    for (var column = index; column < deltaY + 1; column++)
                    {
                        diagram.Map[X1, column]++;
                    }
                }
                else if (Y1 == Y2)
                {
                    index = X1 > X2 ? X2 : X1;
                    var deltaX = (Math.Abs(X1 - X2)) + index;
                    
                    for (var row = index; row < deltaX + 1; row++)
                    {
                        diagram.Map[row, Y1]++;
                    }
                }
            }
        }
        private static Diagram CreateDiagram(IEnumerable<string> input)
        {
            foreach (var coordinateRow in input)
            {
                var row = GetCoordinatesFromRow(coordinateRow);
                
                X1 = int.Parse(row[0]) > X1 ? int.Parse(row[0]) : X1;
                X2 = int.Parse(row[1]) > X2 ? int.Parse(row[1]) : X2;
                Y1 = int.Parse(row[2]) > Y1 ? int.Parse(row[2]) : Y1;
                Y2 = int.Parse(row[3]) > Y2 ? int.Parse(row[3]) : Y2;
            }

            var maxWidth = X1 > X2 ? X1 : X2;
            var maxHeight = Y1 > Y2 ? Y1 : Y2;

            return new Diagram
            {
                Map = new int[maxWidth + 1, maxHeight + 1]
            };
        }

        private static string[] GetCoordinatesFromRow(string coordinateRow)
        {
            string[] separator = { "->",","};
            return coordinateRow.Trim().Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}