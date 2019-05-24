using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string line;
        int i = 0;
        int translatorIndex = 0;
        Translator[] translatorArray = new Translator[0];
        int languagesSpoken = 0;
        int hiredTranslators = 0;

        while ((line = Console.ReadLine()) != string.Empty)
        {
            if (hiredTranslators % 2 != 0)
            { Console.WriteLine("impossible"); return; }

            var split = line.Split();
            if (i == 0)
            {
                languagesSpoken = int.Parse(split[0]);
                hiredTranslators = int.Parse(split[1]);
                translatorArray = new Translator[hiredTranslators];
            }
            else
            {
                translatorArray[translatorIndex] = new Translator
                {
                    ID = translatorIndex,
                    FirstLanguage = int.Parse(split[0]),
                    SecondLanguage = int.Parse(split[1])
                };
                translatorIndex++;
            }
            i++;
        }

        var matchArr = new List<string>();
        string numbersToContain = string.Empty;

        for (int k = 0; k < languagesSpoken; k++)
        {
            numbersToContain += k.ToString();
        }
        for (int j = 0; j <= languagesSpoken; j++)
        {
            for (int k = 1; k <= languagesSpoken; k++)
            {
                if (translatorArray[j].FirstLanguage == translatorArray[k].FirstLanguage)
                {
                    matchArr.Add(translatorArray[j].ID.ToString() + translatorArray[k].ID.ToString());
                }
                if (translatorArray[j].FirstLanguage == translatorArray[k].SecondLanguage)
                {
                    matchArr.Add(translatorArray[j].ID.ToString() + translatorArray[k].ID.ToString());
                }
                if (translatorArray[j].SecondLanguage == translatorArray[k].SecondLanguage)
                {
                    matchArr.Add(translatorArray[j].ID.ToString() + translatorArray[k].ID.ToString());
                }
                if (translatorArray[j].SecondLanguage == translatorArray[k].FirstLanguage)
                {
                    matchArr.Add(translatorArray[j].ID.ToString() + translatorArray[k].ID.ToString());
                }
            }
        }

        matchArr = matchArr.Distinct().ToList().Where(x => x[0] != x[1]).ToList();

        var tmpArray = new string[hiredTranslators / 2];
        var tmpListMatches = new List<string>();
        var index = 0;
        while (tmpArray.Any(x => x == null))
        {
            tmpListMatches = matchArr.ToList();
            for (int j = 0; tmpArray.Any(x => x == null); j++)
            {
                tmpArray[j] = tmpListMatches[index];
                tmpListMatches.RemoveAll(x => x.Contains(tmpArray[j][0]) || x.Contains(tmpArray[j][1]));
                if (tmpListMatches.Count == 0)
                    break;
            }

            if (tmpArray.Any(x => x == null))
            {
                index++;
            }
        }
        foreach (var item in tmpArray)
        {
            Console.WriteLine($"{item[0]} {item[1]}");
        }
        Console.WriteLine();
    }
}

class Translator
{
    public int ID { get; set; }
    public int FirstLanguage { get; set; }
    public int SecondLanguage { get; set; }
}