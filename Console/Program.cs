using System;
using System.Linq;
using Battleships.Application;
using Newtonsoft.Json;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {

            //for (int i = 0; i < 20; i++)
            //{
            //    var randomBoard = BoardGenerator.Generate();
            //    randomBoard.Display();

            //    var grouped = randomBoard.Ships.SelectMany(s => s.OccupiedCoordinates).GroupBy(s => new { s.Column, s.Row } ).Select(g => new { g.Key, Count = g.Count( )}).Where(c => c.Count > 1).ToList();

            //    if (grouped.Any())
            //    {
            //        //INVALID BOARD
            //        randomBoard.Display();
            //        System.Console.WriteLine(JsonConvert.SerializeObject(grouped));
            //        System.Console.WriteLine(JsonConvert.SerializeObject(randomBoard));

            //    }

            //}

            System.Console.Read();
        }
    }
}
