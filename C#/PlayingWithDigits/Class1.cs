using System;
using System.Linq;

namespace PlayingWithDigits
{
    public class DigPow
    {
        public static long digPow(int n, int p)
        {
            // Group digits with their indexes, and sum each digit by it's respective power.
            long sum = n.ToString().Sum(d => (long) Math.Pow(d - '0', p++));
            long divisor = sum / n;
            // Check if divisor and n multiply into sum, this is cheaper than modulo => division
            return (divisor *  n == sum) ? divisor : -1;
        }
    }
}
