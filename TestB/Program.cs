using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine(CountIntPartitions(3, 9));
        NextTestMethod(3, 9);
        //string input;
        //int numberOfDataSets = 0;
        ////int numberOfDataSets = 0;
        ////int set = 0;
        //while ((input = Console.ReadLine()) != null)
        //{
        //    string[] split = input.Split(' ');
        //    if (numberOfDataSets == 0)
        //        numberOfDataSets = int.Parse(split[0]);
        //    else
        //    {
        //        var set = split[0];
        //        var baseOfPowers = int.Parse(split[1]);
        //        var number = int.Parse(split[2]);

        //        var result = CountIntPartitions(baseOfPowers, number);
        //        Console.WriteLine($"{set} {result}");
        //    }
        //}
    }

    private static void NextTestMethod(int basePower, int target)
    {
        var power = 0;
        var powerTo = new List<int>();
        while (powerTo.LastOrDefault() < target)
        {
            powerTo.Add((int)Math.Pow(basePower, power));
            power++;
        }
        if (powerTo.LastOrDefault() > target)
            powerTo.Remove(powerTo.Last());

        int[] intPartition = new int[target];
        int index = 0;
        intPartition[index] = target;

        while (true)
        {
            if (powerTo.ToArray().Intersect(intPartition).Sum() == target)
            {
                Console.WriteLine("It worked!");
            }
            foreach (var item in intPartition)
            {
                if (item != 0)
                    Console.Write(item);
            }
            Console.WriteLine();

            int remainingValue = 0;

            while (index >= 0 && intPartition[index] == 1)
            {
                remainingValue += intPartition[index];
                index--;
            }

            if (index < 0)
                return;

            // Flyttar ner index ev. startar om nästa partition
            intPartition[index]--;
            remainingValue++;

            // if sats för att kolla så att värdet som ska sättas in i min array är en valid power, 
            if (/*powerTo.Contains(intPartition[index])*/true)
            {


                while (remainingValue > intPartition[index])
                {
                    intPartition[index + 1] = intPartition[index];
                    remainingValue = remainingValue - intPartition[index];
                    index++;
                }

                intPartition[index + 1] = remainingValue;
                index++;
            }
            //if (powerTo.ToArray().Intersect(intPartition).Sum() == target)
            //{
            //    Console.WriteLine("It worked!");
            //}
        }

    }

    private static int CountIntPartitions(int baseOfPowers, int number)
    {
        var sum = 1;
        int remainder = number % baseOfPowers;
        int divided = number / baseOfPowers;
        //sum += divided;
        var test2 = new List<int>();
        var test = new int[number, test2.Count()];
        var test3 = new List<int?[]>();
        var power = 0;
        var powerTo = new List<int>();
        while (powerTo.LastOrDefault() < number)
        {
            powerTo.Add((int)Math.Pow(baseOfPowers, power));
            //sum += powerTo[power] / baseOfPowers;
            power++;
            //Console.WriteLine(powerTo[power]);
        }
        if (powerTo.LastOrDefault() > number)
            powerTo.Remove(powerTo.Last());

        //for (int i = 0; i < powerTo.Count; i++)
        //{
        //    test3.Add(new int[powerTo[i]]);
        //    for (int j = 0; j < number; j++)
        //    {
        //        Console.Write(test3[i][j] = powerTo[i]);
        //    }
        //}

        var baseArr = new int?[number];
        for (int i = 0; i < baseArr.Length; i++)
        {
            baseArr[i] = 1;
        }

        //while (true)
        //{
        for (int i = 0; i < powerTo.Count; i++)
        {
            for (int j = 0; j < baseArr.Length; j++)
            {
                baseArr[j] *= powerTo[i];
                baseArr[baseArr.Length - (j + 1)] = 0;
                if (baseArr.Sum() == number)
                    test3.Add(baseArr);
            }
        }
        //}
        var count = 0;
        for (int i = 0; i < number; i++)
        {
            for (int j = 0; j < number; j++)
            {
                test2.Add(powerTo[i]);
                if (test2.Sum() == number)
                    count++;
            }
        }
        //number -= divided;
        //sum += number;
        //if (divided == baseOfPowers)
        //    sum++;
        //sum += remainder;
        //sum += divided;
        for (int i = 0; i < divided /*+ remainder*/; i++)
        {
            //number -= divided;
            //sum += number;
            //sum++;
            //divided = number / baseOfPowers;
            //sum += divided;
        }


        //for (int i = 0; i < remainder; i++)
        //{
        //    sum += CountIntPartitions(remainder, baseOfPowers);
        //}
        return sum;
    }
}