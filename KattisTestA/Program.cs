using System;

class Program
{
    static void Main(string[] args)
    {
        string line;
        int i = 0;
        while ((line = Console.ReadLine()) != null)
        {
            string[] split = line.Split(' ');
            int startDayEarth = int.Parse(split[0]);
            int startDayMars = int.Parse(split[1]);
            int daysPast = 0;
            for (int e = startDayEarth, m = startDayMars; !(e == 0 && m == 0);)
            {
                daysPast++;
                e++;
                m++;
                if (e == 365)
                    e = 0;
                if (m == 687)
                    m = 0;
            }
            i++;
            Console.WriteLine($"Case {i}: {daysPast}");
        }
    }
}