using System;

namespace SudokuSolver
{
    internal class UI
    {
        public void LogField(Field field)
        {
            for (int i = 0; i < Field.Height; i++)
            {
                Console.WriteLine($"{(i % 3 == 0 ? "#####################################" : "#---+---+---#---+---+---#---+---+---#")}");
                for (int j = 0; j < Field.Width; j++)
                {
                    Console.Write($"{(j % 3 == 0 ? "#" : "|")} {(field.GetCell(i, j) == 0 ? " " : field.GetCell(i, j).ToString())} ");
                }
                Console.WriteLine("#");
            }

            Console.WriteLine("#####################################");
        }
    }
}