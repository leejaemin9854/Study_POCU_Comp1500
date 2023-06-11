using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public static class Lab6
    {
        public enum EMode
        {
            HorizontalMirror,
            VerticalMirror,
            DiagonalShift
        };

        public static int[,] Rotate90Degrees(int[,] data)
        {
            int[,] ary = new int[data.GetLength(1), data.GetLength(0)];
            int i;
            int j;

            for (i = 0; i < data.GetLength(0); i++)
            {
                for (j = 0; j < data.GetLength(1); j++)
                {
                    ary[j, data.GetLength(0) - i - 1] = data[i, j];
                }
            }
            

            return ary;
        }



        public static void TransformArray(int[,] data, EMode emod)
        {
            int i;
            int j;


            if (emod == EMode.HorizontalMirror)
            {

                for (i = 0; i < data.GetLength(0); i++)
                {
                    for (j = 0; j < data.GetLength(1) / 2; j++) 
                    {
                        int value = data[i, j];
                        data[i, j] = data[i, data.GetLength(1) - j - 1];
                        data[i, data.GetLength(1) - j - 1] = value;
                    }
                }

            }
            else if (emod == EMode.VerticalMirror)
            {

                for (i = 0; i < data.GetLength(0) / 2; i++) 
                {
                    for (j = 0; j < data.GetLength(1); j++)
                    {
                        int value = data[i, j];
                        data[i, j] = data[data.GetLength(0) - i - 1, j];
                        data[data.GetLength(0) - i - 1, j] = value;
                    }
                }

            }
            else if(emod==EMode.DiagonalShift)
            {
                int[] row = new int[data.GetLength(0) - 1];
                int[] col = new int[data.GetLength(1) - 1];
                int last = data[data.GetLength(0) - 1, data.GetLength(1) - 1];

                for (i = 0; i < data.GetLength(0) - 1; i++) 
                {
                    row[i] = data[i, data.GetLength(1) - 1];
                }
                
                for (i = 0; i < data.GetLength(1) - 1; i++)
                {
                    col[i] = data[data.GetLength(0) - 1, i];
                }




                for (i = 0; i < data.GetLength(0) - 1; i++)
                {
                    for (j = 0; j < data.GetLength(1) - 1; j++)
                    {
                        data[data.GetLength(0) - i - 1, data.GetLength(1) - j - 1] = data[data.GetLength(0) - i - 2, data.GetLength(1) - j - 2];
                    }
                }

                for (i = 1; i < data.GetLength(0); i++) 
                {
                    data[i, 0] = row[i - 1];
                }
                for (i = 1; i < data.GetLength(1); i++)
                {
                    data[0, i] = col[i - 1];
                }

                data[0, 0] = last;

            }


        }
    }
}
