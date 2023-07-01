using System;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{

    public static class Lab7
    {

        public static bool Func(uint[] array, uint index)
        {
            if (index == array.Length - 1)
                return true;
            if (array[index] == 0)
                return false;

            uint value = array[index];
            uint[] ary = new uint[array.Length];
            for (uint i = 0; i < array.Length; i++)
            {
                ary[i] = array[i];
            }
            ary[index] = 0;

            if (array.Length <= value + index && value > index)
                return false;

            if (array.Length <= value + index)
                return Func(ary, index - value);
            if (value > index)
                return Func(ary, index + value);

            return Func(ary, index - value) || Func(ary, index + value);


        }

        public static bool PlayGame(uint[] array)
        {
            if (array.Length <= 1)
                return false;
            if (array[0] == 0 || array[0] >= array.Length) 
                return false;

            uint[] ary = new uint[array.Length - 1];
            for (int i = 0; i < ary.Length; i++)
            {
                ary[i] = array[i + 1];
            }
            return Func(ary, array[0] - 1);
        }
    }
}

