using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string input;
        int i = 0;
        Translator[] translators = new Translator[0];
        int hiredTranslators = 0;
        int languagesSpoken = 0;

        while ((input = Console.ReadLine()) != null)
        {

            var split = input.Split();
            if (hiredTranslators == 0)
            {
                languagesSpoken = int.Parse(split[0]);
                hiredTranslators = int.Parse(split[1]);
                if (hiredTranslators % 2 != 0)
                { Console.WriteLine("impossible"); return; }
                translators = new Translator[hiredTranslators];
            }
            else
            {
                translators[i] = new Translator
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
            //if (!(matchArr[j].Left == translatorArray[j].ID && matchArr[j].Right == translatorArray[j].ID))
            for (int k = 0; k < hiredTranslators; k++)
            {
                //matchArr.Add(new TranslatorPair { Left = translators[j].ID, Right = translators[k].ID });
                //if (!matchArr.Any(x => x.Left + x.Right == matchArr[j].Left + matchArr[k].Right))
                if (translators[j].FirstLanguage == translators[k].FirstLanguage)
                {
                    matchArr.Add(new TranslatorPair { Left = translators[j].ID, Right = translators[k].ID });
                }
                else if (translators[j].FirstLanguage == translators[k].SecondLanguage)
                {
                    matchArr.Add(new TranslatorPair { Left = translators[j].ID, Right = translators[k].ID });
                }
                else if (translators[j].SecondLanguage == translators[k].SecondLanguage)
                {
                    matchArr.Add(new TranslatorPair { Left = translators[j].ID, Right = translators[k].ID });
                }
                else if (translators[j].SecondLanguage == translators[k].FirstLanguage)
                {
                    matchArr.Add(new TranslatorPair { Left = translators[j].ID, Right = translators[k].ID });
                }
            }
        }

        matchArr = matchArr.Where(x => x.Left != x.Right).ToList();
        //var tmpListMatches = new List<TranslatorPair>();
        for (int z = 0; z < matchArr.Count; z++)
        {
            //if (matchArr.Any(x => matchArr[z].Left == x.Right && matchArr[z].Right == x.Left))
            //    matchArr.Remove(matchArr[z]);
            //tmpListMatches.Add(matchArr.First(x => x.Left + x.Right == matchArr[z].Left + matchArr[z].Right));
            for (int x = 0; x < matchArr.Count; x++)
            {
                if (matchArr[z].Left == matchArr[x].Right && matchArr[z].Right == matchArr[x].Left)
                    matchArr.Remove(matchArr[z]);
                //if (matchArr[z].Left + matchArr[z].Right == matchArr[x].Left + matchArr[x].Right)
                //    tmpListMatches.Add(matchArr[z]);
            }
            //tmpListMatches.Add(matchArr.First(x => x.Left + x.Left == matchArr[z].Left + matchArr[z].Right));
            //tmpListMatches = matchArr.Where(x => x.Left + x.Right != matchArr[z].Left + matchArr[z].Right).ToList();
        }
        //if (matchArr.Count > 4000)
        //    Console.WriteLine("impossible");

        //var tmpListMatches = new Queue<TranslatorPair>(matchArr);
        var tmpListMatches = matchArr.ToList();
        if (matchArr.Count == 0)
            throw new Exception();
        var tmpArray = new TranslatorPair[hiredTranslators / 2];
        var index = 0;
        var rnd = new Random();
        var triedCombos = new List<TranslatorPair>();

        //for (int l = 0; tmpArray.Any(x => x == null) /*&& l < tmpArray.Length*/; l++)
        //{
        //    if (tmpListMatches.Count == 0)
        //    {
        //        tmpListMatches = matchArr.ToList();
        //        for (int m = 1; m < tmpArray.Length; m++)
        //        {
        //            tmpArray[m] = null;
        //        }

        //        tmpListMatches.RemoveAll(x => x.Left == tmpArray[0].Left || x.Right == tmpArray[0].Right || x.Left == tmpArray[0].Right || x.Right == tmpArray[0].Left);
        //        tmpListMatches = tmpListMatches.Except(triedCombos).ToList();
        //        l = 1;

        //        if (tmpListMatches.Count == 0)
        //        {
        //            tmpListMatches = matchArr.ToList();
        //            triedCombos.Clear();
        //            l = 0;
        //            index++;
        //        }
        //    }
        //    if (l == 0)
        //        tmpArray[l] = tmpListMatches[index];
        //    else
        //    {
        //        tmpArray[l] = tmpListMatches[0];
        //        //tmpArray[l] = tmpListMatches[rnd.Next(0, tmpListMatches.Count)];
        //        triedCombos.Add(tmpArray[l]);
        //    }
        //    tmpListMatches.RemoveAll(x => x.Left == tmpArray[l].Left || x.Right == tmpArray[l].Right || x.Left == tmpArray[l].Right || x.Right == tmpArray[l].Left);
        //}

        //var testArr = matchArr.GroupBy(x => x.Right);
        //var testArr2 = matchArr.GroupBy(x => x.Left).OrderByDescending(x => x.Key).ToList();
        var tmpTest = new TranslatorPair();
        //matchArr.OrderByDescending(x => x.Right);

        for (int l = 0; l < tmpArray.Length; l++)
        {
            if (tmpListMatches.Count == 0)
            {
                tmpListMatches = matchArr.ToList();
                l = 0;
                index++;
                if (index >= tmpListMatches.Count)
                    index = 0;
                //if (languagesSpoken > 99)
                //    throw new Exception();
            }
            if (l == 0)
                //try
                //{
                //    tmpArray[0] = tmpTest = tmpListMatches[index];
                //}
                //catch (Exception)
                //{
                //    if (index > tmpListMatches.Count - 1)
                //        Console.WriteLine("impossible");
                //    if (tmpArray[0] == null)
                //        throw new Exception();
                //    Environment.Exit(0);
                //}
                    tmpArray[0] = tmpTest = tmpListMatches[index];
            else
                //tmpArray[l] = tmpTest = tmpListMatches[0];
                tmpArray[l] = tmpTest = tmpListMatches[rnd.Next(0, tmpListMatches.Count)];

            tmpListMatches = tmpListMatches.FindAll(x => x.Left != tmpTest.Left && x.Left != tmpTest.Right && x.Right != tmpTest.Left && x.Right != tmpTest.Right);
            tmpListMatches = tmpListMatches.FindAll(x => x.Left != tmpTest.Left && x.Left != tmpTest.Right && x.Right != tmpTest.Left && x.Right != tmpTest.Right);
        }

        for (int i1 = 0; i1 < tmpArray.Length; i1++)
        {
            var item = tmpArray[i1];
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