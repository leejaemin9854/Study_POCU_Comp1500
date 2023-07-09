using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class Lab8
    {
        public static int test(string s1, string s2)
        {
            string p = s1.Length >= s2.Length ? s2 : s1;

            for (int i = 0; i < p.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    Console.WriteLine($"B: s1[{i-1}]: {(int)s1[i-1]}");
                    Console.WriteLine($"B: s2[{i-1}]: {(int)s2[i-1]}");

                    Console.WriteLine($"s1[{i}]: {(int)s1[i]}");
                    Console.WriteLine($"s2[{i}]: {(int)s2[i]}");

                    Console.WriteLine($"A: s1[{i + 1}]: {(int)s1[i + 1]}");
                    Console.WriteLine($"A: s2[{i + 1}]: {(int)s2[i + 1]}");

                    return i;
                } 
            }
            Console.WriteLine("Same");
            return -1;

        }


        public static string ChangeToAlpha(uint num)
        {
            StringBuilder s = new StringBuilder(128);
            uint cnt = num / 26 + 1;

            num = num % 26 + 97;

            for (uint i = 0; i < cnt; i++)
            {
                s.Append((char)num);
            }

            return s.ToString();
        }




        public static string PrettifyListOrNull(string s)
        {
            if (s == "")
                return null;

            string result = "";

            string addString;
            string nLine = "\r\n";

            char[] delims_lv = { '|', '_', '/' };
            uint[] index = { 0, 0, 0 };

            addString = $"{++index[0]}) ";
            result += addString;

            foreach (char c in s)
            {
                if (c == delims_lv[0])
                {

                    addString = $"{nLine}{index[0] + 1}) ";

                    result += addString;

                    index[0]++;
                    index[1] = 0;
                    index[2] = 0;
                }
                else if (c == delims_lv[1])
                {
                    index[2] = 1;

                    addString = $"{nLine}    {ChangeToAlpha(index[1])}) ";

                    result += addString;

                    index[1]++;
                }
                else if (index[2] == 1 && c == delims_lv[2]) 
                {
                    addString = $"{nLine}        - ";

                    result+=addString;
                }
                else
                {
                    result += addString;
                }

            }
            result += addString;

            return result.ToString();
        }

    }
}
