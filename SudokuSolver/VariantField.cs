﻿using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    class VariantField
    {
        //TODO: Learn, how to implement "constants" properly
        public static int numsCount = 10;
        public int[,,] field;

        public VariantField()
        {
            field = new int[Field.Height, Field.Width, numsCount];
            for (int i = 0; i < Field.Height; i++)
            {
                for (int j = 0; j < Field.Width; j++)
                {
                    for (int k = 0; k < numsCount; k++)
                    {
                        field[i, j, k] = 1;
                    }
                }
            }
        }

        public VariantField(Field field) : this()
        {
            for (int i = 0; i < Field.Height; i++)
            {
                for (int j = 0; j < Field.Width; j++)
                {
                    int curNum = field.GetCell(i,j);
                    if (curNum != 0) RemoveVariants(i, j, curNum);
                }
            }
        }

        private void RemoveVariants(int h,int w,int curNum)
        {
            field[h, w, 0] = 0;
            for (int i = 0; i < Field.Height; i++)
            {
                field[i, w, curNum] = 0;
            }

            for (int i = 0; i < Field.Width; i++)
            {
                field[h, i, curNum] = 0;
            }

            var squareCoords = GetSquareCoords(h, w);
            foreach (var (i,j) in squareCoords)
            {
                field[i, j, curNum] = 0;
            }

        }

        private List<(int, int)> GetSquareCoords(int h, int w)
        {
            var coordList = new List<(int, int)>();

            //TODO: rewrite this algorythm
            List<int> coordH;
            if (h < 3)
            {
                coordH = new List<int>{0,1,2};
            } else if (h > 5)
            {
                coordH = new List<int>{6,7,8};
            }
            else
            {
                coordH = new List<int>{3,4,5};
            }

            List<int> coordW;
            if (w < 3)
            {
                coordW = new List<int>{0,1,2};
            } else if (w > 5)
            {
                coordW = new List<int>{6,7,8};
            }
            else
            {
                coordW = new List<int>{3,4,5};
            }

            foreach (var i in coordH)
            {
                foreach (var j in coordW)
                {
                    coordList.Add((i,j));
                }
            }

            return coordList;
        }

        public (int,int,int) GetMinimalCell()
        {
            (int, int) cell = (-1, -1);
            int minSum = 11;
            for (int i = 0; i < Field.Height; i++)
            {
                for (int j = 0; j < Field.Width; j++)
                {
                    if (field[i, j, 0] == 0) continue;
                    int sum = 0;
                    for (int k = 1; k < numsCount; k++)
                    {
                        sum += field[i, j, k];
                    }

                    if (sum == 1)
                    {
                        return (i, j, 1);
                    } else if (sum < minSum)
                    {
                        minSum = sum;
                        cell = (i, j);
                    }
                }
            }

            return (cell.Item1, cell.Item2, minSum);
        }

        public int[] GetCell(int h, int w)
        {
            List<int> cell = new List<int>();
            for (int i = 0; i < numsCount; i++)
            {
                cell.Add(field[h,w,i]);
            }
            return cell.ToArray();
        }
    }
}
