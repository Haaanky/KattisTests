using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8queens
{
    class Program
    {
        static void Main(string[] args)
        {
            var chessBoard = new string[8];
            for (int i = 0; i < 8; i++)
            {
                chessBoard[i] = Console.ReadLine();
            }

            var queenCoordinates = new int[8];
            var index = 0;
            for (int i = 0; i < chessBoard.Length; i++)
            {
                if (chessBoard[i].Count(x => x == '*') != 1)
                {
                    Console.WriteLine("invalid");
                    return;
                }
                if (queenCoordinates.Contains(index = chessBoard[i].IndexOf('*')) && index != 0)
                {
                    Console.WriteLine("invalid");
                    return;
                }
                queenCoordinates[i] = index;
            }
            if (queenCoordinates.Sum() != 28)
            {
                Console.WriteLine("invalid");
                return;
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 1; i + j < 8; j++)
                {
                    if (queenCoordinates[i] + j == queenCoordinates[i + j])
                    {
                        Console.WriteLine("invalid");
                        return;
                    }
                    else if (i - j < 0)
                        continue;
                    else if (queenCoordinates[i] - j == queenCoordinates[i - j])
                    {
                        Console.WriteLine("invalid");
                        return;
                    }
                }
            }
            Console.WriteLine("valid");
        }
    }
}
