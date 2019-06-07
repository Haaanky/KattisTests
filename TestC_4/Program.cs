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
            for (int k = 0; k < hiredTranslators; k++)
            {
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
        for (int z = 0; z < matchArr.Count; z++)
        {
            for (int x = 0; x < matchArr.Count; x++)
            {
                if (matchArr[z].Left == matchArr[x].Right && matchArr[z].Right == matchArr[x].Left)
                    matchArr.Remove(matchArr[z]);
            }
        }
        var tmpListMatches = matchArr.ToList();
        if (matchArr.Count == 0)
            throw new Exception();
        var tmpArray = new TranslatorPair[hiredTranslators / 2];
        var index = 0;
        var rnd = new Random();
        var triedCombos = new List<TranslatorPair>();

        var tmpTest = new TranslatorPair();
        var result = new List<TranslatorPair>();
        var tmpBranch = new List<List<TranslatorPair>>();

        for (int l = 0; result.Count != hiredTranslators / 2; l++)
        {
            //if (l >= tmpArray.Length)
            //{
            //    tmpListMatches = matchArr.ToList();
            //    l = 0;
            //    index++;
            //}
            //if (tmpListMatches.Count == 0)
            //{
            //    l = 0;
            //    index++;
            //}
            //if (l == 0)
            //        tmpArray[0] = tmpTest = tmpListMatches[index];
            //else
            //    tmpArray[l] = tmpTest = tmpListMatches[rnd.Next(0, tmpListMatches.Count)];

            //tmpListMatches = tmpListMatches.FindAll(x => x.Left != tmpTest.Left && x.Left != tmpTest.Right && x.Right != tmpTest.Left && x.Right != tmpTest.Right);
            //IGraph myGraph = (IGraph)matchArr.ToList();
            //TranslatorPair start = matchArr[index];
            //var result = myGraph.DepthFirstTraversal(start)
            //           .Where(x => x.Left != tmpArray[l].Left && x.Left != tmpArray[l].Right && x.Right != tmpArray[l].Left && x.Right != tmpArray[l].Right)
            //           .FirstOrDefault();
            //tmpArray[l] = result;
            //TranslatorPair result = myGraph.DepthFirstTraversal(start)
            //                       .Where(x => x.Left != start.Left && x.Left != start.Right && x.Right != start.Left && x.Right != start.Right)
            //                       .FirstOrDefault();
            result = TraverseDepthFirst(matchArr[l], GetPairs).ToList();
        }

        foreach (var item in result)
        {
            Console.WriteLine($"{item.Left} {item.Right}");
        }

        //for (int i1 = 0; i1 < tmpArray.Length; i1++)
        //{
        //    var item = tmpArray[i1];
        //    if (item != null)
        //        Console.WriteLine($"{item.Left} {item.Right}");
        //}
        IEnumerable<TranslatorPair> GetPairs(TranslatorPair arg, int level)
        {
            if (level == 0 && tmpBranch.Count != 0)
                return tmpBranch[level].First(x => x.Left != arg.Left && x.Left != arg.Right && x.Right != arg.Left && x.Right != arg.Right);
            if (level == 0)
                tmpBranch.Add(tmpListMatches.First(x => x.Left != arg.Left && x.Left != arg.Right && x.Right != arg.Left && x.Right != arg.Right));
            else
                tmpBranch.Add(tmpBranch[level - 1].First(x => x.Left != arg.Left && x.Left != arg.Right && x.Right != arg.Left && x.Right != arg.Right));
            return tmpBranch[level];
            //tmpListMatches = tmpListMatches.FindAll(x => x.Left != arg.Left && x.Left != arg.Right && x.Right != arg.Left && x.Right != arg.Right);
            //return tmpListMatches.FindAll(x => x.Left != arg.Left && x.Left != arg.Right && x.Right != arg.Left && x.Right != arg.Right);
            //return tmpListMatches;
        }
    }


    /// <summary>
    /// Traverses a tree in a depth-first fashion, starting at a root node
    /// and using a user-defined function to get the children at each node
    /// of the tree.
    /// </summary>
    /// <typeparam name="T">The tree node type.</typeparam>
    /// <param name="root">The root of the tree to traverse.</param>
    /// <param name="childrenSelector">
    /// The function that produces the children of each element.</param>
    /// <returns>A sequence containing the traversed values.</returns>
    /// <remarks>
    /// <para>
    /// The tree is not checked for loops. If the resulting sequence needs
    /// to be finite then it is the responsibility of
    /// <paramref name="childrenSelector"/> to ensure that loops are not
    /// produced.</para>
    /// <para>
    /// This function defers traversal until needed and streams the
    /// results.</para>
    /// </remarks>
    public static IEnumerable<T> TraverseDepthFirst<T>(T root, Func<T, int, IEnumerable<T>> childrenSelector)
    {
        if (childrenSelector == null) throw new ArgumentNullException(nameof(childrenSelector));
        var level = 0;
        return _(); IEnumerable<T> _()
        {
            var stack = new Stack<T>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                var current = stack.Pop();
                yield return current;
                // because a stack pops the elements out in LIFO order, we need to push them in reverse
                // if we want to traverse the returned list in the same order as was returned to us
                var children = childrenSelector(current, level);
                foreach (var child in children.Reverse())
                    stack.Push(child);
                if (children.Count() != 0)
                {
                    level++;
                    yield return default;
                }
                else
                    level = 0;
            }
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

internal interface IGraph
{
    IEnumerable<TranslatorPair> GetNeighbours(TranslatorPair v);
}

public class Vertex
{
}

static class Extensions
{
    public static IEnumerable<TranslatorPair> DepthFirstTraversal(
        this IGraph graph,
        TranslatorPair start)
    {
        var visited = new HashSet<TranslatorPair>();
        var stack = new Stack<TranslatorPair>();

        stack.Push(start);

        while (stack.Count != 0)
        {
            var current = stack.Pop();

            if (!visited.Add(current))
                continue;

            yield return current;

            var neighbours = graph.GetNeighbours(current)
                                  .Where(n => !visited.Contains(n));

            // If you don't care about the left-to-right order, remove the Reverse
            foreach (var neighbour in neighbours.Reverse())
                stack.Push(neighbour);
        }
    }
}
