using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guess
{
    class Program
    {
        static void Main(string[] args)
        {
            var lowerBound = 1;
            var upperBound = 1000;
            var numberToTry = 500;
            Console.WriteLine(numberToTry);

            string input;
            while ((input = Console.ReadLine()) != null)
            {
                switch (input)
                {
                    case "lower":
                        Console.WriteLine(numberToTry = (lowerBound + (upperBound = numberToTry)) / 2);
                        break;
                    case "higher":
                        Console.WriteLine(numberToTry = ((lowerBound = ++numberToTry) + upperBound) / 2);
                        break;
                    case "correct":
                        return;
                    default:
                        break;
                }
            }

        }
    }
}
