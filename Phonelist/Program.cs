using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonelist
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());
            CompareInfo compare = CultureInfo.InvariantCulture.CompareInfo;
            while (inputs-- != 0)
            {
                int phoneNumbers = int.Parse(Console.ReadLine());
                //var numberArr = new string[phoneNumbers];
                var numberArr = new List<string>();

                for (int j = 0; j < phoneNumbers; j++)
                {
                    numberArr.Add(Console.ReadLine());
                }

                numberArr.Sort();
                //numberArr.OrderBy(x => x);
                bool containPrefix = true;
                //var tmpArr = numberArr.ToArray();
                //Array.Sort(tmpArr);
                for (int j = 1; j < phoneNumbers; j++)
                {
                    if (numberArr[j].Length > numberArr[j - 1].Length)
                        if (compare.IsPrefix(numberArr[j], numberArr[j - 1]))
                        {
                            containPrefix = false;
                            break;
                        }
                    //if (tmpArr[j].StartsWith(tmpArr[j - 1]))
                    //{
                    //    containPrefix = false;
                    //    break;
                    //}
                }
                Console.WriteLine(containPrefix ? "YES" : "NO");
            }
        }
    }
}