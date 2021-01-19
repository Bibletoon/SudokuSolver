using System;
using System.IO;

namespace SudokuSolver
{
    internal class Field : ICloneable
    {
        public const int Width = 9;
        public const int Height = 9;
        private readonly int[,] field;

        public Field()
        {
            field = new int[Height, Width];
        }

        public Field(string filename) : this()
        {
            //TODO: error handling?
            using var input = new StreamReader(filename);
            for (int i = 0; i < Height; i++)
            {
                string line = input.ReadLine();
                for (int j = 0; j < Width; j++)
                {
                    int num = Int32.Parse(line[j].ToString());
                    field[i, j] = num;
                }
            }
        }

        public int GetCell(int h, int w)
        {
            return field[h, w];
        }

        public void SetCell(int h, int w, int value)
        {
            field[h, w] = value;
        }

        public override string ToString()
        {
            //TODO: string builder
            string result = "";
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; i < Width; i++)
                {
                    result += field[j, i].ToString();
                }
                result += "\n";
            }

            return result;
        }

        public object Clone()
        {
            Field cloneField = new Field();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    cloneField.SetCell(i, j, field[i, j]);
                }
            }

            return cloneField;
        }
    }
}