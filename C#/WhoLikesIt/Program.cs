using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoLikesIt
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = Likes(new string[] { "Alex", "Jacob", "Marion", "Mark" });
            int i = 0;
        }

        public static string Likes(string[] name)
        {
            string output = "";
            int names = name.Count();
            if (names < 2) output = " likes this";
            else output = " like this";

            if (names == 0) return "no one" + output;
            else if (names == 1) return name[1] + output;
            else
            {
                if (names >= 4) output = (names - 2).ToString() + " others" + output;
                else output = name[2] + output;
                output = " and " + output;
            }
            return String.Format("{0}, {1}{2}", name[0], name[1], output);
        }
    }
}
