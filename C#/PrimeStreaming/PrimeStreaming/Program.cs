using System;
using System.Collections.Generic;

namespace PrimeStreaming
{
    class Program
    {
        public static IEnumerable<int> Stream()
        {
            Queue<int> primes = new Queue<int>();
            primes.Enqueue(2); yield return 2;
            primes.Enqueue(3); yield return 3;
            int number = 5;
            while (true)
            {
                if (isPrime(number, ref primes)) yield return number;
                number += 2;
            }
        }

        private static bool isPrime(int n, ref Queue<int> primes)
        {
            foreach (int prime in primes)
            {
                if (prime*prime > n)
                {
                    primes.Enqueue(prime);
                    return true;
                }
                if (n % prime == 0) return false;
            }
            return true;
        }
    }
}
