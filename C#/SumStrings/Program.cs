using System;
using System.Collections.Generic;
using System.Text;

namespace SumStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(sumStrings("544", "456"));
        }

        public static string sumStrings(string a, string b)
        {
            if (b.Equals("0")) return a;
            if (a.Equals("0")) return b;
            bool carry = false;
            Stack<string> sumStack = new Stack<string>();
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < Math.Min(a.Length, b.Length); index++)
            {
                int addition = (a[a.Length - index - 1] - '0') + (b[b.Length - index - 1] - '0')
                    + (carry ? 1 : 0);
                carry = addition > 9;
                sumStack.Push((addition % 10).ToString());
            }
            if (a.Length == b.Length && carry) sb.Append("1");
            else sb.Append(sumStrings(a.Length > b.Length ? a.Substring(0, a.Length - sumStack.Count) : b.Substring(0, b.Length - sumStack.Count), carry ? "1" : "0"));
            string append = default;
            while (sumStack.TryPop(out append))
                sb.Append(append);
            return sb.ToString().TrimStart('0');
        }
    }
}
