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
            decimal rightValue = 0;

            if (usersPerDay.Length != revenuePerDay.Length)
                return false;
            

            for (index = 0; index < usersPerDay.Length; index++)
            {
                if (usersPerDay[index] <= 10)
                {
                    rightValue = (decimal)usersPerDay[index] / 2;

                }
                else if (usersPerDay[index] <= 100)
                {
                    rightValue = 16 * (decimal)usersPerDay[index] / 5 - 27;

                }
                else if (usersPerDay[index] <= 1000)
                {
                    rightValue = (decimal)usersPerDay[index] * (decimal)usersPerDay[index] / 4 - 2 * (decimal)usersPerDay[index] - 2007;

                }
                else
                {
                    rightValue = 245743 + (decimal)usersPerDay[index] / 4;

                }


                if ((float)rightValue != (float)revenuePerDay[index])
                {
                    revenuePerDay[index] = (double)rightValue;
                    bResult = true;
                }
            }
            

            return bResult;
        }

        public static int GetInvalidEntryCount(uint[] usersPerDay, double[] revenuePerDay)
        {
            int result = 0;
            decimal rightValue = 0;
            int i;

            if (usersPerDay.Length != revenuePerDay.Length || usersPerDay.Length == 0) 
                return -1;


            for (i = 0; i < revenuePerDay.Length; i++)
            {
                if (usersPerDay[i] <= 10f)
                {
                    rightValue = (decimal)usersPerDay[i] / 2;

                }
                else if (usersPerDay[i] <= 100f)
                {
                    rightValue = 16 * (decimal)usersPerDay[i] / 5 - 27;

                }
                else if (usersPerDay[i] <= 1000f)
                {
                    rightValue = (decimal)usersPerDay[i] * (decimal)usersPerDay[i] / 4 - 2 * (decimal)usersPerDay[i] - 2007;
                    
                }
                else
                {
                    rightValue = 245743 + (decimal)usersPerDay[i] / 4;

                }

                if (rightValue != (decimal)revenuePerDay[i])
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
