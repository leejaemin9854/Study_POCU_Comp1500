﻿using System;
using System.IO;

namespace Assignment1
{
    public static class Assignment1
    {
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

            fmat = f1 + "} " + f2 + "} " + f3 + ":X}";


            int[] nums = new int[5];
            for (int i = 0; i < 5; i++)
            {
                nums[i] = int.Parse(input.ReadLine());
            }

            output.WriteLine(fmat, "oct", "dec", "hex");
            for (int i = 0; i < 5; i++)
            {
                output.WriteLine(fmat, Convert.ToString(nums[i], 8), nums[i], nums[i]);
            }


        }

        public static void PrintStats(StreamReader input, StreamWriter output)
        {
            float[] nums = new float[5];
            float min;
            float max;
            float sum;
            float avg;

            nums[0] = float.Parse(input.ReadLine());
            min = nums[0];
            max = nums[0];
            sum = nums[0];

            for (int i = 1; i < 5; i++)
            {
                nums[i] = float.Parse(input.ReadLine());

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
