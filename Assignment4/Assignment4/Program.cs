using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Assignment4
{
    class Program
    {
        static int arenaTurns = 0;
        static void Main(string[] args)
        {
            List<int> test= new List<int>(5);
            for (int i = 0; i < 5; i++)
            {
                test.Add(i);
            }

            test.RemoveAt(0);
            test.RemoveAt(6);
            
        }


    }
}
