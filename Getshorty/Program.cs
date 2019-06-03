using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getshorty
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "0 0")
            {
                var firstLine = input.Split();
                var n = int.Parse(firstLine[0]); // 2 <= n <= 10 000
                var m = int.Parse(firstLine[1]); // 1 <= m <= 15 000
                var corridors = new List<Corridor>();

                for (int i = 0; i < m; i++)
                {
                    var corridorInput = Console.ReadLine().Split();

                    corridors.Add(new Corridor
                    {
                        X = int.Parse(corridorInput[0]),
                        Y = int.Parse(corridorInput[1]),
                        F = double.Parse(corridorInput[2])
                    });
                }

                Console.WriteLine(CheckSize());

                double CheckSize()
                {
                    var start = 0;
                    var exit = n - 1;
                    var currentPos = start;
                    var startSize = 1.0;
                    var currentSize = startSize;

                    for (int i = 0; currentPos != exit; i++)
                    {
                        if(corridors[i].X == currentPos && corridors[i].Y > currentPos)
                        {
                            currentPos = corridors[i].Y;
                            currentSize *= corridors[i].F;
                        } else if (corridors[i].Y == currentPos && corridors[i].X > currentPos)
                        {
                            currentPos = corridors[i].X;
                            currentSize *= corridors[i].F;
                        }
                    }

                    return currentSize;
                }
            }
        }
    }
    internal class Corridor
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double F { get; set; }
        public override string ToString()
        {
            return $"{X}, {Y}, {F}";
        }
    }
    internal class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Size { get; set; }
    }
}
