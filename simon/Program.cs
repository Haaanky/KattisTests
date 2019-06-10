using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simon
{
    class Program
    {
        static void Main(string[] args)
        {
            var testCases = int.Parse(Console.ReadLine());

            for (int i = 0; i < testCases; i++)
            {
                var input = Console.ReadLine();
                var inputSplit = input.Split();

                if (inputSplit.Length > 1)
                    if (inputSplit[0] == "simon" && inputSplit[1] == "says" && input.Length > 11)
                        Console.WriteLine(input.Substring(11));
                    else
                        Console.WriteLine();
                else
                    Console.WriteLine();
            }
        }
    }
}
