using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var r1 = int.Parse(input[0]);
            var s = int.Parse(input[1]);
            Console.WriteLine(s * 2 - r1);
        }
    }
}
