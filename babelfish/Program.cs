using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babelfish
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, string>();

            string firstInput;
            while ((firstInput = Console.ReadLine()) != string.Empty)
            {
                var englishWord = firstInput.Split()[0];
                var foreignWord = firstInput.Split()[1];

                dictionary.Add(foreignWord, englishWord);
            }

            string secondInput;
            while ((secondInput = Console.ReadLine()) != null)
            {
                Console.WriteLine(dictionary.ContainsKey(secondInput) ? dictionary[secondInput] : "eh");
            }
        }
    }
}
