using System;

namespace SudokuSolver
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Enter filename with field (leave blank to use default field.txt): ");
            string filename = Console.ReadLine();
            Field field = new Field(filename == "" ? "field.txt" : filename);
            Game game = new Game(field);
            game.StartSolving();
        }
    }
}