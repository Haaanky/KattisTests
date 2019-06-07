using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace different
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != null)
            {
                var split = input.Split();
                var firstInt = Int64.Parse(split[0]);
                var secondInt = Int64.Parse(split[1]);
                if (firstInt < secondInt)
                    Console.WriteLine(secondInt - firstInt);
                else
                    Console.WriteLine(firstInt - secondInt);
            }
        }
    }
}
