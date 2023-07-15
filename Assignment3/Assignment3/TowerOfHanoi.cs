using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class TowerOfHanoi
    {
        public static int Pow(int num, int power)
        {
            int result = 1;
            for (int i = 0; i < power; i++)
            {
                result*= num;
            }

            return result;
        }

        public static int GetNumberOfSteps(int numDiscs)
        {
            if (numDiscs < 0)
                return -1;

            return Pow(2, numDiscs) - 1;
        }

        public static List<List<int>[]> SolveTowerOfHanoi(int numDiscs)
        {
            List<List<int>[]> result = new List<List<int>[]>();
            if (numDiscs < 1)
                return result;

            List<int>[] line;
            int num = GetNumberOfSteps(numDiscs);
            for (int i = 0; i < num + 1; i++)
            {
                line = new List<int>[3];
                for (int j = 0; j < line.Length; j++)
                {
                    line[j] = new List<int>();
                }

                result.Add(line);
            }

            for (int i = numDiscs; i > 0; i--)
            {
                result[0][0].Add(i);
            }

            List<int[]> moveInfo = new List<int[]>(num);
            ReturnHanoiMoveInfo(moveInfo, numDiscs, 1, 3);
            


            for (int i = 0; i < moveInfo.Count; i++)
            {
                CopyListAry(result[i + 1], result[i]);

                Move(result[i + 1], moveInfo[i][0], moveInfo[i][1]);
            }



            return result;
        }

        static void CopyListAry(List<int>[] dst, List<int>[] src)
        {
            for (int i = 0; i < src.Length; i++)
            {
                for (int j = 0; j < src[i].Count; j++)
                {
                    dst[i].Add(src[i][j]);
                }
            }
        }

        public static void Move(List<int>[] list, int from, int to)
        {
            from--;
            to--;

            int num = list[from][list[from].Count - 1];
            list[from].RemoveAt(list[from].Count - 1);
            list[to].Add(num);

        }

        public static void ReturnHanoiMoveInfo(List<int[]> sb, int disks, int fromPeg, int toPeg)
        {
            if (disks == 0)
                return;


            int sparePeg = 6 - fromPeg - toPeg;

            //재귀 조건
            ReturnHanoiMoveInfo(sb, disks - 1, fromPeg, sparePeg);

            int[] info = new int[] { fromPeg, toPeg };
            sb.Add(info);


            ReturnHanoiMoveInfo(sb, disks - 1, sparePeg, toPeg);
        }
    }
}
