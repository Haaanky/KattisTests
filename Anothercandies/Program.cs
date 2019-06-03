using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anothercandies
{
    class Program
    {
        static void Main(string[] args)
        {
            var testCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                Console.ReadLine();
                var amountChildren = int.Parse(Console.ReadLine());
                decimal candy = 0;
                for (int j = 0; j < amountChildren; j++)
                {
                    candy += decimal.Parse(Console.ReadLine());
                }
                if(candy % amountChildren == 0)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }
    }
}
