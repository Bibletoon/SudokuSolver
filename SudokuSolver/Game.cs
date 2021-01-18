using System;

namespace SudokuSolver
{
    class Game
    {
        private Field field;
        private readonly UI UserInterface;

        public Game()
        {
            field = new Field();
            UserInterface = new UI();
        }

        public Game(string filename) : this()
        {
            field = new Field(filename);
        }

        public void StartSolving()
        {
            UserInterface.LogField(field);
            Console.WriteLine("Press any key to solve this sudoku");
            Console.ReadKey(true);
            Solver mySolver = new Solver(field);
            var result = mySolver.Solve();
            if (result)
            {
                field = mySolver.Field;
                UserInterface.LogField(field);
                Console.WriteLine("Sudoku is solved!");
            }
            else
            {
                Console.WriteLine("Whoops! Can't solve sudoku");
            }
        }
    }
}
