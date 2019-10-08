using System;

namespace BuildPileCubes
{
    public class ASum
    {
        // Uses the knowledge that sum of r^3 = ((n(n+1))/2)^2
        public static long findNb(long m)
        {
            long sqrt = (long)Math.Sqrt(m);
            if (sqrt * sqrt != m) return -1;
            long n = (long)Math.Sqrt(sqrt * 2);
            return (n * (n + 1) == sqrt * 2) ? n : -1;

        }

    }
}
