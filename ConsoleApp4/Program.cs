// C# program to generate all unique 
// partitions of an integer 
using System;
using System.Collections.Generic;
using System.Linq;

class GFG
{
    static List<int[]> partitionsList = new List<int[]>();
    static int count = 0;

    // Function to print an array p[] 
    // of size n 
    static int[] printArray(int[] p, int n)
    {
        var tmp = new int[n];
        for (int i = 0; i < n; i++)
        {
            tmp[i] = p[i];
            //Console.Write(p[i] + " ");
        }
        //Console.WriteLine();
        return tmp;
    }

    // Function to generate all unique partitions of an integer 
    static void printAllUniqueParts(int targetNumber)
    {
        var baseOfPowers = 5;
        var power = 0;
        var powerTo = new List<int>();
        while (powerTo.LastOrDefault() < targetNumber)
        {
            powerTo.Add((int)Math.Pow(baseOfPowers, power));
            power++;
        }
        if (powerTo.LastOrDefault() > targetNumber)
            powerTo.Remove(powerTo.Last());

        // An array to store a partition 
        int[] partionArray = new int[targetNumber];

        // Index of last element in a 
        // partition 
        int indexPosition = 0;

        // Initialize first partition as 
        // number itself 
        partionArray[indexPosition] = targetNumber;

        // This loop first prints current 
        // partition, then generates next 
        // partition. The loop stops when 
        // the current partition has all 1s 
        while (true)
        {

            // print current partition 
            var tmp = printArray(partionArray, indexPosition + 1);
            // Generate next partition 

            // Find the rightmost non-one value in p[]. Also, update 
            // the rem_val so that we know how much value can be accommodated 
            int remainingValue = 0;
            //if (powerTo.ToArray().Intersect(tmp).Sum() == targetNumber)
            //{
            //    Console.WriteLine("It worked!");
            //}
            //var store = powerTo.ToArray().Intersect(tmp);
            var store = tmp.Where(x => powerTo.Contains(x));

            if (store.Sum() == targetNumber)
            {
                //Console.WriteLine("nice");
                count++;
            }
            // partitionArray är inte korrekt.......................

            while (indexPosition >= 0 && partionArray[indexPosition] == 1)
            {
                remainingValue += partionArray[indexPosition];
                indexPosition--;
            }
            // if indexPosition < 0, all the values are 1 so 
            // there are no more partitions 
            if (indexPosition < 0)
                return;

            // Decrease the partionArray[indexPosition] found above 
            // and adjust the remainingValue 
            partionArray[indexPosition]--;
            remainingValue++;

            // If remainingValue is more, then the sorted 
            // order is violeted. Divide remainingValue in 
            // differnt values of size partionArray[indexPosition] and copy 
            // these values at different positions 
            // after partionArray[indexPosition] 
            while (remainingValue > partionArray[indexPosition])
            {
                partionArray[indexPosition + 1] = partionArray[indexPosition];
                remainingValue = remainingValue - partionArray[indexPosition];
                indexPosition++;
            }
            // Copy remainingValue to next position and 
            // increment position 
            partionArray[indexPosition + 1] = remainingValue;
            indexPosition++;

        }
    }

    // Driver program 
    public static void Main()
    {
        //Console.WriteLine("All Unique Partitions of 2");
        //printAllUniqueParts(2);

        //Console.WriteLine("All Unique Partitions of 3");
        //printAllUniqueParts(3);

        Console.WriteLine("All Unique Partitions of 9");
        printAllUniqueParts(75);
        Console.WriteLine(count);
        //var tmp = new List<int[]>();
        //var count = 0;
        //foreach (var item in partitionsList)
        //{
        //    if (item.Any(i => i == 3))
        //        count++;

        //    //tmp.Add(item.Where(i => i == i / 3).ToArray());
        //    //for (int i = 0; i < item.Length; i++)
        //    //{
        //    //    item[i] 
        //    //}
        //}
    }
}