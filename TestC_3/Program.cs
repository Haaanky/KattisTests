using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string input;
        int i = 0;
        int translatorIndex = 0;
        Translator[] translatorArray = new Translator[0];
        int languagesSpoken = 0;
        int hiredTranslators = 0;

        while ((input = Console.ReadLine()) != null)
        {
            if (hiredTranslators % 2 != 0)
            { Console.WriteLine("impossible"); return; }

            var split = input.Split();
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

        //var tmpListMatches = new List<string>();
        var tmpListMatches = matchArr.ToList();
        var tmpArray = new string[hiredTranslators / 2];
        var index = 0;
        var rnd = new Random();
        var triedCombos = new List<string>();

        //while (tmpArray.Any(x => x == null))
        //{
        //    tmpListMatches = matchArr.ToList();
        triedCombos = matchArr.ToList();
        //tmpListMatches = tmpListMatches.Except(triedCombos).ToList();

        for (int j = 0; tmpArray.Any(x => x == null); j++)
        {
            if (tmpListMatches.Count == 0)
            {
                tmpListMatches = matchArr.ToList();
                for (int k = 1; k < tmpArray.Length; k++)
                {
                    tmpArray[k] = null;
                }

                tmpListMatches.RemoveAll(x => x.Contains(tmpArray[0][0]) || x.Contains(tmpArray[0][1]));
                tmpListMatches = tmpListMatches.Except(triedCombos).ToList();
                j = 1;

                if (tmpListMatches.Count == 0)
                {
                    tmpListMatches = matchArr.ToList();
                    j = 0;
                    triedCombos.RemoveAll(x => true);
                }
            }
            if (j == 0)
                tmpArray[j] = tmpListMatches[index++];
            else
            {
                tmpArray[j] = tmpListMatches[0];
                //tmpArray[j] = tmpListMatches[rnd.Next(0, tmpListMatches.Count)];
                triedCombos.Add(tmpArray[j]);
            }
            tmpListMatches.RemoveAll(x => x.Contains(tmpArray[j][0]) || x.Contains(tmpArray[j][1]));
        }
        //}
        foreach (var item in tmpArray)
        {
            Console.WriteLine($"{item[0]} {item[1]}");
        }
    }
}

class Translator
{
    public int ID { get; set; }
    public int FirstLanguage { get; set; }
    public int SecondLanguage { get; set; }
}