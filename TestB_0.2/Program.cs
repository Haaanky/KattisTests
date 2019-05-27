using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestB_0._2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int baseOfPowers = 3;
            const int targetNumber = 9;

            var power = 0;
            var powerTo = new List<int>();
            var partitionArray = new int[targetNumber];
            var tempListToPrint = new List<int[]>();
            do
            {
                powerTo.Add((int)Math.Pow(baseOfPowers, power));
                power++;
            } while (powerTo.LastOrDefault() < targetNumber);
            powerTo = powerTo.OrderByDescending(i => i).ToList();
            while (true)
            {
                for (int i = 0; i < powerTo.Count; i++)
                {
                    for (int j = 0; j < targetNumber; j++)
                    {
                        partitionArray[j] = powerTo[i];
                        if (partitionArray.Sum() == targetNumber)
                            //count++;
                            tempListToPrint.Add(partitionArray.ToArray());
                    }
                }
                foreach (var item in tempListToPrint)
                {
                    foreach (var integer in item)
                    {
                        Console.Write(integer);
                    }
                    Console.WriteLine();
                }
                break;
            }
        }
    }
}
