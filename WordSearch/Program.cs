using System;

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
        /// <summary>
        /// Main entry point for Word search project
        /// </summary>
        /// <param name="args"></param>
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
        /// Takes words from Words array and iterates over Grid of chars to find a starting row/y and column/x,
        /// when it finds a starting point it takes the result of WordSearch and prints out a result of starting and ending coordinates
        /// for each word.
        /// </summary>
        private static void FindWords()
        {
            foreach(var word in Words)
            {
                int [] coordinates = new int []{};

                for (int r = 0; r < Grid.GetLength(0); ++r)
                {
                    for (int c = 0; c < Grid.GetLength(1); ++c)
                    {
                        if(coordinates.Length > 0)
                        {
                            break;
                        }

                        if (Grid[r, c] == word[0])
                        {
                            coordinates = WordSearch(r, c, word);
                            
                            if(coordinates.Length > 0)
                            {
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine(
                    $"{word} found at ({coordinates[0]}, {coordinates[1]}) to ({coordinates[2]}, {coordinates[3]})"
                );
            }
        }

        /// <summary>
        /// Method that starts with r and c coordinates, then looks in each direction to detect each letter in the word's
        /// sequence.
        /// </summary>
        /// <param name="sr">starting row</param>
        /// <param name="sc">starting column</param>
        /// <param name="word">word to find</param>
        /// <returns>string result</returns>
        public static int [] WordSearch(int sr, int sc, string word)
        {
            int er = -1, ec = -1;

            int[] directionRow = new int[] { -1, -1, 0, 1, 1, 1, 0, -1 }; // directional row/y array
            int[] directionCol = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 }; // directional row/x array

            int row = sr;
            int column = sc;

            // Loop through directions
            for (int i = 0; i < 8; ++i)
            {
                // Loop over word characters
                for(int j = 1; j < word.Length; ++j)
                {   
                    int newRow = row + directionRow[i];
                    int newCol = column + directionCol[i];

                    if (newRow < 0 || newCol < 0)
                    {
                        break;
                    }

                    if (newRow >= Grid.GetLength(0) || newCol >= Grid.GetLength(1))
                    {
                        break;
                    }

                    if(word[j] != Grid[newRow, newCol])
                    {
                        row = sr;
                        column = sc;
                        break;
                    }

                    if(j == word.Length - 1)
                    {
                        er = newRow;
                        ec = newCol;

                        return new int [] {sr, sc, er, ec};
                    }
                    row = newRow;
                    column = newCol;
                }
            }

            return new int [0];
        }
    }
}
