using System;

namespace FindMissingLetter
{
    public class Kata
    {

        public static char FindMissingLetter(char[] array)
        {
            if (array.Length < 2) throw new ArgumentOutOfRangeException("Required input array must have length 2 or greater");
            char current = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] != ++current) return current;
            }
            return ++current;
        }

    }
}
