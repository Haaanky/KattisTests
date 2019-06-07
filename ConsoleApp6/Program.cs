using System;
using System.Collections.Generic;

internal class Edge
{
    internal int u, v, index;
    public Edge(int x, int y, int label)
    {
        index = label;
        u = (x < y) ? x : y;
        v = (x < y) ? y : x;
    }

    public virtual int other(int x)
    {
        return x == u ? v : u;
    }
}

public class translatorsdinner
{

    public static IList<IDictionary<int, int>> getEdges(int[][] G)
    {
        int n = G.Length;
        IList<IDictionary<int, int>> edges = new List<IDictionary<int, int>>(n);
        for (int i = 0; i < n; i++)
        {
            edges.Add(new Dictionary<int, int>());
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (G[i][j] >= 0)
                {
                    edges[i][j] = G[i][j];
                    edges[j][i] = G[i][j];
                }
            }
        }
        return edges;
    }

    public static IList<IDictionary<int, int>> buildST(int[][] G, IList<IDictionary<int, int>> edges, int n)
    {
        IList<IDictionary<int, int>> tree = new List<IDictionary<int, int>>(n);
        bool[] vis = new bool[n];

        ISet<int> visset = new HashSet<int>();

        for (int i = 0; i < n; i++)
        {
            tree.Add(new Dictionary<int, int>());
        }

        vis[0] = true;
        visset.Add(0);

        int cand = 0;

        while (visset.Count < n)
        {
            foreach (int node in visset)
            {
                bool flag = false;
                foreach (int nxt in edges[node].Keys)
                {
                    if (!vis[nxt])
                    {
                        flag = true;
                        cand = nxt;
                        vis[nxt] = true;
                        visset.Add(nxt);
                        break;
                    }

                }
                if (flag)
                {
                    tree[node][cand] = G[node][cand];
                    tree[cand][node] = G[node][cand];
                    break;
                }
            }
        }


        return tree;
    }

    public static int getLeaf(IList<IDictionary<int, int>> tree, int n)
    {

        for (int i = 0; i < n; i++)
        {
            if (tree[i].Count == 1)
            {
                return i;
            }
        }
        return -1;
    }

    public static void pairUp(int[] partner, int[][] G)
    {
        int n = G.Length;
        IList<IDictionary<int, int>> edges = getEdges(G), tree;
        tree = buildST(G, edges, n);

        // System.out.println(tree);

        ISet<int> unseen = new HashSet<int>();
        for (int i = 0; i < n; i++)
        {
            unseen.Add(i);
        }
        int leaf = getLeaf(tree, n);
        while (leaf >= 0)
        {
            unseen.Remove(leaf);
            int adj = -1;
            if (!(tree[leaf].Count == 0))
            {
                //adj = tree[leaf].Keys.GetEnumerator().MoveNext()); // the only tree neighbour of leaf
                tree[leaf].Keys.GetEnumerator().MoveNext(); // the only tree neighbour of leaf
                var test = tree[leaf].Keys.GetEnumerator();
                adj = int.Parse(tree[leaf].Keys.GetEnumerator().Current.ToString());
            }
            // System.out.println("pendant "+adj);
            int other = -1;
            if (edges[leaf].Count >= 0)
            {
                // begin pair up

                var nbhrs = new List<int>(edges[leaf].Keys);
                foreach (int item in nbhrs)
                {

                }
                for (int i = 0, buddy; i < nbhrs.Count; i++)
                {
                    buddy = nbhrs[i];
                    if (buddy == adj)
                    {
                        continue;
                    }
                    if (other < 0)
                    {
                        other = buddy;
                    }
                    else
                    {
                        // pair up other and buddy
                        // System.out.println(other+" "+buddy);
                        // System.out.println(G[leaf][other]+" "+G[leaf][buddy]);
                        partner[G[leaf][other]] = G[leaf][buddy];
                        partner[G[leaf][buddy]] = G[leaf][other];
                        edges[leaf].Remove(other);
                        edges[leaf].Remove(buddy);
                        edges[other].Remove(leaf);
                        edges[buddy].Remove(leaf);
                        other = -1;
                    }
                }
            }
            if ((other < 0))
            {
                tree[adj].Remove(leaf);
                tree[leaf].Remove(adj);
            }
            else
            {
                //pair up other and adj
                // System.out.println(other+" "+adj);
                // System.out.println(G[leaf][other]+" "+G[leaf][adj]);
                partner[G[leaf][adj]] = G[leaf][other];
                partner[G[leaf][other]] = G[leaf][adj];
                tree[adj].Remove(leaf);
                tree[leaf].Remove(adj);
                edges[leaf].Remove(other);
                edges[leaf].Remove(adj);
                edges[other].Remove(leaf);
                edges[adj].Remove(leaf);
            }

            leaf = getLeaf(tree, n);
        }

        // we should have unseen.size()<=1 here.
        foreach (int v in unseen)
        {
            ISet<int> nbrs = new HashSet<int>(edges[v].Keys);
            int other = -1;
            foreach (int buddy in nbrs)
            {
                if (other < 0)
                {
                    other = buddy;
                }
                else
                {
                    partner[G[v][buddy]] = G[v][other];
                    partner[G[v][other]] = G[v][buddy];
                    other = -1;
                }
            }
        }

    }

    public static void Main(string[] args)
    {
        //Scanner input = new Scanner(System.in);
        var input = Console.ReadLine().Split();
        int n = int.Parse(input[0]), m = int.Parse(input[1]);

        int[][] G = RectangularArrays.RectangularIntArray(n, n);
        for (int i = 0; i < m; i++)
        {
            input = Console.ReadLine().Split();
            int a = int.Parse(input[0]), b = int.Parse(input[1]);
            G[a][b] = i + 1;
            G[b][a] = i + 1;
        }
        if ((m & 1) == 1)
        {
            Console.WriteLine("impossible");
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    G[i][j]--;
                }
            }
            int[] partner = new int[m];
            for (int i = 0; i < m; i++)
            {
                partner[i] = -1;
            }
            pairUp(partner, G);
            for (int i = 0; i < m; i++)
            {
                if (i > partner[i])
                {
                    Console.WriteLine(i + " " + partner[i]);
                }
            }
        }
    }
}

//Helper class added by Java to C# Converter:

//----------------------------------------------------------------------------------------
//	Copyright © 2007 - 2019 Tangible Software Solutions, Inc.
//	This class can be used by anyone provided that the copyright notice remains intact.
//
//	This class includes methods to convert Java rectangular arrays (jagged arrays
//	with inner arrays of the same length).
//----------------------------------------------------------------------------------------
internal static class RectangularArrays
{
    public static int[][] RectangularIntArray(int size1, int size2)
    {
        int[][] newArray = new int[size1][];
        for (int array1 = 0; array1 < size1; array1++)
        {
            newArray[array1] = new int[size2];
        }

        return newArray;
    }
}
