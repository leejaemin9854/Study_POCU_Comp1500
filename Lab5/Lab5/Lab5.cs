using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public static class Lab5
    {
        public static bool TryFixData(uint[] usersPerDay, double[] revenuePerDay)
        {
            bool bResult = false;
            int index = 0;
            double rightValue = 0;

            if (usersPerDay.Length != revenuePerDay.Length)
                return false;
            

            for (index = 0; index < usersPerDay.Length; index++)
            {
                if (usersPerDay[index] <= 10)
                {
                    rightValue = (double)usersPerDay[index] / 2;

                }
                else if (usersPerDay[index] <= 100)
                {
                    rightValue = 16 * (double)usersPerDay[index] / 5 - 27;

                }
                else if (usersPerDay[index] <= 1000)
                {
                    rightValue = (double)usersPerDay[index] * (double)usersPerDay[index] / 4 - 2 * (double)usersPerDay[index] - 2007;

                }
                else
                {
                    rightValue = 245743 + (double)usersPerDay[index] / 4;

                }


                if (rightValue != revenuePerDay[index])
                {
                    revenuePerDay[index] = rightValue;
                    bResult = true;
                }
            }
            

            return bResult;
        }

        public static int GetInvalidEntryCount(uint[] usersPerDay, double[] revenuePerDay)
        {
            int result = 0;
            double rightValue = 0;
            uint i;

            if (usersPerDay.Length != revenuePerDay.Length || usersPerDay.Length == 0) 
                return -1;


            for (i = 0; i < revenuePerDay.Length; i++)
            {
                if (usersPerDay[i] <= 10)
                {
                    rightValue = (double)usersPerDay[i] / 2;

                }
                else if (usersPerDay[i] <= 100)
                {
                    rightValue = 16f * (double)usersPerDay[i] / 5 - 27;

                }
                else if (usersPerDay[i] <= 1000)
                {
                    rightValue = (double)usersPerDay[i] * (double)usersPerDay[i] / 4 - 2 * (double)usersPerDay[i] - 2007;
                    
                }
                else
                {
                    rightValue = 245743 + (double)usersPerDay[i] / 4;

                }

                if (rightValue != revenuePerDay[i])
                    result++;
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
