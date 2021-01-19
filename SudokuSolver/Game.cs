using System;

namespace SudokuSolver
{
    internal class Game
    {
        private Field _field;

        private readonly UI _userInterface;

        public Game()
        {
            _field = new Field();
            _userInterface = new UI();
        }

        public Game(Field field) : this()
        {
            _field = field;
        }

        public void StartSolving()
        {
            _userInterface.LogField(_field);
            Console.WriteLine("Press any key to solve this sudoku");
            Console.ReadKey(true);
            Solver mySolver = new Solver(_field);
            var result = mySolver.Solve();
            if (result)
            {
                _field = mySolver.Field;
                _userInterface.LogField(_field);
                Console.WriteLine("Sudoku is solved!");
            }
            else
            {
                Console.WriteLine("Whoops! Can't solve sudoku");
            }
        }
    }
}