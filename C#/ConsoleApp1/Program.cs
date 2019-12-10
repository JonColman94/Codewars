using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(IsPrime(17).ToString());
        }

        public static bool IsPrime(int n)
        {
            bool[] sieve = new bool[n+1];
            for (int index = 2; index <= n; index++)
                sieve[index] = true;

            for (int index = 2; index*index <= n; index++)
            {
                if (sieve[index])
                {
                    for (int step = 2; index*step <= n; step++)
                    {
                        if (index * step == n) return false;
                        sieve[index * step] = false;
                    }
                }
            }
            return true;
        }
    }
}
