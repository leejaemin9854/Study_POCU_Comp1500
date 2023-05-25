using System.Diagnostics;

namespace Lab4
{
    public static class Calendar
    {
        public static bool IsLeapYear(uint year)
        {
            if (year == 0)
                return false;

            if (year % 400 == 0)
                return true;
            else if (year % 100 == 0)
                return false;
            else if (year % 4 == 0)
                return true;
            else
                return false;
        }

        public static int GetDaysInMonth(uint year, uint month)
        {
            if (year > 9999 || month == 0 || month > 12)
                return -1;

            int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            int result = days[month - 1];

            if (month == 2 && IsLeapYear(year))
                result += 1;

            return result;
        }
    }
}
