﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Cpp();
            ProperMethod();
        }

        private static void ProperMethod()
        {
            string input;
            int numberOfDataSets = 0;
            //int numberOfDataSets = 0;
            //int set = 0;
            while ((input = Console.ReadLine()) != null)
            {
                string[] split = input.Split(' ');
                if (numberOfDataSets == 0)
                    numberOfDataSets = int.Parse(split[0]);
                else
                {
                    var set = split[0];
                    var baseOfPowers = int.Parse(split[1]);
                    var number = int.Parse(split[2]);
                    var result = 0;

                    Console.WriteLine($"{set} {result}");
                }
            }
        }

        private static void Cpp()
        {
            int N = 5;
            while (N-- > 0)
            {
                int set = 1;
                int basePower = 97;
                int targetNumber = 9999;

                int s = (int)(Math.Log(targetNumber) / Math.Log(basePower)) + 1;
                int[] c = new int[s];
                c[0] = 1;
                for (int i = 1; i < s; i++)
                {
                    c[i] = basePower * c[i - 1];
                }

                uint[] r = new uint[targetNumber + 1];
                //memset(r, 0, sizeof(uint));
                r[0] = 1;

                for (int i = 0; i < s; i++)
                {
                    for (int j = c[i]; j <= targetNumber; j++)
                    {
                        r[j] += r[j - c[i]];
                    }
                }

                Console.Write(set);
                Console.Write(" ");
                Console.Write(r[targetNumber]);
                Console.Write("\n");
            }
        }
    }
}