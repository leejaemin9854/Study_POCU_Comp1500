using System;
using System.IO;

namespace Lab3
{
    public static class RestaurantBillCalculator
    {
        public static double CalculateTotalCost(StreamReader input)
        {
            double[] priceFood = new double[5];
            int tip;

            double resultSum = 0, resultTax, resultTip, result;

            Console.WriteLine("음식");
            Console.Write("1. 첫번째 음식 가격 = ");
            priceFood[0] = double.Parse(input.ReadLine());

            Console.Write("2. 두번째 음식 가격 = ");
            priceFood[1] = double.Parse(input.ReadLine());

            Console.Write("3. 세번째 음식 가격 = ");
            priceFood[2] = double.Parse(input.ReadLine());

            Console.Write("4. 네번째 음식 가격 = ");
            priceFood[3] = double.Parse(input.ReadLine());

            Console.Write("5. 다섯번째 음식 가격 = ");
            priceFood[4] = double.Parse(input.ReadLine());

            Console.Write("\n팁퍼센트 = ");
            tip = int.Parse(input.ReadLine());

            foreach (double price in priceFood)
            {
                resultSum += price;
            }
            resultTax = resultSum * 0.05;
            resultTip = (resultSum + resultTax) * tip / 100;

            result = resultSum + resultTax + resultTip;
            result = Math.Round(result, 2);
            return result;
        }

        public static double CalculateIndividualCost(StreamReader input, double totalCost)
        {
            double personCount = double.Parse(input.ReadLine());


            return Math.Round(totalCost / personCount, 2);
        }

        public static uint CalculatePayerCount(StreamReader input, double totalCost)
        {
            double pay = double.Parse(input.ReadLine());
            double result = Math.Round(totalCost / pay);
            if (result < totalCost)
                result += 1;



            return (uint)result;
        }
    }
}

