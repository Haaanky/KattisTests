using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string input;
        int i = 0;
        Translator[] translatorArray = new Translator[0];
        int hiredTranslators = 0;

        while ((input = Console.ReadLine()) != null)
        {

            var split = input.Split();
            if (hiredTranslators == 0)
            {
                hiredTranslators = int.Parse(split[1]);
                if (hiredTranslators % 2 != 0)
                { Console.WriteLine("impossible"); return; }
                translatorArray = new Translator[hiredTranslators];
            }
            else
            {
                translatorArray[i] = new Translator
                {
                    ID = i,
                    FirstLanguage = int.Parse(split[0]),
                    SecondLanguage = int.Parse(split[1])
                };
                i++;
            }
        }

        var matchArr = new List<TranslatorPair>();

        for (int j = 0; j < hiredTranslators; j++)
        {
            for (int k = 0; k < hiredTranslators; k++)
            {
                if (translatorArray[j].FirstLanguage == translatorArray[k].FirstLanguage)
                {
                    matchArr.Add(new TranslatorPair { Left = translatorArray[j].ID, Right = translatorArray[k].ID });
                }
                else if (translatorArray[j].FirstLanguage == translatorArray[k].SecondLanguage)
                {
                    matchArr.Add(new TranslatorPair { Left = translatorArray[j].ID, Right = translatorArray[k].ID });
                }
                else if (translatorArray[j].SecondLanguage == translatorArray[k].SecondLanguage)
                {
                    matchArr.Add(new TranslatorPair { Left = translatorArray[j].ID, Right = translatorArray[k].ID });
                }
                else if (translatorArray[j].SecondLanguage == translatorArray[k].FirstLanguage)
                {
                    matchArr.Add(new TranslatorPair { Left = translatorArray[j].ID, Right = translatorArray[k].ID });
                }
            }
        }

        matchArr = matchArr.Where(x => x.Left != x.Right).ToList();
        matchArr.TrimExcess();

        var tmpListMatches = matchArr.ToList();
        tmpListMatches.TrimExcess();
        var tmpArray = new TranslatorPair[hiredTranslators / 2];
        var index = 0;
        var rnd = new Random();
        var triedCombos = new List<TranslatorPair>();

        for (int l = 0; tmpArray.Any(x => x == null) /*&& l < tmpArray.Length*/; l++)
        {
            if (tmpListMatches.Count == 0)
            {
                tmpListMatches = matchArr.ToList();
                for (int m = 1; m < tmpArray.Length; m++)
                {
                    tmpArray[m] = null;
                }

                tmpListMatches.RemoveAll(x => x.Left == tmpArray[0].Left || x.Right == tmpArray[0].Right || x.Left == tmpArray[0].Right || x.Right == tmpArray[0].Left);
                tmpListMatches = tmpListMatches.Except(triedCombos).ToList();
                l = 1;

                if (tmpListMatches.Count == 0)
                {
                    tmpListMatches = matchArr.ToList();
                    triedCombos.Clear();
                    l = 0;
                    index++;
                }
            }
            if (l == 0)
                tmpArray[l] = tmpListMatches[index];
            else
            {
                tmpArray[l] = tmpListMatches[0];
                //tmpArray[l] = tmpListMatches[rnd.Next(0, tmpListMatches.Count)];
                triedCombos.Add(tmpArray[l]);
            }
            tmpListMatches.RemoveAll(x => x.Left == tmpArray[l].Left || x.Right == tmpArray[l].Right || x.Left == tmpArray[l].Right || x.Right == tmpArray[l].Left);
        }

        for (int i1 = 0; i1 < tmpArray.Length; i1++)
        {
            throw new Exception();
            TranslatorPair item = tmpArray[i1];
            if (item != null)
                Console.WriteLine($"{item.Left} {item.Right}");
        }
    }

}

internal class TranslatorPair
{
    public int Left { get; set; }
    public int Right { get; set; }
}

class Translator
{
    public int ID { get; set; }
    public int FirstLanguage { get; set; }
    public int SecondLanguage { get; set; }
}