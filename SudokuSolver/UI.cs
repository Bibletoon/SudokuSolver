using System;

namespace SudokuSolver
{
    internal class UI
    {
        public void LogField(Field field)
        {
            for (int coordinateY = 0; coordinateY < Field.Height; coordinateY++)
            {
                Console.WriteLine($"{(coordinateY % 3 == 0 ? "#####################################" : "#---+---+---#---+---+---#---+---+---#")}");
                for (int coordinateX = 0; coordinateX < Field.Width; coordinateX++)
                {
                    Console.Write($"{(coordinateX % 3 == 0 ? "#" : "|")} {(field.GetCell(coordinateY, coordinateX) == 0 ? " " : field.GetCell(coordinateY, coordinateX).ToString())} ");
                }

                Console.WriteLine("#");
            }

            Console.WriteLine("#####################################");
        }
    }
}