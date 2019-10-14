using System;

namespace NumberOfTrailingZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int TrailingZeros(int n)
        {
            int factors = 0;
            int divisor = 5;
            while (n >= divisor)
            {
                factors += n / divisor;
                divisor *= 5;
            }
            return factors;
        }
    }
}
