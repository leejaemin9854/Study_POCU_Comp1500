using System;
using System.IO;

namespace Assignment1
{
    public static class Assignment1
    {
        public static void PrintIntegers(StreamReader input, StreamWriter output, int width)
        {

        }

        public static void PrintStats(StreamReader input, StreamWriter output)
        {
            float[] nums = new float[5];
            float min, max, sum, avg;

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
