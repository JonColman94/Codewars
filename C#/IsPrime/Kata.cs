using System;
using System.Collections.Generic;
using System.Linq;

namespace IsPrime
{
    public static class Kata
    {

        public static bool IsPrime(int n)
        {
            List<int> primes = new List<int>(Enumerable.Range(2, n-2));
            int count = primes.Count;
            for (int startIndex = 0; startIndex < count; startIndex++)
            {
                int prime = primes.ElementAt(startIndex);
                if (prime == n) return true;
                int searchIndex = startIndex - 1;
                while (searchIndex < count)
                {
                    if (primes.ElementAt(searchIndex) % prime == 0)
                    {
                        primes.RemoveAt(searchIndex);
                        count--;
                    }
                    else searchIndex++;
                }
            }

            return false;
        }
    }
}
