using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plantingtrees
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var seedlingGrowthDays = Console.ReadLine().Split();
            var setSeedlings = new int[input];
            //var setSeedlings = new HashSet<int>();

            for (int i = 0; i < input; i++)
            {
                setSeedlings[i] = int.Parse(seedlingGrowthDays[i]);
                //setSeedlings.Add(int.Parse(seedlingGrowthDays[i]));
            }
            var total = setSeedlings.GroupBy(_ => _).Where(_ => _.Count() > 1).Sum(_ => _.Count());
            //var tmp = (input - setSeedlings.Count);
            Console.WriteLine(total+setSeedlings.Max()+1);

        }
    }
}
