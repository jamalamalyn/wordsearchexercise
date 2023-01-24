using System;
using System.Collections.Generic;

namespace WordSearch
{
    class Program
    {
        static char[,] Grid = new char[,] {
            {'C', 'P', 'K', 'X', 'O', 'I', 'G', 'H', 'S', 'F', 'C', 'H'},
            {'Y', 'G', 'W', 'R', 'I', 'A', 'H', 'C', 'Q', 'R', 'X', 'K'},
            {'M', 'A', 'X', 'I', 'M', 'I', 'Z', 'A', 'T', 'I', 'O', 'N'},
            {'E', 'T', 'W', 'Z', 'N', 'L', 'W', 'G', 'E', 'D', 'Y', 'W'},
            {'M', 'C', 'L', 'E', 'L', 'D', 'N', 'V', 'L', 'G', 'P', 'T'},
            {'O', 'J', 'A', 'A', 'V', 'I', 'O', 'T', 'E', 'E', 'P', 'X'},
            {'C', 'D', 'B', 'P', 'H', 'I', 'A', 'W', 'V', 'X', 'U', 'I'},
            {'L', 'G', 'O', 'S', 'S', 'B', 'R', 'Q', 'I', 'A', 'P', 'K'},
            {'E', 'O', 'I', 'G', 'L', 'P', 'S', 'D', 'S', 'F', 'W', 'P'},
            {'W', 'F', 'K', 'E', 'G', 'O', 'L', 'F', 'I', 'F', 'R', 'S'},
            {'O', 'T', 'R', 'U', 'O', 'C', 'D', 'O', 'O', 'F', 'T', 'P'},
            {'C', 'A', 'R', 'P', 'E', 'T', 'R', 'W', 'N', 'G', 'V', 'Z'}
        };

        static string[] Words = new string[]
        {
            "CARPET",
            "CHAIR",
            "DOG",
            "BALL",
            "DRIVEWAY",
            "FISHING",
            "FOODCOURT",
            "FRIDGE",
            "GOLF",
            "MAXIMIZATION",
            "PUPPY",
            "SPACE",
            "TABLE",
            "TELEVISION",
            "WELCOME",
            "WINDOW"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Word Search");

            for (int y = 0; y < 12; y++)
            {
                for (int x = 0; x < 12; x++)
                {
                    Console.Write(Grid[y, x]);
                    Console.Write(' ');
                }
                Console.WriteLine("");

            }

            Console.WriteLine("");
            Console.WriteLine("Found Words");
            Console.WriteLine("------------------------------");

            FindWords();

            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void FindWords()
        {
            foreach(var word in Words)
            {
                for (int r = 0; r < Grid.GetLength(0); ++r)
                {
                    bool found = false;
                    for (int c = 0; c < Grid.GetLength(1); ++c)
                    {
                        if (Grid[r, c] == word[0])
                        {
                            found = BreadthFirstSearch(r, c, word);
                        }
                    }
                    if(found)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Method that starts with r and c coordinates, then looks in each direction to detect each word
        /// </summary>
        /// <param name="sr"></param>
        /// <param name="sc"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool BreadthFirstSearch(int sr, int sc, string word)
        {
            int er = -1, ec = -1;

            string toPrint = "";
            bool wordHasBeenFound = false;
            int[] directionRow = new int[] { -1, -1, 0, 1, 1, 1, 0, -1 };
            int[] directionCol = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };

            int row = sr;
            int column = sc;

            for (int i = 0; i < 8; ++i)
            {
                for(int j = 1; j < word.Length; ++j)
                {   
                    int newRow = row + directionRow[i];
                    int newCol = column + directionCol[i];

                    if (newRow < 0 || newCol < 0)
                        break;

                    if (newRow >= Grid.GetLength(0) || newCol >= Grid.GetLength(1))
                        break;

                    if(word[j] != Grid[newRow, newCol])
                    {
                        break;
                    }

                    if(j == word.Length - 1)
                    {
                        ec = newRow;
                        er = newCol;
                        wordHasBeenFound = true;
                        break;
                    }

                    row = newRow;
                    column = newCol;
                }
                if(wordHasBeenFound)
                {
                    toPrint = $"{word} found at ({sr}, {sc}) to ({er}, {ec})";
                    Console.WriteLine(toPrint);
                    break;
                }
            }

            return wordHasBeenFound;
        }
}
}
