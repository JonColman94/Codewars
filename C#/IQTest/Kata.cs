using System;
using System.Linq;

public class IQ
{
    /*
     * This solution assumes that there is one 'odd one out' in the sequence of numbers.
     * Indexes in this solution start at 1, not 0. It sums the indexes where the value is odd.
     * If the odd number out is an odd number, the only counted index is the odd index.
     * Otherwise, the solution exploits the idea that the Sum(N) from 1 to n - counted sum will yield the correct index
     * Uses bit logic to find odd numbers, as bit logic is less expensive than modulo
     */
    public static int Test(string numbers)
    {
        string[] split = numbers.Split(' ');
        // Group values by {value, index}
        long sum = split.Select((number, index) => new { Value = int.Parse(number), Index = index + 1 })
            .Where(x => (x.Value & 1) == 1)         // Find odd values
            .Sum(x => x.Index);                     // Sum indexes
        return (int)(sum <= split.LongCount() ? sum : ((split.LongCount()) * (split.LongCount() + 1L) / 2 - sum));
    }
}