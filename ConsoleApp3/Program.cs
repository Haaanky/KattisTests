// C# program to generate all unique 
// partitions of an integer 
using System;
using System.Collections.Generic;
using System.Linq;

class GFG
{
    static List<int[]> partitionsList = new List<int[]>();

    // Function to print an array p[] 
    // of size n 
    static void printArray(int[] p, int n)
    {

        for (int i = 0; i < n; i++)
            Console.Write(p[i] + " ");

        Console.WriteLine();
    }
    static void printArray(List<int> p, int n)
    {

        for (int i = 0; i < n; i++)
            Console.Write(p[i] + " ");

        Console.WriteLine();
    }

    // Function to generate all unique partitions of an integer 
    static void printAllUniqueParts(int targetNumber)
    {
        var baseOfPowers = 3;
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
        //int[] partionArray = new int[targetNumber];

        List<int> partionArray = new List<int>();

        for (int i = 0; i < targetNumber; i++)
        {
            partionArray.Add(0);
        }

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
            printArray(partionArray, indexPosition + 1);
            partitionsList.Add(partionArray.ToArray());
            // Generate next partition 

            // Find the rightmost non-one value in p[]. Also, update 
            // the rem_val so that we know how much value can be accommodated 
            int remainingValue = 0;
            if (powerTo.ToArray().Intersect(partionArray).Sum() == targetNumber)
            {
                Console.WriteLine("It worked!");
            }
            // partitionArray är inte korrekt.......................

            while (indexPosition >= 0 && partionArray[indexPosition] == 1)
            {
                remainingValue += partionArray[indexPosition];
                indexPosition--;
            }
            if (powerTo.ToArray().Intersect(partionArray).Sum() == targetNumber)
            {
                Console.WriteLine("It worked!2");
            }
            // if indexPosition < 0, all the values are 1 so 
            // there are no more partitions 
            if (indexPosition < 0)
                return;

            // Decrease the partionArray[indexPosition] found above 
            // and adjust the remainingValue 
            partionArray[indexPosition]--;
            remainingValue++;
            if (powerTo.ToArray().Intersect(partionArray).Sum() == targetNumber)
            {
                Console.WriteLine("It worked!3");
            }
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
            if (powerTo.ToArray().Intersect(partionArray).Sum() == targetNumber)
            {
                Console.WriteLine("It worked!4");
            }
            // Copy remainingValue to next position and 
            // increment position 
            partionArray[indexPosition + 1] = remainingValue;
            indexPosition++;
            if (powerTo.ToArray().Intersect(partionArray).Sum() == targetNumber)
            {
                Console.WriteLine("It worked!5");
            }
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
        printAllUniqueParts(9);
        var tmp = new List<int[]>();
        var count = 0;
        foreach (var item in partitionsList)
        {
            if (item.Any(i => i == 3))
                count++;

            //tmp.Add(item.Where(i => i == i / 3).ToArray());
            //for (int i = 0; i < item.Length; i++)
            //{
            //    item[i] 
            //}
        }
    }
}

// This code is contributed by Sam007. 
