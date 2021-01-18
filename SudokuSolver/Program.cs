using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter filename with field (leave blank to use default field.txt): ");
            string filename = Console.ReadLine();
            filename = filename == "" ? "field.txt" : filename;
            Game game=new Game("field.txt");
            game.StartSolving();
        }
    }
}
