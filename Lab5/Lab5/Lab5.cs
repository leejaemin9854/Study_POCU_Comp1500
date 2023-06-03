using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public static class Lab5
    {
        public static bool TryFixData(uint[] usersPerDay, double[] revenuePerDay)
        {
            bool result = false;
            int index = 0;
            double rightValue = 0;

            if (usersPerDay.Length != revenuePerDay.Length)
                return false;
            

            for (index = 0; index < usersPerDay.Length; index++)
            {
                if (usersPerDay[index] <= 10)
                {
                    rightValue = (double)usersPerDay[index] / 2;

                    if(rightValue != revenuePerDay[index])
                    {
                        revenuePerDay[index] = rightValue;
                        result = true;
                    }

                }
                else if (usersPerDay[index] <= 100)
                {
                    rightValue = 16 * (double)usersPerDay[index] / 5 - 27;

                    if (rightValue != revenuePerDay[index])
                    {
                        revenuePerDay[index] = rightValue;
                        result = true;
                    }

                }
                else if (usersPerDay[index] <= 1000)
                {
                    rightValue = (double)usersPerDay[index] * (double)usersPerDay[index] / 4 - 2 * (double)usersPerDay[index] - 2007;
                    
                    if (rightValue != revenuePerDay[index])
                    {
                        revenuePerDay[index] = rightValue;
                        result = true;
                    }

                }
                else
                {
                    rightValue = 245743 + (double)usersPerDay[index] / 4;

                    if (rightValue != revenuePerDay[index])
                    {
                        revenuePerDay[index] = rightValue;
                        result = true;
                    }

                }
            }
            

            return result;
        }

        public static int GetInvalidEntryCount(uint[] usersPerDay, double[] revenuePerDay)
        {
            int result = 0;
            int index = 0;
            double rightValue = 0;


            if (usersPerDay.Length != revenuePerDay.Length)
                return -1;


            for (index = 0; index < usersPerDay.Length; index++)
            {
                if (usersPerDay[index] <= 10)
                {
                    rightValue = (double)usersPerDay[index] / 2;
                    result += rightValue != revenuePerDay[index] ? 1 : 0;

                }
                else if (usersPerDay[index] <= 100)
                {
                    rightValue = 16 * (double)usersPerDay[index] / 5 - 27;
                    result += rightValue != revenuePerDay[index] ? 1 : 0;

                }
                else if (usersPerDay[index] <= 1000)
                {
                    rightValue = (double)usersPerDay[index] * (double)usersPerDay[index] / 4 - 2 * (double)usersPerDay[index] - 2007;
                    result += rightValue != revenuePerDay[index] ? 1 : 0;

                }
                else
                {
                    rightValue = 245743 + (double)usersPerDay[index] / 4;
                    result += rightValue != revenuePerDay[index] ? 1 : 0;

                }
            }

            return result;
        }

        public static double CalculateTotalRevenue(double[] revenuePerDay, uint start, uint end)
        {
            double result = 0;
            uint index = 0;

            if (revenuePerDay.Length == 0 || start < 0 || end >= revenuePerDay.Length || start > end)  
                return -1;

            for (index = start; index <= end; index++)
            {
                result += revenuePerDay[index];
            }

            return result;
        }
    }
}
