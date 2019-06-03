using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtualfriends
{
    class Program
    {
        static void Main(string[] args)
        {
            var testCases = int.Parse(Console.ReadLine());
            var friendArray = new Dictionary<string, int>();
            for (int i = 0; i < testCases; i++)
            {
                var friendships = int.Parse(Console.ReadLine());
                for (int j = 0; j < friendships; j++)
                {
                    var line = Console.ReadLine().Split();
                    var firstName = line[0];
                    var secondName = line[1];

                    if (friendArray.Keys.Contains(firstName) && friendArray.Keys.Contains(secondName)) // fix this
                    {
                        //friendArray[firstName] = friendArray[secondName] += friendArray[firstName];
                        //Console.WriteLine(friendArray[firstName] + 1);
                        var tmp = friendArray[firstName];
                        friendArray[firstName] += friendArray[secondName];
                        Console.WriteLine(friendArray[secondName] + friendArray[firstName]);
                        friendArray[secondName] += friendArray[firstName] - tmp;
                    }
                    else if (friendArray.Keys.Contains(firstName) && !friendArray.Keys.Contains(secondName))
                    {
                        friendArray.Add(secondName, 1);
                        var tmp = friendArray[firstName];
                        friendArray[firstName] += friendArray[secondName];
                        Console.WriteLine(friendArray[secondName] + friendArray[firstName]);
                        friendArray[secondName] += friendArray[firstName] - tmp;
                        //friendArray.Add(secondName, + 1);
                        //friendArray[firstName]++;
                    }
                    else if (!friendArray.Keys.Contains(firstName) && friendArray.Keys.Contains(secondName))
                    {
                        friendArray.Add(firstName, 1);
                        var tmp = friendArray[secondName];
                        friendArray[secondName] += friendArray[firstName];
                        Console.WriteLine(friendArray[firstName] + friendArray[secondName]);
                        friendArray[firstName] += friendArray[secondName] - tmp;

                        //friendArray.Add(firstName, +friendArray[secondName]);
                        //friendArray.Add(firstName, +1);
                        //friendArray[secondName] = friendArray[firstName] += friendArray[secondName];
                        //friendArray[secondName]++;
                    }
                    else
                    {
                        friendArray.Add(firstName, +1);
                        friendArray.Add(secondName, +1);

                        Console.WriteLine(friendArray[firstName] + friendArray[secondName]);
                    }
                    //friendArray.Add(firstName, +1);

                    //if (!friendArray.Keys.Contains(secondName) && friendArray.Keys.Contains(firstName))
                    //    friendArray.Add(secondName, + friendArray[firstName]);
                    //else if (friendArray.Keys.Contains(secondName))
                    //    friendArray[secondName]++;
                    //else
                    //    friendArray.Add(secondName, +1);

                }
            }
        }
    }
}
