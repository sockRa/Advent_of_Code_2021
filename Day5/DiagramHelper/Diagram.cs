using System;
using System.Collections.Generic;

namespace DiagramHelper
{
    public class Diagram
    {
        protected static int X1 {get;set;}
        protected static int X2 {get;set;}
        protected static int Y1 {get;set;}
        protected static int Y2 {get;set;}

        public int[,] Map { get; set; }

        public Diagram(IEnumerable<string> input)
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

            Map = new int[maxWidth + 1, maxHeight + 1];
        }

        public static string[] GetCoordinatesFromRow(string coordinateRow)
        {
            string[] separator = { "->",","};
            return coordinateRow.Trim().Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}