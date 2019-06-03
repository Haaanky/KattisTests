using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonelist
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = int.Parse(Console.ReadLine());
            while (inputs-- != 0)
            {
                var phoneNumbers = int.Parse(Console.ReadLine());
                var numberArr = new string[phoneNumbers];

                if (phoneNumbers > 9999)
                    throw new Exception();
                for (int j = 0; j < phoneNumbers; j++)
                {
                    numberArr[j] = Console.ReadLine();
                }


                Array.Sort(numberArr);
                //numberArr.OrderBy(x => x);
                bool containPrefix = true;

                for (int j = 1; j < phoneNumbers; j++)
                {
                    if (numberArr[j].StartsWith(numberArr[j - 1]))
                    {
                        containPrefix = false;
                        break;
                    }
                }
                if (phoneNumbers > 9999)
                    throw new Exception();
                Console.WriteLine(containPrefix ? "YES" : "NO");
            }
        }
    }
}