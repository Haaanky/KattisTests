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
        //int languagesSpoken = 0;
        int hiredTranslators = 0;

        while ((input = Console.ReadLine()) != null)
        {

            var split = input.Split();
            if (hiredTranslators == 0)
            {
                //languagesSpoken = int.Parse(split[0]);
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
                //if (!matchArr.Contains(translatorArray[k].FirstLanguage.ToString() + translatorArray[k].SecondLanguage.ToString()) || !matchArr.Contains(translatorArray[k].SecondLanguage.ToString() + translatorArray[k].FirstLanguage.ToString()))
                if (!matchArr.Contains(new TranslatorPair { Left = translatorArray[j], Right = translatorArray[k] }))
                {
                    if (translatorArray[j].FirstLanguage == translatorArray[k].FirstLanguage)
                    {
                        matchArr.Add(new TranslatorPair { Left = translatorArray[j], Right = translatorArray[k] });
                        //matchArr.Add(translatorArray[j].ID + translatorArray[k].ID);
                    }
                    else
                if (translatorArray[j].FirstLanguage == translatorArray[k].SecondLanguage)
                    {
                        matchArr.Add(new TranslatorPair { Left = translatorArray[j], Right = translatorArray[k] });
                        //matchArr.Add(translatorArray[j].ID + translatorArray[k].ID);
                    }
                    else
                if (translatorArray[j].SecondLanguage == translatorArray[k].SecondLanguage)
                    {
                        matchArr.Add(new TranslatorPair { Left = translatorArray[j], Right = translatorArray[k] });
                        //matchArr.Add(translatorArray[j].ID + translatorArray[k].ID);
                    }
                    else
                if (translatorArray[j].SecondLanguage == translatorArray[k].FirstLanguage)
                    {
                        matchArr.Add(new TranslatorPair { Left = translatorArray[j], Right = translatorArray[k] });
                        //matchArr.Add(translatorArray[j].ID + translatorArray[k].ID);
                    }
                }
            }
        }

        matchArr = matchArr.Where(x => x.Left.ID != x.Right.ID).ToList();

        var tmpListMatches = matchArr.ToList();
        var tmpArray = new TranslatorPair[hiredTranslators / 2];
        var index = 0;
        var rnd = new Random();
        var triedCombos = new List<TranslatorPair>();
        int l = 0;

        for (l = 0; tmpArray.Any(x => x == null) && l < tmpArray.Length; l++)
        {
            if (tmpListMatches.Count == 0)
            {
                tmpListMatches = matchArr.ToList();
                for (int m = 1; m < tmpArray.Length; m++)
                {
                    tmpArray[m] = null;
                }

                tmpListMatches.RemoveAll(x => x.Left.ID.Equals(tmpArray[0].Left.ID) || x.Right.ID.Equals(tmpArray[0].Right.ID) || x.Left.ID.Equals(tmpArray[0].Right.ID) || x.Right.ID.Equals(tmpArray[0].Left.ID));
                tmpListMatches = tmpListMatches.Except(triedCombos).ToList();
                l = 1;

                if (tmpListMatches.Count == 0)
                {
                    tmpListMatches = matchArr.ToList();
                    triedCombos.RemoveAll(x => true);
                    l = 0;
                    index++;
                    if (index >= matchArr.Count)
                        break;
                }
            }
            if (l == 0)
                tmpArray[l] = tmpListMatches[index];
            else
            {
                //tmpArray[j] = tmpListMatches[0];
                tmpArray[l] = tmpListMatches[rnd.Next(0, tmpListMatches.Count)];
                triedCombos.Add(tmpArray[l]);
            }
            var test2 = tmpListMatches.RemoveAll(x => x.Left.ID == tmpArray[l].Left.ID || x.Right.ID == tmpArray[l].Right.ID || x.Left.ID == tmpArray[l].Right.ID || x.Right.ID == tmpArray[l].Left.ID);
        }

        foreach (var item in tmpArray)
        {
            if (item != null)
                Console.WriteLine($"{item.Left.ID} {item.Right.ID}");
        }
    }

}

internal class TranslatorPair
{
    public Translator Left { get; set; }
    public Translator Right { get; set; }
}

class Translator
{
    public int ID { get; set; }
    public int FirstLanguage { get; set; }
    public int SecondLanguage { get; set; }
}