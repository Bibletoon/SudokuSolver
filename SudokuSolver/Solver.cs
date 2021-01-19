using System;

namespace SudokuSolver
{
    internal class Solver
    {
        public Field Field { get; set; }

        public Solver(Field field)
        {
            this.Field = field;
        }

        private bool CheckSolved()
        {
            for (int coordinateY = 0; coordinateY < Field.Height; coordinateY++)
            {
                for (int coordinateX = 0; coordinateX < Field.Width; coordinateX++)
                {
                    if (Field.GetCell(coordinateY, coordinateX) == 0) return false;
                }
            }

            return true;
        }

        public bool Solve()
        {
            //TODO: do better!
            VariantField varField = new VariantField(Field);
            while (!CheckSolved())
            {
                var (coordinateY, coordinateX, count) = varField.GetMinimalCell();

                if (count == 0 || count == 11)
                {
                    return false;
                }

                var cell = varField.GetCell(coordinateY, coordinateX);
                

                if (count != 1)
                {
                    for (int number = 1; number < VariantField.NumsCount; number++)
                    {
                        if (cell[number] == 1)
                        {
                            var subSolver = new Solver((Field)Field.Clone());
                            subSolver.Field.SetCell(coordinateY, coordinateX, number);
                            if (subSolver.Solve())
                            {
                                Field = subSolver.Field;
                                return true;
                            }
                        }
                    }

                    return false;
                }
                else
                {
                    var cellNum = GetCellNum(cell);
                    Field.SetCell(coordinateY, coordinateX, cellNum);
                }

                varField = new VariantField(Field);
            }

            return true;
        }

        private int GetCellNum(int[] cell)
        {
            for (int number = 1; number < VariantField.NumsCount; number++)
            {
                if (cell[number] == 1) return number;
            }

            //TODO: ensure code will not fail in case when -1 return
            return -1;
        }
    }
}