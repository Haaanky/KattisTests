using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        CountIntPartitions(3, 9);
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
                
                var result = CountIntPartitions(baseOfPowers, number);
                Console.WriteLine($"{set} {result}");
            }
        }
    }

    private static int CountIntPartitions(int baseOfPowers, int number)
    {
        var sum = 1;
        int remainder = number % baseOfPowers;
        int divided = number / baseOfPowers;
        sum += divided;
        var test2 = new List<int>();
        var test = new int[number, test2.Count()];
        var test3 = new List<int[]>();
        for (int i = 0; i < divided; i++)
        {
            for (int j = 0; j < number; j++)
            {
                test3.Add(new int[number]);
                //test3[j][1] = ;
            }
        }

        //number -= divided;
        //sum += number;
        if (divided == baseOfPowers)
            sum++;
        //sum += remainder;
        //sum += divided;
        for (int i = 0; i < divided /*+ remainder*/; i++)
        {
            //number -= divided;
            //sum += number;
            sum++;
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