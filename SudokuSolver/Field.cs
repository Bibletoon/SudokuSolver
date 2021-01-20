using System;
using System.IO;
using System.Text;

namespace SudokuSolver
{
    internal class Field : ICloneable
    {
        public const int Width = 9;
        public const int Height = 9;
        private readonly int[,] _field;

        public Field()
        {
            _field = new int[Height, Width];
        }

        public Field(string filename) : this()
        {
            try
            {
                using var input = new StreamReader(filename);
                for (int coordinateY = 0; coordinateY < Height; coordinateY++)
                {
                    string line = input.ReadLine();
                    for (int coordinateX = 0; coordinateX < Width; coordinateX++)
                    {
                        int num = Int32.Parse(line[coordinateX].ToString());
                        _field[coordinateY, coordinateX] = num;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Couldn't open file. Using empty field.");
            }
        }

        public int GetCell(int coordinateY, int coordinateX)
        {
            return _field[coordinateY, coordinateX];
        }

        public void SetCell(int coordinateY, int coordinateX, int value)
        {
            _field[coordinateY, coordinateX] = value;
        }

        public override string ToString()
        {
            var result = new StringBuilder("", Height * (Width + 1));
            for (int coordinateY = 0; coordinateY < Height; coordinateY++)
            {
                for (int coordinateX = 0; coordinateY < Width; coordinateY++)
                {
                    result.Append(_field[coordinateX, coordinateY].ToString());
                }

                result.Append("\n");
            }

            return result.ToString();
        }

        public object Clone()
        {
            Field cloneField = new Field();
            for (int coordinateY = 0; coordinateY < Height; coordinateY++)
            for (int coordinateX = 0; coordinateX < Width; coordinateX++)
            {
                cloneField.SetCell(coordinateY, coordinateX, _field[coordinateY, coordinateX]);
            }
            

            return cloneField;
        }
    }
}