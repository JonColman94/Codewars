using System;

namespace MatrixDeterminant
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Determinant(new int[][] { new int[] { 2,5,3 }, new int[] { 1,-2,-1 }, new int[] { 1,3,4 } }));
        }

        public static int Determinant(int[][] matrix)
        {
            if (matrix.Length == 1) return matrix[0][0];
            int det = 0;
            int[][] minor = new int[matrix.Length-1][];
            int multiplier = -1;
            for (int column = 0; column < matrix.Length; column++)
            {
                multiplier *= -1;
                // 0 * a = 0
                if (matrix[0][column] == 0) continue;
                // Generate minor matrix
                for (int row = 1; row < matrix.Length; row++)
                {
                    minor[row - 1] = new int[matrix.Length - 1];
                    int index = 0;
                    for (int minor_column = 0; minor_column < matrix.Length; minor_column++)
                    {
                        if (minor_column != column)
                        {
                            minor[row - 1][index] = matrix[row][minor_column];
                            index++;
                        }
                    }
                }
                det += multiplier * matrix[0][column] * Determinant(minor);
            }

            return det;
        }
    }
}
