using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class Lab8
    {
        
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
            string nLine = "\n";

            char[] delimsLv = { '|', '_', '/' };
            uint[] index = { 0, 0, 0 };

            addString = $"{++index[0]}) ";
            result += addString;

            foreach (char c in s)
            {
                if (c == delimsLv[0])
                {

                    addString = $"{nLine}{index[0] + 1}) ";

                    result += addString;

                    index[0]++;
                    index[1] = 0;
                    index[2] = 0;
                }
                else if (c == delimsLv[1])
                {
                    index[2] = 1;

                    addString = $"{nLine}    {ChangeToAlpha(index[1])}) ";

                    result += addString;

                    index[1]++;
                }
                else if (index[2] == 1 && c == delimsLv[2]) 
                {
                    addString = $"{nLine}        - ";

                    result += addString;
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
