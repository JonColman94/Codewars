using System;
using System.Collections.Generic;
using System.Linq;

public static class Kata
{
   
    //If length if 0 or string is null, return 0, else count vowels
    public static int GetVowelCount(string str)
    {
        return (str.Length == 0 || str == null) ? 0 : str.Count(c => "aeiouAEIOU".Contains(c));
    }
}
