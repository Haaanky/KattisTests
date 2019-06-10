using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Edge
{
    int u, v, index;
    public Edge(int x, int y, int label)
    {
        index = label;
        u = (x < y) ? x : y;
        v = (x < y) ? y : x;
    }

    public int Other(int x)
    {
        return x == u ? v : u;
    }
}

public class translatorsdinner
{
    public static List<Dictionary<int, int>> GetEdges(int[][] G)
    {
        int n = G.Length;
        List<Dictionary<int, int>> edges = new List<Dictionary<int, int>>(n);
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
                    edges[i].Add(j, G[i][j]);
                    edges[j].Add(i, G[i][j]);
                }
            }
        }
        return edges;
    }

    public static List<Dictionary<int, int>> BuildST(int[][] G, List<Dictionary<int, int>> edges, int n)
    {
        var tree = new List<Dictionary<int, int>>(n);
        var vis = new bool[n];

        var visset = new HashSet<int>();


        for (int i = 0; i < n; i++)
        {
            tree.Add(new Dictionary<int, int>());
        }

        vis[0] = true;
        visset.Add(0);

        int cand = 0;

        while (visset.Count < n - 1)
        {
            for (int node = 0; node <= visset.Count; node++)
            {
                bool flag = false;
                for (int nxt = 0; nxt <= edges[node].Keys.Count; nxt++)
                {
                    if (!vis[nxt])
                    {
                        flag = true;
                        cand = nxt;
                        vis[nxt] = true;
                        visset.Add(nxt);
                        //break;
                    }

                    if (flag)
                    {
                        tree[node].Add(cand, G[node][cand]);
                        tree[cand].Add(node, G[node][cand]);
                        //break;
                    }
                }
            }
        }


        return tree;
    }

    public static int GetLeaf(List<Dictionary<int, int>> tree, int n)
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

    public static void PairUp(int[] partner, int[][] G)
    {
        int n = G.Length;
        List<Dictionary<int, int>> edges = GetEdges(G), tree;
        tree = BuildST(G, edges, n);

        // System.out.println(tree);

        var unseen = new HashSet<int>();
        for (int i = 0; i < n; i++)
        {
            unseen.Add(i);
        }
        int leaf = GetLeaf(tree, n);
        while (leaf >= 0)
        {
            unseen.Remove(leaf);
            // System.out.println(tree);
            // System.out.println("leaf "+leaf);
            int adj = -1;
            if (tree[leaf].Count != 0)
            {
                adj = tree[leaf].Keys.ElementAt(0); // the only tree neighbour of leaf
            }
            // System.out.println("pendant "+adj);
            int other = -1;
            if (edges[leaf].Count >= 0)
            {
                // begin pair up

                var nbhrs = new HashSet<int>(edges[leaf].Keys);
                for (int buddy = 0; buddy < nbhrs.Count; buddy++)
                {
                    if (buddy == adj)
                    {
                        continue;
                    }
                    else if (other < 0)
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

            leaf = GetLeaf(tree, n);
        }

        // we should have unseen.size()<=1 here.
        for (int v = 0; unseen.Count <= 1; v++)
        {
            var nbrs = new HashSet<int>(edges[v].Keys);
            int other = -1;
            for (int buddy = 0; buddy < nbrs.Count; buddy++)
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
        string input;
        int i = 0;
        int hiredTranslators = 0;
        int languagesSpoken = 0;
        int[][] G = new int[0][];

        while ((input = Console.ReadLine()) != null)
        {
            var split = input.Split();
            if (hiredTranslators == 0)
            {
                languagesSpoken = int.Parse(split[0]);
                hiredTranslators = int.Parse(split[1]);
                if (hiredTranslators % 2 != 0)
                { Console.WriteLine("impossible"); return; }
                G = new int[languagesSpoken][];
                for (int j = 0; j < G.Length; j++)
                {
                    G[j] = new int[hiredTranslators];
                }
            }
            else
            {
                int a = int.Parse(split[0]), b = int.Parse(split[1]);
                G[a][b] = i + 1;
                G[b][a] = i + 1;

                //translators[i] = new Translator
                //{
                //    ID = i,
                //    FirstLanguage = int.Parse(split[0]),
                //    SecondLanguage = int.Parse(split[1])
                //};
                i++;
            }
        }

        //Scanner sc = new Scanner(System.in);
        //int languagesSpoken = sc.nextInt(), m = sc.nextInt();
        //int[][] G = new int[languagesSpoken][languagesSpoken];
        //for (int i = 0; i < hiredTranslators; i++)
        //{
        //    int a = sc.nextInt(), b = sc.nextInt();
        //    G[a][b] = i + 1;
        //    G[b][a] = i + 1;
        //}
        //if ((m & 1) == 1)
        //{
        //    Console.WriteLine("impossible");
        //}
        //else
        //{
        for (int k = 0; k < languagesSpoken; k++)
        {
            for (int j = 0; j < languagesSpoken; j++)
            {
                G[k][j]--;
            }
        }
        int[] partner = new int[hiredTranslators];
        for (int l = 0; l < hiredTranslators; l++)
        {
            partner[l] = -1;
        }
        PairUp(partner, G);
        for (int m = 0; m < hiredTranslators; m++)
        {
            if (m > partner[m])
            {
                Console.WriteLine(m + " " + partner[m]);
            }
        }
        //}
    }

}