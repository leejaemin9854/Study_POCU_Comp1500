using System;
using System.IO;

namespace Assignment1
{
    internal static class Assignment1
    {
        static string DeleteSpace(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= '0' && str[i] <= '9')
                    result += str[i];
            }
            return result;
        }

        static string NumberConvert(string str, int convertNum)
        {
            string numberString = "";
            char[] ch = { 'A', 'B', 'C', 'D', 'E', 'F' };

            decimal num = decimal.Parse(str);
            while (true)
            {
                decimal temp = num % convertNum;
                if (temp < 10)
                    numberString += Convert.ToString(temp);
                else
                    numberString += ch[(int)temp - 10];
                num -= temp;
                if (num <= 0)
                    break;
                num /= convertNum;
            }

            string result = "";
            for (int i = 0; i < numberString.Length; i++)
            {
                result += numberString[numberString.Length - i - 1];
            }


            return result;
        }

        public static void PrintIntegers(StreamReader input, StreamWriter output, int width)
        {
            string f1 = "{0,";
            string f2 = "{1,";
            string f3 = "{2,";
            string fmat = "";

            if (width <= 10)
                width = 10;

            f1 += Convert.ToString(width);
            f2 += Convert.ToString(width);
            f3 += Convert.ToString(width);

            fmat = f1 + "} " + f2 + "} " + f3 + "}";
            string[] nums = new string[5];
            for (int i = 0; i < 5; i++)
            {
                nums[i] = DeleteSpace(input.ReadLine());
            }


            output.WriteLine(fmat, "oct", "dec", "hex");
            for (int i = 0; i < 5; i++)
            {
                output.WriteLine(fmat, NumberConvert(nums[i], 8), nums[i], NumberConvert(nums[i], 16));
            }

        }

        public static void PrintStats(StreamReader input, StreamWriter output)
        {
            double[] nums = new double[5];
            double min;
            double max;
            double sum;
            double avg;

            nums[0] = double.Parse(input.ReadLine());
            min = nums[0];
            max = nums[0];
            sum = nums[0];

            for (int i = 1; i < 5; i++)
            {
                nums[i] = double.Parse(input.ReadLine());

                if (min > nums[i])
                    min = nums[i];
                if (max < nums[i])
                    max = nums[i];

                sum += nums[i];
            }
            avg = sum / 5f;

            for (int i = 0; i < 5; i++)
            {
                output.WriteLine("{0,25:f3}", nums[i]);
            }

            output.WriteLine("Min{0,22:f3}", min);
            output.WriteLine("Max{0,22:f3}", max);
            output.WriteLine("Sum{0,22:f3}", sum);
            output.WriteLine("Average{0,18:f3}", avg);
        }
    }
}
