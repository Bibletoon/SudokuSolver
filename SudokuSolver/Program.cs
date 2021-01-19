using System;

namespace SudokuSolver
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Enter filename with field (leave blank to use default field.txt): ");
            string filename = Console.ReadLine();
            Game game = new Game(filename == "" ? "field.txt" : filename);
            game.StartSolving();
        }
    }
}