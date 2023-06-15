using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public static class Canvas
    {
        public enum EShape
        {
            Rectangle,
            IsoscelesRightTriangle,
            IsoscelesTriangle,
            Circle
        };


        public static void ShowCanvas(char[,] canvas)
        {
            int[] size = { canvas.GetLength(0), canvas.GetLength(1) };
            
            int i;
            int j;

            for (i = 0; i < size[0]; i++)
            {
                for (j = 0; j < size[1]; j++)
                {
                    Console.Write(canvas[i, j]);
                }
                Console.WriteLine();
            }
        }
        private static int Reset(char[,] canvas)
        {
            int width = canvas.GetLength(1);
            int height = canvas.GetLength(0);
            if (width <= 0 || height <= 0)
                return 0;


            int i;
            int j;

            for (i = 0; i < width; i++)
            {
                for (j = 0; j < height; j++)
                {
                    canvas[j, i] = ' ';
                }
            }


            for (i = 0; i < width; i++)
            {
                canvas[0, i] = '-';
                canvas[height - 1, i] = '-';
            }
            for (j = 1; j < height - 1; j++)
            {
                canvas[j, 0] = '|';
                canvas[j, width - 1] = '|';
            }

            return 1;
        }

        public static bool Compare(char[,] ch1, char[,] ch2)
        {
            int width = ch1.GetLength(0);
            int height = ch1.GetLength(1);
            if (width != ch2.GetLength(0) || height != ch2.GetLength(1))
                return false;


            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (ch1[i, j] != ch2[i, j])
                        return false;
                }
            }



            return true;
        }

        public static char[,] Draw(uint width, uint height, EShape shape)
        {
            char[,] canvas;
            if (width == 0 || height == 0)
            {
                canvas = new char[0, 0];
                return canvas;
            } 
                

            if (shape == EShape.Rectangle)
            {
                canvas = new char[height + 4, width + 4];

                Reset(canvas);

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        canvas[j + 2, i + 2] = '*';
                    }
                }
            }
            else if (shape == EShape.IsoscelesRightTriangle)
            {
                if (width != height) 
                {
                    canvas = new char[0, 0];
                }
                else
                {
                    canvas = new char[height + 4, width + 4];
                    Reset(canvas);

                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < i + 1; j++)
                        {
                            canvas[i + 2, j + 2] = '*';
                        }
                    }
                }
            }
            else if (shape == EShape.IsoscelesTriangle)
            {
                if (width != height * 2 - 1) 
                {
                    canvas = new char[0, 0];
                }
                else
                {
                    canvas = new char[height + 4, width + 4];
                    Reset(canvas);

                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < i * 2 + 1; j++)  
                        {
                            canvas[i + 2, width / 2 - i + j + 2] = '*';
                        }
                    }
                }

            }
            else
            {
                if (width != height || width % 2 == 0) 
                {
                    canvas = new char[0, 0];
                }
                else
                {
                    canvas = new char[height + 4, width + 4];
                    Reset(canvas);

                    uint rad = width / 2;

                    for (uint i = 0; i < height; i++)
                    {
                        uint dis = 0;
                        if (rad > i)
                            dis = rad - i;
                        else
                            dis = i - rad;

                        uint count = 0;
                        for (; count < width; count++)
                        {
                            if (count * count > rad * rad - dis * dis)
                                break;
                        }

                        count = count * 2 - 1;
                        for (uint j = 0; j < count; j++)
                        {
                            canvas[i + 2, (width - count) / 2 + j + 2] = '*';
                        }
                    }
                }

            }
            

            return canvas;
        }

        public static bool IsShape(char[,] canvas, EShape shape)
        {
            if (canvas.Length == 0)
                return false;

            char[,] rightCanvas = Draw((uint)canvas.GetLength(1) - 4, (uint)canvas.GetLength(0) - 4, shape);

            return Compare(canvas, rightCanvas);
        }
    }
}
