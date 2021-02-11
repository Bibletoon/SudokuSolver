using System;
using System.Text;

namespace SudokuSolver
{
    internal class UI
    {
        public void LogField(Field field)
        {
            var edgeLine = new StringBuilder("#",(Field.Width / 3) * 12 + 1);
            var middleLine = new StringBuilder("#",(Field.Width / 3) * 12 + 1);
            for (int i = 0; i < Field.Width / 3; i++)
            {
                edgeLine.Append(new string('#', 12));
                middleLine.Append("---+---+---#");
            }
            
            for (int coordinateY = 0; coordinateY < Field.Height; coordinateY++)
            {
                Console.WriteLine($"{(coordinateY % 3 == 0 ? edgeLine.ToString() : middleLine.ToString())}");
                for (int coordinateX = 0; coordinateX < Field.Width; coordinateX++)
                {
                    Console.Write($"{(coordinateX % 3 == 0 ? "#" : "|")} {(field.GetCell(coordinateY, coordinateX) == 0 ? " " : field.GetCell(coordinateY, coordinateX).ToString())} ");
                }

                Console.WriteLine("#");
            }

            Console.WriteLine(edgeLine.ToString());
        }
    }
}