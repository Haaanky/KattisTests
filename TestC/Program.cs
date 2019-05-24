using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        var firstLangArr = translatorArray.GroupBy(t => t.FirstLanguage).ToArray();
        var secondLangArr = translatorArray.GroupBy(t => t.SecondLanguage).ToArray();
        var distLangArr = firstLangArr.Concat(secondLangArr);
        //var matchArr = new List<int[]>();
        var matchArr = new List<string>();
        string numbersToContain = string.Empty;
        var indexIncrease = 0;

        for (int k = 0; k < languagesSpoken; k++)
        {
            numbersToContain += k.ToString();
        }
        for (int j = 0; (matchArr.Count != hiredTranslators / 2) && !matchArr.Contains(numbersToContain); j++)
        {
            for (int k = 1; k <= languagesSpoken; k++)
            {
                //if (translatorArray[j].FirstLanguage == translatorArray[j + 1].FirstLanguage)
                //    matchArr.Add(new int[] { translatorArray[j].ID, translatorArray[j + 1].ID });
                //else if(translatorArray[j].FirstLanguage == translatorArray[j + 1].SecondLanguage)
                //    matchArr.Add(new int[] { translatorArray[j].ID, translatorArray[j + 1].ID });
                //else if (translatorArray[j].SecondLanguage == translatorArray[j + 1].SecondLanguage)
                //    matchArr.Add(new int[] { translatorArray[j].ID, translatorArray[j + 1].ID });

                //indexIncrease = j + 1;
                //if (indexIncrease >= translatorArray.Length - 1)
                //    indexIncrease = 0;
                //if (translatorArray[j].FirstLanguage != translatorArray[indexIncrease].FirstLanguage)
                //    if (translatorArray[j].FirstLanguage != translatorArray[indexIncrease].SecondLanguage)
                //        if (translatorArray[j].SecondLanguage != translatorArray[indexIncrease].SecondLanguage)
                //            continue;
                //        else
                //        {
                //            matchArr.Add(new int[] { translatorArray[j].ID, translatorArray[indexIncrease].ID });
                //            j++;
                //        }
                //    else
                //    {
                //        matchArr.Add(new int[] { translatorArray[j].ID, translatorArray[indexIncrease].ID });
                //        j++;
                //    }
                //else
                //{
                //    matchArr.Add(new int[] { translatorArray[j].ID, translatorArray[indexIncrease].ID });
                //    j++;
                //}

                indexIncrease = k;
                //if (indexIncrease >= translatorArray.Length - 1)
                //    indexIncrease = 0;
                if (translatorArray[j].FirstLanguage != translatorArray[indexIncrease].FirstLanguage)
                    if (translatorArray[j].FirstLanguage != translatorArray[indexIncrease].SecondLanguage)
                        if (translatorArray[j].SecondLanguage != translatorArray[indexIncrease].SecondLanguage)
                            if (translatorArray[j].SecondLanguage != translatorArray[indexIncrease].FirstLanguage)
                                continue;
                            else
                            {
                                matchArr.Add(translatorArray[j].ID.ToString() + translatorArray[indexIncrease].ID.ToString());
                                //numbersToContain = numbersToContain.Remove(translatorArray[j].SecondLanguage, 1);
                                //j++;
                            }
                        else
                        {
                            matchArr.Add(translatorArray[j].ID.ToString() + translatorArray[indexIncrease].ID.ToString());
                            //numbersToContain = numbersToContain.Remove(translatorArray[j].FirstLanguage, 1);
                            //j++;
                        }
                    else
                    {
                        matchArr.Add(translatorArray[j].ID.ToString() + translatorArray[indexIncrease].ID.ToString());
                        //numbersToContain = numbersToContain.Remove(translatorArray[j].FirstLanguage, 1);
                        //j++;
                    }
                else
                {
                    matchArr.Add(translatorArray[j].ID.ToString() + translatorArray[indexIncrease].ID.ToString());
                    //numbersToContain = numbersToContain.Remove(translatorArray[j].FirstLanguage, 1);
                    //j++;
                }
            }

            //matchArr = matchArr.Contains(numbersToContain);

        }


        foreach (var item in matchArr)
        {
            Console.WriteLine($"{item} ");
        }
        Console.WriteLine();
        //foreach (var translators in firstLangArr)
        //{
        //    foreach (var item in translators)
        //    {
        //        Console.Write(item.ID);
        //    }
        //    Console.WriteLine();
        //    //Console.WriteLine(item.Select(t => t.ID).Single());
        //}
        //foreach (var translators in secondLangArr)
        //{
        //    foreach (var item in translators)
        //    {
        //        Console.Write(item.ID);
        //    }
        //    Console.WriteLine();
        //    //Console.WriteLine(item.Select(t => t.ID).Single());
        //}
        //var result = translatorArray.Select(t => new { t.FirstLanguage, t.SecondLanguage }).Distinct();

        //foreach (var item in result)
        //{
        //    Console.WriteLine(item);
        //}
    }
}

internal class Translator
{
    public int ID { get; set; }
    public int FirstLanguage { get; set; }
    public int SecondLanguage { get; set; }
}