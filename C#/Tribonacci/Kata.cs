using System;
using System.Collections.Generic;
using System.Linq;

namespace Tribonacci
{
    public class Xbonacci
    {
        /*
         * Take the signature, and for every new value found, push the oldest value in signature queue into sequence
         */
        public double[] Tribonacci(double[] signature, int n)
        {
            Queue<double> sequence = new Queue<double>();
            Queue<double> sigQueue = new Queue<double>(signature);
            double sigSum = sigQueue.Sum();
            for (int k = 1; k <= n; k++)
            {
                double value = sigQueue.Dequeue();
                sigQueue.Enqueue(sigSum);
                sigSum += sigSum - value;
                sequence.Enqueue(value);
            }
            return sequence.ToArray();
        }
    }
}
