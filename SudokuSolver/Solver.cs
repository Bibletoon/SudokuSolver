using System;

namespace SudokuSolver
{
    class Solver
    {
        public Field Field { get; set; }
        public Solver(Field field)
        {
            this.Field = field;
        }

        private bool CheckSolved()
        {
            for (int i = 0; i < Field.Height; i++)
            {
                for (int j = 0; j < Field.Width; j++)
                {
                    if (Field.GetCell(i,j) == 0) return false;
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
                var (y,x,count) = varField.GetMinimalCell();
                var cell = varField.GetCell(y, x);
                if (count==0)
                {
                    return false;
                }

                if (count!=1)
                {
                    for (int i = 1; i < VariantField.NumsCount; i++)
                    {
                        if (cell[i] == 1)
                        {
                            //TODO: check
                            if (y == 1 && x == 0)
                            {
                                Console.Write("");
                            }
                            var subSolver = new Solver((Field)Field.Clone());
                            subSolver.Field.SetCell(y,x,i);
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
                    Field.SetCell(y, x, cellNum);
                }
                varField = new VariantField(Field);
            }

            return true;
        }

        private int GetCellNum(int[] cell)
        {
            for (int i = 1; i < VariantField.NumsCount; i++)
            {
                if (cell[i] == 1) return i;
            }

            //TODO: ensure code will not fail in case when -1 return
            return -1;
        }
    }
}
