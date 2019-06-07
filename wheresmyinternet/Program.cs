using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wheresmyinternet
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split();
            var numberOfHouses = int.Parse(firstLine[0]);
            var numberOfCables = int.Parse(firstLine[1]);
            var housePairs = new Queue<HousePair>();

            for (int i = 0; i < numberOfCables; i++)
            {
                var input = Console.ReadLine().Split();
                housePairs.Enqueue(new HousePair { FirstHouse = int.Parse(input[0]), SecondHouse = int.Parse(input[1]) });
            }
            IEnumerable<int> uniques;
            // If no house is 1, none is connected
            if (!housePairs.Any(x => x.FirstHouse == 1 || x.SecondHouse == 1))
            {
                //var firstHouses = new int[housePairs.Count];
                //var secondHouses = new int[housePairs.Count];
                //var housePairsArray = housePairs.ToArray();
                //for (int i = 0; i < housePairs.Count; i++)
                //{
                //    firstHouses[i] = housePairsArray[i].FirstHouse;
                //    secondHouses[i] = housePairsArray[i].SecondHouse;
                //}

                //uniques = firstHouses.Intersect(secondHouses).OrderBy(x => x);
                //foreach (var item in uniques)
                //{
                //    Console.WriteLine(item);
                //}

                var remainingHousesSet = new SortedSet<int>();
                foreach (var item in housePairs)
                {
                    remainingHousesSet.Add(item.SecondHouse);
                    remainingHousesSet.Add(item.FirstHouse);
                }

                foreach (var item in remainingHousesSet.Distinct())
                {
                    Console.WriteLine(item);
                }
                return;
            }

            for (int i = 0; i < numberOfCables; i++)
            {
                var housePair = housePairs.Dequeue();
                if (housePairs.Count == 0)
                {
                    if (numberOfCables > 1)
                        throw new Exception();
                    Console.WriteLine("Connected");
                    return;
                }

                //housePair(a || b) == housePairs(a || b )
                //    continue;
                if (housePairs.Any(a => a.FirstHouse == housePair.FirstHouse ||
                a.FirstHouse == housePair.SecondHouse ||
                a.SecondHouse == housePair.FirstHouse ||
                a.SecondHouse == housePair.SecondHouse))
                    continue;
                else
                    break;
                //if (housePairs.Any(a => a.FirstHouse == housePair.FirstHouse))
                //    continue;
                //else if (housePairs.Any(a => a.FirstHouse == housePair.SecondHouse))
                //    continue;
                //else if (housePairs.Any(a => a.SecondHouse == housePair.FirstHouse))
                //    continue;
                //else if (housePairs.Any(a => a.SecondHouse == housePair.SecondHouse))
                //    continue;
                //else
                //    break;
                //if (housePairs.Any(x => x.FirstHouse != housePair.FirstHouse && x.FirstHouse != housePair.SecondHouse))
                //    if (housePairs.Any(x => x.SecondHouse != housePair.SecondHouse && x.SecondHouse != housePair.FirstHouse))
                //        break;
                //if (housePair.SecondHouse != houseParis.Peek().SecondHouse))
                //    if (housePair.FirstHouse != housePairs.Peek().SecondHouse)
                //        break;
            }
            var remainingHouses = new SortedSet<int>();
            foreach (var item in housePairs)
            {
                remainingHouses.Add(item.SecondHouse);
                remainingHouses.Add(item.FirstHouse);
            }

            foreach (var item in remainingHouses.Distinct())
            {
                Console.WriteLine(item);
            }
        }
    }

    internal class HousePair
    {
        public int FirstHouse { get; set; }
        public int SecondHouse { get; set; }

        public override string ToString()
        {
            return $"{FirstHouse}, {SecondHouse}";
        }
    }
}
