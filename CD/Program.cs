using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "0 0")
        {
            var firstLine = input.Split();
            var jack = int.Parse(firstLine[0]);
            var jill = int.Parse(firstLine[1]);
            var jackArray = new int[jack];
            var jillArray = new int[jill];

            for (int i = 0; i < jack; i++)
            {
                jackArray[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < jill; i++)
            {
                jillArray[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(jackArray.Intersect(jillArray).Count());

            //var nullVal = Console.ReadLine();
        }
    }
}