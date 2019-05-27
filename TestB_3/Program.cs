using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string input;
        int numberOfDataSets = 0;

        while ((input = Console.ReadLine()) != null)
        {
            string[] split = input.Split();
            if (numberOfDataSets == 0)
                numberOfDataSets = int.Parse(split[0]);
            else
            {
                var set = split[0];
                var baseOfPowers = int.Parse(split[1]);
                var targetNumber = int.Parse(split[2]);
                var power = 0;
                var powerTo = new List<int>();
                do
                {
                    powerTo.Add((int)Math.Pow(baseOfPowers, power));
                    power++;
                } while (powerTo.LastOrDefault() < targetNumber);

                int[] partitionsPossibilities = new int[targetNumber];
                partitionsPossibilities[0] = 1;
                int result = 0;

                for (int i = 0; i < powerTo.Count; i++)
                {
                    for (int j = powerTo[i]; j <= targetNumber; j++)
                    {
                        if (j != targetNumber)
                            partitionsPossibilities[j] += partitionsPossibilities[j - powerTo[i]];
                        else
                            result += partitionsPossibilities[j - powerTo[i]];
                    }
                }
                Console.WriteLine($"{set} {result}");
            }
        }
    }
}