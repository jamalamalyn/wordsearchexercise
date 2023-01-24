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

        private static void FindWords()
        {
            string word = "PUPPY";
            string result = "";

            for(int r = 0; r < Grid.GetLength(0); ++r)
            {
                for(int c = 0; c < Grid.GetLength(1); ++c)
                {
                    if(Grid[r,c] == word[0])
                    {
                        Console.WriteLine("Found first letter in Grid: " + Grid[r,c]);
                        result = breadthFirstSearch(r, c, word);
                        if(!string.IsNullOrEmpty(result))
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(result);
        }

        public static string breadthFirstSearch(int sr, int sc, string word)
        {
            int [] directionRow = new int [] {-1,-1,0,1,1,1,0,-1};
            int [] directionCol = new int [] {0,1,1,1,0,-1,-1,-1};

            Queue<int> rowQueue = new Queue<int>();
            Queue<int> columnQueue = new Queue<int>();

            int er = -1, ec = -1;

            rowQueue.Enqueue(sr);
            columnQueue.Enqueue(sc);

            bool [,] visited = new bool [Grid.GetLength(0),Grid.GetLength(1)];
            string stitchedString = "";

            foreach(char c in word)
            {
                while(rowQueue.Count > 0)
                {
                    int row = rowQueue.Dequeue();
                    int column = columnQueue.Dequeue();

                    Console.WriteLine("Checking" + row + ", " + column);

                    visited[row, column] = true;

                    if(c != Grid[row, column])
                    {
                        continue;
                    }
                    else 
                    {
                        Console.WriteLine("Found " + c + " at " + row + ", " + column);
                        stitchedString += c;
                    }

                    if(stitchedString == word)
                    {
                        er = row;
                        ec = column;
                        break;
                    }

                    for(int i = 0; i < 8; ++i)
                    {
                        int newRow = row + directionRow[i];
                        int newCol = column + directionCol[i];

                        if(newRow < 0 || newCol < 0) 
                            continue;

                        if(newRow >= Grid.GetLength(0) || newCol >= Grid.GetLength(1)) 
                            continue;

                        if(visited[newRow, newCol]) 
                            continue;

                        rowQueue.Enqueue(newRow);
                        columnQueue.Enqueue(newCol);
                        visited[newRow, newCol] = true;
                    }
                }
            }

            if(er > -1 && ec > -1){
                return $"{word} found at ({sr}, {sc}) to ({er}, {ec})";
            }
            else 
            {
                return null;
            }
        }
    }
}
