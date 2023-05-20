using System;
using System.IO;

namespace Lab3
{
    public static class RestaurantBillCalculator
    {
        public static double CalculateTotalCost(StreamReader input)
        {
            double[] price_food = new double[5];
            int tip;

            double result_sum = 0, result_tax, result_tip, result;

            Console.WriteLine("음식");
            Console.Write("1. 첫번째 음식 가격 = ");
            price_food[0] = double.Parse(Console.ReadLine());

            Console.Write("2. 두번째 음식 가격 = ");
            price_food[1] = double.Parse(Console.ReadLine());

            Console.Write("3. 세번째 음식 가격 = ");
            price_food[2] = double.Parse(Console.ReadLine());

            Console.Write("4. 네번째 음식 가격 = ");
            price_food[3] = double.Parse(Console.ReadLine());

            Console.Write("5. 다섯번째 음식 가격 = ");
            price_food[4] = double.Parse(Console.ReadLine());

            Console.Write("\n팁퍼센트 = ");
            tip = int.Parse(Console.ReadLine());

            foreach (double price in price_food)
            {
                result_sum += price;
            }
            result_tax = result_sum * 0.05;
            result_tip = (result_sum + result_tax) * tip / 100;

            result = result_sum + result_tax + result_tip;
            result = Math.Round(result, 2);
            return result;
        }

        public static double CalculateIndividualCost(StreamReader input, double totalCost)
        {
            int person_count = int.Parse(Console.ReadLine());


            return Math.Round(totalCost / person_count, 2);
        }

        public static uint CalculatePayerCount(StreamReader input, double totalCost)
        {
            double pay = double.Parse(Console.ReadLine());
            uint result = (uint)(totalCost / pay) + 1;

            return result;
        }
    }
}

