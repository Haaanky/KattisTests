using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backspace
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            StringBuilder stringBuilder = new StringBuilder(input, input.Length);

            //for (int i = 0; input.Contains('<'); i++)
            //{
            //    if (stringBuilder[i] == '<')
            //    {
            //        stringBuilder = stringBuilder.Remove(--i, 2);
            //        input = stringBuilder.ToString();
            //    }
            //}
            //for (int i = input.IndexOf('<'); input.Contains('<'); i = input.IndexOf('<'))
            //{
            //    if (input[i] == '<')
            //    {
            //        input = input.Remove(--i, 2);
            //    }
            //}

            while (input.Contains('<'))
            {
                //input = input.Remove(input.IndexOf('<') - 1, 2);
                stringBuilder = stringBuilder.Remove(input.IndexOf('<') - 1, 2);
                input = stringBuilder.ToString();
            }
            Console.WriteLine(input);
        }
    }
}
