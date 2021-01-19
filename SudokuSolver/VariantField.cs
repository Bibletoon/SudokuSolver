using System.Collections.Generic;

namespace SudokuSolver
{
    internal class VariantField
    {
        public const int NumsCount = 10;
        public int[,,] Field;

        public VariantField()
        {
            Field = new int[SudokuSolver.Field.Height, SudokuSolver.Field.Width, NumsCount];
            for (int coordinateY = 0; coordinateY < SudokuSolver.Field.Height; coordinateY++)
            {
                for (int coordinateX = 0; coordinateX < SudokuSolver.Field.Width; coordinateX++)
                {
                    for (int number = 0; number < NumsCount; number++)
                    {
                        Field[coordinateY, coordinateX, number] = 1;
                    }
                }
            }
        }

        public VariantField(Field field) : this()
        {
            for (int coordinateY = 0; coordinateY < SudokuSolver.Field.Height; coordinateY++)
            {
                for (int coordinateX = 0; coordinateX < SudokuSolver.Field.Width; coordinateX++)
                {
                    int curNum = field.GetCell(coordinateY, coordinateX);
                    if (curNum != 0) RemoveVariants(coordinateY, coordinateX, curNum);
                }
            }
        }

        private void RemoveVariants(int coordinateY, int coordinateX, int curNum)
        {
            Field[coordinateY, coordinateX, 0] = 0;
            for (int i = 0; i < SudokuSolver.Field.Height; i++)
            {
                Field[i, coordinateX, curNum] = 0;
            }

            for (int i = 0; i < SudokuSolver.Field.Width; i++)
            {
                Field[coordinateY, i, curNum] = 0;
            }

            var squareCoords = GetSquareCoords(coordinateY, coordinateX);
            foreach (var (coordinateYIterator, coordinateXIterator) in squareCoords)
            {
                Field[coordinateYIterator, coordinateXIterator, curNum] = 0;
            }
        }

        private List<(int, int)> GetSquareCoords(int coordinateY, int coordinateX)
        {
            var coordinatesList = new List<(int, int)>();

            List<int> coordinatesYList;
            if (coordinateY < 3)
            {
                coordinatesYList = new List<int> {0, 1, 2};
            }
            else if (coordinateY > 5)
            {
                coordinatesYList = new List<int> {6, 7, 8};
            }
            else
            {
                coordinatesYList = new List<int> {3, 4, 5};
            }

            List<int> coordinatesXList;
            if (coordinateX < 3)
            {
                coordinatesXList = new List<int> {0, 1, 2};
            }
            else if (coordinateX > 5)
            {
                coordinatesXList = new List<int> {6, 7, 8};
            }
            else
            {
                coordinatesXList = new List<int> {3, 4, 5};
            }

            foreach (var coordinateYIterator in coordinatesYList)
            {
                foreach (var coordinateXIterator in coordinatesXList)
                {
                    coordinatesList.Add((coordinateYIterator, coordinateXIterator));
                }
            }

            return coordinatesList;
        }

        public (int coordinateY, int coordinateX, int count) GetMinimalCell()
        {
            (int resultCoordinateY, int resultCoordinateX) cell = (-1, -1);
            int minSum = 11;
            for (int coordinateY = 0; coordinateY < SudokuSolver.Field.Height; coordinateY++)
            {
                for (int coordinateX = 0; coordinateX < SudokuSolver.Field.Width; coordinateX++)
                {
                    if (Field[coordinateY, coordinateX, 0] == 0) continue;
                    int sum = 0;
                    for (int number = 1; number < NumsCount; number++)
                    {
                        sum += Field[coordinateY, coordinateX, number];
                    }

                    if (sum == 1)
                    {
                        return (coordinateY, coordinateX, 1);
                    }
                    else if (sum < minSum)
                    {
                        minSum = sum;
                        cell = (coordinateY, coordinateX);
                    }
                }
            }

            return (cell.resultCoordinateY, cell.resultCoordinateX, minSum);
        }

        public int[] GetCell(int h, int w)
        {
            List<int> cell = new List<int>();
            for (int i = 0; i < NumsCount; i++)
            {
                cell.Add(Field[h, w, i]);
            }

            return cell.ToArray();
        }
    }
}