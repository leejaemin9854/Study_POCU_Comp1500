using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    internal class Lab9
    {
        public static List<int> MergeLists(List<int> sortedList1, List<int> sortedList2)
        {
            List<int> result = new List<int>(sortedList1.Count + sortedList2.Count);

            foreach (int num in sortedList1)
            {
                result.Add(num);
            }
            
            foreach (int num in sortedList2)
            {
                int index = 0;

                for (index = 0; index < result.Count; index++)
                {
                    if (result[index] > num)
                    {
                        break;
                    }
                }
                result.Insert(index, num);

            }


            return result;
        }

        public static Dictionary<string, int> CombineListsToDictionary(List<string> keys, List<int> values)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            int size = keys.Count <= values.Count ? keys.Count : values.Count;
            int index = 0;

            for (index = 0; index < size; index++)
            {
                if (!result.ContainsKey(keys[index]))
                {
                    result.Add(keys[index], values[index]);
                }

            }


            return result;
        }

        public static Dictionary<string, decimal> MergeDictionaries(Dictionary<string, int> numerators, Dictionary<string, int> denominators)
        {
            Dictionary<string, decimal> result = new Dictionary<string, decimal>();

            if (numerators.Count > 0 && denominators.Count > 0)
            {
                foreach (KeyValuePair<string, int> numer in numerators)
                {
                    if (denominators.ContainsKey(numer.Key) && denominators[numer.Key] != 0) 
                    {
                        decimal va = (decimal)numer.Value / (decimal)denominators[numer.Key];

                        result.Add(numer.Key, va < 0 ? va * -1 : va);

                    }

                }

            }



            return result;
        }

    }
}
