using System;
using System.Linq;

namespace RGBToHex
{
    public class Kata
    {
        // Bring rgb values between 0 and 255 inclusively; translate each to 2 digit hex and join.
        public static string Rgb(int r, int g, int b)
        {
            int[] rgb = new int[] { r, g, b };
            return string.Join("", rgb.Select(n => bound(n).ToString("X2")).ToArray());
        }

        private static int bound(int n)
        {
            return (n < 0) ? 0 : (n > 255) ? 255 : n;
        }
    }
}
