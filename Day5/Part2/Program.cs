using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DiagramHelper;

namespace Part2
{
    internal class Program
    {
        private static int X1 {get;set;}
        private static int X2 {get;set;}
        private static int Y1 {get;set;}
        private static int Y2 {get;set;}
        
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"..\..\..\DiagramHelper\input.txt");
            
            // Create diagram with map of max width and height
            var diagram =  new Diagram(input);
            
            // Go through each tuple of coordinates and map them to the diagram
            MapToDiagram(diagram, input);

            var count = diagram.Map.Cast<int>().Count(i => i >= 2);
            Console.WriteLine(count);
        }
        
        private static void MapToDiagram(Diagram diagram, IEnumerable<string> input)
        {
            foreach (var coordinateRow in input)
            {
                var coordinateTuple = Diagram.GetCoordinatesFromRow(coordinateRow);
                
                X1 = int.Parse(coordinateTuple[0]);
                Y1 = int.Parse(coordinateTuple[1]);
                X2 = int.Parse(coordinateTuple[2]);
                Y2 = int.Parse(coordinateTuple[3]);

                int index;
                int deltaX;
                int deltaY;
                int indexX;
                int indexY;
                
                if (X1 == X2)
                {
                    index = Y1 > Y2 ? Y2 : Y1;
                    deltaY = Math.Abs(Y1 - Y2) + index;
                    
                    for (var column = index; column < deltaY + 1; column++)
                    {
                        diagram.Map[X1, column]++;
                    }
                }
                else if (Y1 == Y2)
                {
                    index = X1 > X2 ? X2 : X1;
                    deltaX = Math.Abs(X1 - X2) + index;
                    
                    for (var row = index; row < deltaX + 1; row++)
                    {
                        diagram.Map[row, Y1]++;
                    }
                }
                else if (X1 > X2)
                {
                    indexX = X1 > X2 ? X1 : X2;
                    indexY = Y1;
                    
                    deltaX = Math.Abs(X1 - X2 - indexX);
                    
                    for (var x = indexX; x >= deltaX; x--)
                    {
                        diagram.Map[x, indexY]++;

                        if (Y1 > Y2)
                        {
                            indexY--;
                        }
                        else
                        {
                            indexY++;
                        }
                        
                    }
                }
                else if (X1 < X2)
                {
                    indexX = X1 > X2 ? X2 : X1;
                    indexY = Y1;

                    deltaX = Math.Abs(X1 - X2 - indexX);

                    for (var x = indexX; x < deltaX + 1; x++)
                    {
                        diagram.Map[x, indexY]++;

                        if (Y1 > Y2)
                        {
                            indexY--;
                        }
                        else
                        {
                            indexY++;
                        }
                    }
                }
            }
        }
    }
}