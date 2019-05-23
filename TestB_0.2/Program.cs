﻿using System;
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
            var count = 0;
            var index = 0;
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
                    var x = targetNumber / powerTo[i];
                    for (index = 0; index < targetNumber; index++)
                    {
                        partitionArray[index] = powerTo[i];
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
