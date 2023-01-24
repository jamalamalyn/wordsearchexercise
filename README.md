# Word Search Exercise
---
## Background
Given a grid of letters and a list of words modify the program to find each word in the grid and display the start and end coordinates.  The words can go in all 8 directions.

## Goal
Find each of the words in the words array in the grid of letters, output the start and end location of each:
	e.g. PUPPY found at (10,7) to (10, 3) 
  
 ## Models
 ### Grid
 ```csharp
  static char[,] Grid = new char[,] 
  {
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
 ```
 ### Words to find
 ```csharp
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
 ```
