using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookingaroom
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split();
            var numberOfRooms = int.Parse(firstLine[0]);
            var numberOfBookedRooms = int.Parse(firstLine[1]);

            var hashSet = new HashSet<int>();

            for (int i = 1; i <= numberOfRooms; i++)
            {
                hashSet.Add(i);
            }

            for (int i = 0; i < numberOfBookedRooms; i++)
            {
                hashSet.Remove(int.Parse(Console.ReadLine()));
            }

            if (numberOfRooms == numberOfBookedRooms)
            {
                Console.WriteLine("too late");
                return;
            }

            Console.WriteLine(hashSet.First());
        }
    }
}
