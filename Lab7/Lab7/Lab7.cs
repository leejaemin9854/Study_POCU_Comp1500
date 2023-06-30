using System;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{

    public static class Lab7
    {

        public static bool ReculsiveFunc(uint[] array, uint index)
        {
            if (array[index] == 0)
                return true;

            if (array[index] + index >= array.Length && index < array[index])
                return false;

            if (array[index] + index >= array.Length)
                return array[index - array[index]] != array[index] ? ReculsiveFunc(array, index - array[index]) : false;

            if (index < array[index])
                return array[array[index] + index] != array[index] ? ReculsiveFunc(array, array[index] + index) : false;


            return ReculsiveFunc(array, index - array[index]) || ReculsiveFunc(array, array[index] + index);
        }

        public static bool PlayGame(uint[] array)
        {
            if (array.Length <= 1)
                return false;
            if (array[0] >= array.Length)
                return false;

            uint[] ary = new uint[array.Length - 1];
            for (int i = 0; i < ary.Length; i++)
            {
                ary[i] = array[i + 1];
            }
            return ReculsiveFunc(ary, array[0] - 1);
        }
    }
}

