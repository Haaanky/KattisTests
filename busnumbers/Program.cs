using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace busnumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfBuses = int.Parse(Console.ReadLine());
            var buses = Console.ReadLine().Split();
            var buslineNumbers = new SortedSet<int>();

            for (int i = 0; i < numberOfBuses; i++)
            {
                buslineNumbers.Add(int.Parse(buses[i]));
            }

            var tmp = new List<string>();
            for (int i = 0; i < buslineNumbers.Count; i++)
            {
                if (i != 0 && i+1 < buslineNumbers.Count && buslineNumbers.ElementAt(i) - 1 == buslineNumbers.ElementAt(i - 1) && buslineNumbers.ElementAt(i) + 1 == buslineNumbers.ElementAt(i + 1))
                    tmp.Add("-");
                else
                    tmp.Add(buslineNumbers.ElementAt(i).ToString());
            }
            var tmpString = new StringBuilder();
            for (int i = 0; i < tmp.Count; i++)
            {
                string item = tmp[i];
                //if (tmp[i] == "-")
                //    Console.Write("-");
                //else
                if (i + 1 < tmp.Count && (tmp[i] != "-" && tmp[i + 1] == "-") && tmp[i + 1] == "-" || tmp[i] == "-")
                    //Console.Write(item);
                    tmpString.Append(item);
                else
                    //Console.Write(item + " ");
                    tmpString.Append(item + " ");
            }

            tmpString.Replace("--", "-");
            tmpString.Replace("---", "-");
            tmpString.Replace("----", "-");
            tmpString.Replace("-----", "-");
            tmpString.Replace("------", "-");
            tmpString.Replace("-------", "-");
            tmpString.Replace("--------", "-");
            tmpString.Replace("---------", "-");
            tmpString.Replace("----------", "-");
            tmpString.Replace("-----------", "-");
            tmpString.Replace("------------", "-");
            tmpString.Replace("-------------", "-");
            tmpString.Replace("--------------", "-");
            tmpString.Replace("---------------", "-");
            tmpString.Replace("----------------", "-");
            tmpString.Replace("-----------------", "-");
            tmpString.Replace("------------------", "-");
            tmpString.Replace("-------------------", "-");
            tmpString.Replace("--------------------", "-");
            tmpString.Replace("---------------------", "-");
            tmpString.Replace("----------------------", "-");
            tmpString.Replace("-----------------------", "-");
            tmpString.Replace("------------------------", "-");
            tmpString.Replace("-------------------------", "-");
            tmpString.Replace("--------------------------", "-");
            tmpString.Replace("---------------------------", "-");
            Console.WriteLine(tmpString);
            //var busOutput = new SortedSet<string>();
            //var busQueue = busNumbers.ToArray();

            //for (int i = 0; i < numberOfBuses; i++)
            //{
            //    string result;
            //    for (int j = 0; j < busNumbers.Count; j++)
            //    {
            //        var tmp = new StringBuilder();
            //        if (busQueue[i] + j == busQueue[i + j])
            //            tmp.Append(busQueue[i]);
            //        else if ()
            //        {

            //            break;
            //        }
            //    }
            //    _ = busOutput.Add(result);
            //}
        }
    }
}
