using System;

namespace TicTacToeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsSolved(new int[,] { { 1,2,0 }, { 0, 1, 2 }, { 0, 0, 1 } }));
            Console.ReadLine();
        }

        public static int IsSolved(int[,] board)
        {
            bool emptySpaces = false;
            int searchResult;
            // Search Rows
            for (int y = 0; y < 3; y++)
            {
                if ((searchResult = search(board, 0, y, 1, 0, ref emptySpaces)) > 0) return searchResult;
            }
            //Search Columns and Diagonals
            for (int x = 0; x < 3; x++)
            {

                if ((searchResult = search(board, x, 0, 0, 1, ref emptySpaces)) > 0) return searchResult;
                //Search Diagonal
                if (x != 1)
                {
                    if ((searchResult = search(board, x, 0, 1-x, 1, ref emptySpaces)) > 0) return searchResult;
                }
            }
            return emptySpaces ? -1 : 0;
        }



        private static int search(int[,] board, int xStart, int yStart, int xStep, int yStep, ref bool isEmpty)
        {
            int x = xStart; int y = yStart;
            int output = -1;
            while (isInBounds(x, y))
            {
                switch (board[y,x])
                {
                    case 0:
                        isEmpty = true;
                        return -1;
                    case 1:
                        if (output < 0) output = 1;
                        else if (output == 2) output = 0;
                        break;
                    case 2:
                        if (output < 0) output = 2;
                        else if (output == 1) output = 0;
                        break;
                }
                x += xStep;
                y += yStep;
            }
            return output;
        }

        private static bool isInBounds(int x, int y)
        {
            return (x >= 0 && y >= 0 && x < 3 && y < 3);
        }
    }
}
