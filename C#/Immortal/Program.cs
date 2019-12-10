using System;

namespace Immortal
{
    class Immortal
    {
        static void Main(string[] args)
        {
            //PrintGrid(8, 5, 1);
            Console.WriteLine(ElderAge(28827050410L, 35165045587L, 7109602, 13719506));
        }

        public static long ElderAge(long n, long m, long k, long newp)
        {
            if (n < 1 || m < 1) return 0;
            if (n > m) return ElderAge(m, n, k, newp);
            long largest_power_2 = (long) Math.Pow(2, Math.Floor(Math.Log2(m)));
           // PrintGrid(Math.Min(n, largest_power_2), largest_power_2, k);
            long block_total = Math.Min(n, largest_power_2) * ((sumN(largest_power_2 - 1 - ((k > 0) ? k : 0)) % newp) + ((k < 0) ? ((largest_power_2)%newp * (-k)) : 0));
            long side_total = ElderAge(Math.Min(n, largest_power_2), m - largest_power_2, k - largest_power_2, newp);
            long bottom_total = ElderAge(n - largest_power_2, largest_power_2, k - largest_power_2, newp);
            long diag_total = ElderAge(n - largest_power_2, m - largest_power_2, k, newp);
            return (block_total + side_total + bottom_total + diag_total) % newp; 
        }

        public static long sumN(long n)
        {
            if (n < 1) return 0;
            long sum = (n * (n + 1)) / 2;
            return sum;
        }

        public static void PrintGrid(long n, long m, long k)
        {
            string gridString = "";
            for (long row = 0; row < n; row++)
            {
                string rowString = "";
                for (long column = 0; column < m; column++)
                {
                    long xor = (row ^ column);
                    long value = (xor < k) ? 0 : (xor - k);
                    rowString += value.ToString() + " ";
                }
                gridString += rowString + "\n";
            }
            Console.WriteLine(gridString + "\n" + "\n");
        }
    }
}
